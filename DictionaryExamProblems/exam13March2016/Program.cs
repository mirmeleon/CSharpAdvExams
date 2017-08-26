using System;
using System.Collections.Generic;
using System.Linq;

namespace exam13March2016
{
    class Program
    {
        static void Main()
        {
            var dic = new Dictionary<string, int>();
            var opponents = new Dictionary<string, SortedSet<string>>();

            var inp = Console.ReadLine();

            while (inp != "stop")
            {
                var tokens = inp.Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries);
                var team1 = tokens[0];
                var team2 = tokens[1];
                var firstMatchGols = tokens[2].Split(':');
                var secondMatchGoals = tokens[3].Split(':');
                var team1FirstMatchScore = int.Parse(firstMatchGols[0]);
                var team2FirstMatchScore = int.Parse(firstMatchGols[1]);
                var team1SecondMatchScore = int.Parse(secondMatchGoals[1]);
                var team2SecondMatchScore = int.Parse(secondMatchGoals[0]);
            
                var winner = "";
                var looser = "";

                var goalsTeam1 = team1FirstMatchScore + team1SecondMatchScore;
                var goalsTeam2 = team2FirstMatchScore + team2SecondMatchScore;
                if (goalsTeam1 > goalsTeam2)
                {
                    winner = team1;
                    looser = team2;
                } else if (goalsTeam2 > goalsTeam1)
                {
                    winner = team2;
                    looser = team1;
                }
                else
                {
                    if (team2FirstMatchScore > team1FirstMatchScore)
                    {
                        winner = team2;
                        looser = team1;
                    } else if (team1SecondMatchScore > team2SecondMatchScore)
                    {
                        winner = team1;
                        looser = team2;
                    }
                    else
                    {
                        if (team2FirstMatchScore < team2SecondMatchScore)
                        {
                            winner = team1;
                            looser = team2;
                        }
                        else
                        {
                            winner = team2;
                            looser = team1;
                        }
                       
                    }
                  
                }

                if (!dic.ContainsKey(winner) && winner != "")
                {
                    dic[winner] = 0;
                    opponents[winner] = new SortedSet<string>();
                }

                if (!dic.ContainsKey(looser))
                {
                    dic[looser] = 0;
                    opponents[looser] = new SortedSet<string>();
                }

                dic[winner]++;
                opponents[winner].Add(looser);
                opponents[looser].Add(winner);
                

               
                inp = Console.ReadLine();
            }

            foreach (var te in dic.OrderByDescending(t=>t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{te.Key}");
                Console.WriteLine($"- Wins: {te.Value}");
                Console.WriteLine($"- Opponents: {string.Join(", ", opponents[te.Key])}");
            }
        }

      
    }
}
