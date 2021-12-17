using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDictionary<string, int> myDict = new CustomDictionary<string, int>(6);
            Console.WriteLine(myDict.Size);

            myDict["Odin"] = 1;
            myDict.Add("Dva", 2);
            myDict.Add("Tri", 3);

            foreach (var item in myDict)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            Console.WriteLine();

            foreach (var item in myDict)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            Console.WriteLine();

            myDict.Remove("Tri");
            myDict["Dva"] = 42121;
            foreach (var item in myDict)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

        }
    }
}
