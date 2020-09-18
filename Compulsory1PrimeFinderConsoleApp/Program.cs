using System;
using Compulsory1PrimeFinder;

namespace Compulsory1PrimeFinderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var primeNumbers = new SeqPrimeFinder().GetPrimesBetween(1, 10_000_000);
            Console.WriteLine("Primes");
            var primesString = string.Join(", ", primeNumbers);
            Console.WriteLine(primesString);
        }
    }
}
