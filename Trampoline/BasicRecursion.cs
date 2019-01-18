using System;
using System.Numerics;

namespace Trampoline
{
    /// <summary>
    /// Inefficient way of doing recursion, which can lead to StackOverflowExceptions
    /// </summary>
    public class BasicRecursion : IRecursor
    {
        private BigInteger Factoral(BigInteger n)
        {
            return n == 0 ? 1 : n * Factoral(n - 1);
        }

        public void Go(BigInteger n)
        {
            Factoral(n);
        }
    }
}