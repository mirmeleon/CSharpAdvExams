using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        
        Stack<int> flowers = new Stack<int>(Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray()
            .Reverse());
        var inpKofa = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Stack<int> bucket = new Stack<int>(inpKofa);

        Queue<int> secondNatureFlowers = new Queue<int>();
        
        int reminder = 0;

        int currentFlower = 0;
        int currWater = 0;
        


        while (flowers.Count > 0 && bucket.Count > 0)
        {
            currentFlower = flowers.Pop();


            while (bucket.Count > 0 && (currentFlower - bucket.Peek()) > 0)
            
                //polivame dokat ima kofi
                currentFlower -= bucket.Pop();
            
            //remi ako sa ostanali oshte kofi
            if (bucket.Count > 0)
            {
                //proveriavame dali prepolivame
                if (currentFlower - bucket.Peek() < 0)
                {
                    reminder = bucket.Pop() - currentFlower;

                }
                else
                {
                    secondNatureFlowers.Enqueue(currentFlower);
                    bucket.Pop();
                }

                currentFlower = -1; //za da ne ostane polojitelno zarad dolnata proverka

                if (bucket.Count > 0)
                {
                    bucket.Push(bucket.Pop() + reminder); 
                }
                else if (reminder > 0)
                {
                    bucket.Push(reminder);
                }
            } //end if

            if (currentFlower > 0)
                {
                    flowers.Push(currentFlower);
                }
           
        }
        
        
        
        //print
        if (flowers.Count > 0)
        {
            Console.WriteLine(string.Join(" ", flowers));
         }

        if (bucket.Count > 0)
        {
            Console.WriteLine(string.Join(" ", bucket));
        }

        if (secondNatureFlowers.Count > 0)
        {
            Console.WriteLine(string.Join(" ", secondNatureFlowers));
        }
        else
        {
            Console.WriteLine("None");
        }
    }

}  

   

