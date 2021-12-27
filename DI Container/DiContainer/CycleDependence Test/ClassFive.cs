using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.CycleDependence_Test
{
    class ClassFive : IClassFive
    {
        public ClassFive() { }

        public void Show()
        {
            Console.WriteLine("One");
        }
    }
}
