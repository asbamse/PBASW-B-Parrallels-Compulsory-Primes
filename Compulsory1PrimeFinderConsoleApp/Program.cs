using System;
using System.Diagnostics;
using Compulsory1PrimeFinderLogic;

namespace Compulsory1PrimeFinderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var stopWatch = Stopwatch.StartNew();
            var primeNumbers = new ParallelPrimeFinder().GetPrimesBetween(1, 10_000_000);
            stopWatch.Stop();
            Console.WriteLine($"Time elapsed: {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("Primes");
            var primesString = string.Join(", ", primeNumbers);
            //Console.WriteLine(primesString);
        }
    }
}
