using System;
using System.Diagnostics;
using Compulsory1PrimeFinderLogic;

namespace Compulsory1PrimeFinderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rangeStart = 1;
            var rangeEnd = 300_000;
            Console.WriteLine("Hello World!");

            var stopWatch = new Stopwatch();

            stopWatch.Start();
            new ParallelPrimeFinder().GetPrimesBetween(rangeStart, rangeEnd);
            stopWatch.Stop();
            Console.Write($"Time elapsed for Parallel: {stopWatch.ElapsedMilliseconds}ms, ");

            stopWatch.Reset();

            stopWatch.Start();
            new SeqPrimeFinder().GetPrimesBetween(rangeStart, rangeEnd);
            stopWatch.Stop();
            Console.WriteLine($"Time elapsed for Sequential: {stopWatch.ElapsedMilliseconds}ms");
        }
    }
}
