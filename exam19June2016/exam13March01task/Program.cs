using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam13March01task
{
    class Program
    {
        static void Main()
        {
            //01. 13 marth 2016
            string[] inp = Console.ReadLine().Split(new [] {", "}, StringSplitOptions.RemoveEmptyEntries);

            MakeMagic(inp);
        }

        private static void MakeMagic(string[] inp)
        {
           
            var singleNum = "";
            var set = new List<string>();
            for (int i = 0; i < inp.Length; i++) //4
            {
                for (int j = 0; j < inp[i].Length; j++) //1111
                {
                    
                    var sub = inp[i].Substring(0+j, 1);
                    switch (sub)
                    {
                        case "0":
                            singleNum += "zero";
                            break;
                        case "1":
                            singleNum += "one";
                            break;
                        case "2":
                            singleNum += "two";
                            break;
                        case "3":
                            singleNum += "three";
                            break;
                        case "4":
                            singleNum += "four";
                            break;
                        case "5":
                            singleNum += "five";
                            break;
                        case "6":
                            singleNum += "six";
                            break;
                        case "7":
                            singleNum += "seven";
                            break;
                        case "8":
                            singleNum += "eight";
                            break;
                        case "9":
                            singleNum += "nine";
                            break;
                       

                    }//end switch

                    if (inp[i].Length > 1 && j < inp[i].Length - 1)
                    {
                        singleNum += "-";//da proveriavam length i togava da advam
                    }
                    sub = "";

                } //end vutreshen for
                set.Add(singleNum);
                singleNum = "";
            }//end vunshen
           // Console.WriteLine();
            ReverseBack(set);
        }

        private static void ReverseBack(List<string> set)
        {
            var number = "";
            var singleNum = "";
            var ordered = set.OrderBy(s => s);

                foreach (var num in ordered)
                {
               
                    var tokens = num.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries); //0-1
                    for (int i = 0; i < tokens.Length; i++)
                    {
                      switch (tokens[i]) //zero
                     {
                        case "zero":
                            singleNum += "0";
                            break;
                        case "one":
                            singleNum += "1";
                            break;
                        case "two":
                            singleNum += "2";
                            break;
                        case "three":
                            singleNum += "3";
                            break;
                        case "four":
                            singleNum += "4";
                            break;
                        case "five":
                            singleNum += "5";
                            break;
                        case "six":
                            singleNum += "6";
                            break;
                        case "seven":
                            singleNum += "7";
                            break;
                        case "eight":
                            singleNum += "8";
                            break;
                        case "nine":
                            singleNum += "9";
                            break;
                    } //end switch


                } //end for
                    number += singleNum + ", ";
                    singleNum = "";
                } //end foreach


            if (number.EndsWith(", "))
            {

                Console.WriteLine(number.Remove(number.Length - 2));
            }
            else
            {
                Console.WriteLine(number);
            }
            
           
        }
    }
}
