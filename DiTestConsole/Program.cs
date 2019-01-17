using System;
using DiServices;
using Unity;

namespace DiTestConsole
{
    class Program
    {
        private static IUnityContainer ConfigureContainer()
        {
            return new UnityContainer()
                .RegisterType<ICalculator, Calculator>()
                .RegisterType<IAdder, Adder>()
                .RegisterType<ISubtractor, Subtractor>();
        }

        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            var calculator = container.Resolve<ICalculator>();
            var a = 10;
            var b = 2;
            
            Console.WriteLine($"{a} + {b} = {calculator.Add(a, b)}");
            Console.WriteLine($"{a} - {b} = {calculator.Subtract(a, b)}");
        }
    }
}