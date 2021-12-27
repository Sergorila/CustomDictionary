using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.CycleDependence_Test
{
    class ClassFour : IClassFour
    {
        public ClassFour(IClassFive e) { }

        public void Show()
        {
            Console.WriteLine("Four");
        }
    }
}
