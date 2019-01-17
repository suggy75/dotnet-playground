using System;

namespace DiServices
{
    public abstract class BaseCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
            Console.WriteLine("Add was called");
            return DoAdd(a, b);
        }

        public int Subtract(int a, int b)
        {
            throw new NotImplementedException();
        }

        public abstract int DoAdd(int a, int b);
    }



    public class Calculator : BaseCalculator
    {
        private readonly IAdder _adder;
        private readonly ISubtractor _subtractor;

        public Calculator(IAdder adder, ISubtractor subtractor)
        {
            _adder = adder ?? throw new ArgumentNullException(nameof(adder));
            _subtractor = subtractor ?? throw new ArgumentNullException(nameof(subtractor));
        }

        public virtual int Add(int a, int b) => _adder.Add(a, b);

        public int Subtract(int a, int b) => _subtractor.Subtract(a, b);

        public override int DoAdd(int a, int b) => _adder.Add(a, b);
    }

    public class LoggingCalculator : Calculator
    {
        public LoggingCalculator(IAdder adder, ISubtractor subtractor) : base(adder, subtractor)
        {
        }

        public override int Add(int a, int b)
        {
            Console.WriteLine("Add method was called");
            return base.Add(a, b);
        }
    }
}