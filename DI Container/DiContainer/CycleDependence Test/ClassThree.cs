using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.CycleDependence_Test
{
    class ClassThree : IClassThree
    {
        public ClassThree(IClassFive e) { }

        public void Show()
        {
            Console.WriteLine("Three");
        }
    }
}
