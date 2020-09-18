using System;
using System.Collections.Generic;

namespace Compulsory1PrimeFinderLogic
{
    public class SeqPrimeFinder
    {
        public List<int> GetPrimesBetween(int start, int end)
        {
            List<int> primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        private bool IsPrime(int num)
        {
            if (num == 2)
            {
                return true;
            }
            else if (num == 1)
            {
                return false;
            }
            else if (num % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
