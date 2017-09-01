using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam28Feb04task
{
    class Program
    {
        private static DateTime eventTime;
        static void Main(string[] args)
        {
            //04. events
            string pattern = @"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d+:\d+)$";
            Regex rgx = new Regex(pattern);
            int N = int.Parse(Console.ReadLine());
            //city -> person -> time1, time2, time3
            var data = new SortedDictionary<string, SortedDictionary<string, List<DateTime>>>();

            for (int i = 1; i <= N; i++)
            {
                Match match = rgx.Match(Console.ReadLine());
                if (match.Success && IsValidDate(match.Groups[3].Value))
                {
                    string person = match.Groups[1].Value;
                    string location = match.Groups[2].Value;

                    if (!data.ContainsKey(location))
                    {
                        data[location] = new SortedDictionary<string, List<DateTime>>();
                    }
                    if (!data[location].ContainsKey(person))
                    {
                        data[location][person] = new List<DateTime>();
                    }

                    data[location][person].Add(eventTime);
                }
            }

            string[] locations = Console.ReadLine().Split(',');

            foreach (var pair in data)
            {
                if (locations.Contains(pair.Key))
                {
                    Console.WriteLine(pair.Key + ":");
                    int lineNumber = 1;
                    foreach (var personData in pair.Value)
                    {
                        var formattedEventTimes = personData.Value
                            .OrderBy(v => v)
                            .Select(v => v.ToString("HH:mm")); //podrejda po chasove i min
                        Console.WriteLine($"{lineNumber++}. {personData.Key} -> {string.Join(", ", formattedEventTimes)}");
                    }
                }
            }
        }

        private static bool IsValidDate(string d)
        {
            //chisto i prosto polzva tryparse za validacia ...
            return DateTime.TryParse(d, out eventTime);
        }
    
    }
}
