using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer
{
    public class ClassOne : IClassOne
    {
        public ClassOne(IClassTwo b) { }

        public void Show()
        {
            Console.WriteLine("One");
        }
    }
}
