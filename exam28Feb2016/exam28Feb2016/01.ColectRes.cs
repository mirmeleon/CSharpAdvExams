using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace exam28Feb2016
{
    class Program
    {
        static void Main()
        {
            bool isValidResourse = false;
            var resourses = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
            int paths = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, int>();
            bool timeToStop = false;
            string key = "";
            int val = 0;
            var sum = new List<int>();

            for (int i = 0; i < paths; i++)
            {
                var startAndStep = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                var start = startAndStep[0];
                var step = startAndStep[1];
               
               // currentIndex = (start + step) % resourses.Length;//(0+3)%4 =3

              
                    for (int j = start; j < resourses.Length; j = (j+step) % resourses.Length)//(currentIndex+step) % resourses.Length)
                    {
                    //stone_5 gold_2 wood_7 metal_17; start = 0, step =3
                    //j = 0, 3, 2
                        if (timeToStop)
                        {
                           // Console.WriteLine("time!");
                            break;

                        }

                        isValidResourse = ValidateResource(resourses[j]);
                    //stone_5
                        if (isValidResourse)
                        {
                        if (resourses[j].Contains("_"))
                        {
                            var res = resourses[j].Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                            key = res[0];
                            val = int.Parse(res[1]);
                        }
                        else
                        {
                            key = resourses[j];
                            val = 1;
                        }
                    } //end isValid


                    if (!dic.ContainsKey(key) && isValidResourse)
                    {
                        dic[key] = val;
                    }
                    else if(dic.ContainsKey(key) && key != "")
                    {
                            timeToStop = true;
                    }

                        Console.WriteLine(j);
                        key = "";
                       // val = 0;
                    } //end for
               
                    sum.Add(dic.Values.Sum());
                dic.Clear();
                timeToStop = false;
            }//end for paths
            Console.WriteLine(sum.Max());
        }

        protected static bool ValidateResource(string resName)
        {
            bool isValid = false;
            var name = "";
            if (resName.Contains("_"))
            {
                var res = resName.Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
                name = res[0];
            }
            else
            {
                name = resName;
            }
           

            //stone, gold, wood and food
            switch (name)
            {
                case "stone":
                    isValid = true;
                    break;
                case "gold":
                    isValid = true;
                    break;
                case "wood":
                    isValid = true;
                    break;
                case "food":
                    isValid = true;
                    break;

            }

            return isValid;
        }

      
    }
}
