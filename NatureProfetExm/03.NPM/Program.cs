using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NPM
{
    class Program
    {
        static void Main()
        {
         string input = Console.ReadLine();
           // string input = "Foxtrot";
            char charche = '\0';
            char nextCharche = '\0';
            StringBuilder sb = new StringBuilder();
         //   bool isAdded = true;

           
            while (input != "---NMS SEND---")
            {
                for (int i = 0; i < input.Length - 1; i++)
                {

                    if (i == 0)
                    {
                        if (char.ToLower(nextCharche) >= char.ToLower(input[0]))
                        {
                            sb.AppendLine();
                        }
                    }

                    charche = input[i];//a b a
                  
                    nextCharche = input[i + 1]; //b a d

                    if (char.ToLower(charche) <= char.ToLower(nextCharche))  //a b a d
                    {
                        sb.Append(charche);
                       // isAdded = true;
                    }
                    else
                    {
                       // if (isAdded)
                      //  {
                            sb.Append(charche);
                            sb.AppendLine();
                       // }

                    }

                } //end for

                if (input.Length - 2 <= nextCharche)
                {
                    sb.Append(nextCharche);
                }
                else
                {
                    sb.AppendLine();
                    sb.Append(nextCharche);
                }

                input = Console.ReadLine();
            } //end while

            

           
            string razdelitel = Console.ReadLine();
            sb.Replace("\r\n", razdelitel);

            Console.WriteLine(sb);
        } 



      

    }
}
