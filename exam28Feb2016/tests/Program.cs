using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    class Program
    {
        static void Main()
        {
            var dic = new Dictionary<string, int>();
            var resName = "deni";
            bool isValidResourse = true;
           // dic.Add("deni", 23);

            if (isValidResourse && !dic.ContainsKey(resName))
            {
                Console.WriteLine("vlezna");
            }

            if (dic.ContainsKey(resName) && isValidResourse)
            {
                Console.WriteLine("vlezna 2");
            }


        }
    }
}
