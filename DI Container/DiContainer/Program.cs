using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiContainer.Injector;
using DiContainer.CycleDependence_Test;

namespace DiContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton
            Console.WriteLine("Singleton");
            var servicesOne = new ServiceCollection();
            servicesOne.RegisterSingleton<IWordGenerator, WordGenerator>();

            var containerOne = servicesOne.GenerateContainer();

            var serviceOne = containerOne.GetService<IWordGenerator>();
            var serviceTwo = containerOne.GetService<IWordGenerator>();

            Console.WriteLine(serviceOne.RandomWord);
            Console.WriteLine(serviceTwo.RandomWord);
            Console.WriteLine();

            //Transient
            Console.WriteLine("Transient");
            var servicesTwo = new ServiceCollection();
            servicesTwo.RegisterTransient<IWordGenerator, WordGenerator>();

            var containerTwo = servicesTwo.GenerateContainer();

            serviceOne = containerTwo.GetService<IWordGenerator>();
            serviceTwo = containerTwo.GetService<IWordGenerator>();

            Console.WriteLine(serviceOne.RandomWord);
            Console.WriteLine(serviceTwo.RandomWord);
            Console.WriteLine();


            //Cycle Exeption
            Console.WriteLine("Check for cycle exeption");
            var servicesThree = new ServiceCollection();
            servicesThree.RegisterTransient<IClassOne, ClassOne>();
            servicesThree.RegisterTransient<IClassTwo, ClassTwo>();
            servicesThree.RegisterTransient<IClassThree, ClassThree>();
            servicesThree.RegisterTransient<IClassFour, ClassFour>();
            servicesThree.RegisterTransient<IClassFive, ClassFive>();

            var containerThree = servicesThree.GenerateContainer();

            try
            {
                var singletonTestFirst = containerThree.GetService<IClassOne>();
                Console.WriteLine("OK");
            }
            catch
            {
                Console.WriteLine("Cycle found");
            }
            
        }
    }
}
