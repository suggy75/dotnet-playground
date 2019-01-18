using System;
using System.Numerics;

namespace Trampoline
{
    /// <summary>
    /// Slightly optimized recursion, but can still get StackOverflowExceptions
    /// </summary>
    public class TailRecursion : IRecursor
    {
        private BigInteger Accumulate(BigInteger current, BigInteger n)
        {
            return n == 0 ? current : Accumulate(current * n, n - 1);
        }

        private BigInteger Factoral(BigInteger n)
        {
            return Accumulate(1, n);
        }

        public void Go(BigInteger n)
        {
            Console.WriteLine($"{Factoral(n)}");
        }
    }
}