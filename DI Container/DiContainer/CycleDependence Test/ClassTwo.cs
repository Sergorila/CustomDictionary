using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer
{
    public class ClassTwo : IClassTwo
    {
        public ClassTwo(IClassOne a) { }

        public void Show()
        {
            Console.WriteLine("Two");
        }
    }
}
