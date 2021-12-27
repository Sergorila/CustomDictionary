using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.CycleDependence_Test
{
    public class ClassTwo : IClassTwo
    {
        public ClassTwo(IClassFour d) { }

        public void Show()
        {
            Console.WriteLine("Two");
        }
    }
}
