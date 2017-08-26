using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.AshesOfRoses
{
    class Program
    {
        static void Main()
        {
            

            Regex rgx = new Regex(@"^Grow <(?<region>[A-Z][a-z]+)> <(?<color>[A-Za-z0-9]+)> (?<amount>[0-9]+)$");
            

            string inp = Console.ReadLine();
            int number = 0;
            int roses = 0;

            var regionsInfo = new Dictionary<string, Dictionary<string, long>>();

            while (inp != "Icarus, Ignite!")
            {
                var match = rgx.Match(inp);

                if (!match.Success) 
                {
                    continue;
                }

                var regName = match.Groups["region"].Value;
                var color = match.Groups["color"].Value;
                var amount = int.Parse(match.Groups["amount"].Value);

                if (!regionsInfo.ContainsKey(regName)) //ako go niama regiona
                {
                    regionsInfo[regName] = new Dictionary<string, long>();
                }

                if (!regionsInfo[regName].ContainsKey(color)) //ako cveta go niama
                {
                    regionsInfo[regName].Add(color, 0);
                }

                regionsInfo[regName][color] += amount;

                inp = Console.ReadLine();
            }

            foreach (var region in regionsInfo
                .OrderByDescending(r=>r.Value.Values.Sum()) //ili rg.Value.Sum(r=>r.Value)
                .ThenBy(rg => rg.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var color in region.Value
                    .OrderBy(c => c.Value).ThenBy(c1 => c1.Key))
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
                
                
            
        }
    }
}
