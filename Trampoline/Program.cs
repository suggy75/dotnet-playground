using System;
using System.Diagnostics;

namespace Trampoline
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 26000;
            
            Console.WriteLine($"Started: Processing {n} times");
            var stopwatch = new Stopwatch();
            var bad = new BasicRecursion();
            var better = new TailRecursion();
            var best = new Trampoline();
            
            stopwatch.Start();
            bad.Go(n);
            stopwatch.Stop();
            Console.WriteLine($"Bad took {stopwatch.ElapsedMilliseconds} milliseconds");
            
            stopwatch.Reset();
            stopwatch.Start();
            better.Go(n);
            stopwatch.Stop();
            Console.WriteLine($"Better took {stopwatch.ElapsedMilliseconds} milliseconds");
            
            stopwatch.Reset();
            stopwatch.Start();
            best.Go(n);
            stopwatch.Stop();
            Console.WriteLine($"Best took {stopwatch.ElapsedMilliseconds} milliseconds");
            
            Console.WriteLine("Finished");
        }
    }
}