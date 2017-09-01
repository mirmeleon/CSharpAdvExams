using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam13March2016task02
{
    class Program
    {
        static void Main()
        {
            //02. 13 Marh Monopoly -> 100t.

            var inp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var m = new char[inp[0]][];
            string input = "";
            var rows = inp[0];
            var cols = inp[1];
           
          
                for (var i = 0; i < inp[0]; i++)
                {
                input = Console.ReadLine(); 
                m[i] = new char[inp[1]];
                    for (var j = 0; j < inp[1]; j++)
                    {

                        m[i][j] = input[j];
                    }
                  

                }

            Monopoly(m, rows, cols);

        }

        private static void Monopoly(char[][] m, int rows, int cols)
        {
            var money = 50;
            var turns = 0;
            var hotels = 0;
            var turnsInJail = 0;

            for (int r = 0; r < m.Length; r++)
            {
                if ((r+1) % 2 == 0) 
                {
                    for (int c = cols-1; c >= 0; c--)
                    {
                        if (m[r][c] == 'H')
                        {
                            hotels++;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                            money = 0;
                          
                            m[r][c] = 'O';
                        }

                       

                        if (m[r][c] == 'J')
                        {
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                           turns += 2;
                           turnsInJail += 2;
                             money += 2 * (hotels*10);
                       
                           // continue;
                        }
                        
                        if (m[r][c] == 'S')
                        {
                            var currRow = r + 1;
                            var currCol = c + 1;
                           
                            int spentMoney = Math.Min((currCol) * (currRow), money);
                           
                            money -= spentMoney;
                            Console.WriteLine($"Spent {spentMoney} money at the shop.");
                        }

                        turns++;
                        money += 10 * hotels;
                    } //end col for
                }
                else
                {
                  
                  
                    for (int c = 0; c < cols; c++)
                    {
                        if (m[r][c] == 'H')
                        {
                            hotels++;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                            money = 0;
                         
                            m[r][c] = 'O';
                        }

                       

                        if(m[r][c] == 'J')
                        {
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            turns += 2;
                            turnsInJail += 2;
                            money += 2 * (hotels * 10);
                           
                        }
                        
                        if (m[r][c] == 'S')
                        {
                            var currRow = r + 1;
                            var currCol = c + 1;
                        
                            int spentMoney = Math.Min((currCol) * (currRow), money);
                            money -= spentMoney;
                          
                            Console.WriteLine($"Spent {spentMoney} money at the shop.");
                        }

                        turns++;
                        money += 10*hotels;
                    } //end col for
                }

              
            } //end for
        
         
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }
    }
}
