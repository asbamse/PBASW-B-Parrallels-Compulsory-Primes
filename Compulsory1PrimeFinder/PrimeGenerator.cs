using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compulsory1PrimeFinderLogic
{
    public class PrimeGenerator
    {
        public List<long> GetPrimesSequential(long first, long last)
        {
            List<long> primes = new List<long>();

            for (long i = first; i <= last; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public List<long> GetPrimesParallel(long first, long last)
        {
            Object lockObj = new Object();
            List<List<long>> parallelResults = new List<List<long>>();
            Parallel.ForEach(Partitioner.Create(first, last + 1),
                (range) =>
                {
                    List<long> primes = new List<long>();

                    for (long i = range.Item1; i < range.Item2; i++)
                    {
                        if (IsPrime(i))
                        {
                            primes.Add(i);
                        }
                    }

                    lock (lockObj)
                    {
                        parallelResults.Add(primes);
                    }
                });

            List<long> primes = new List<long>();
            foreach (var item in parallelResults.Where(x => x.Count > 0).OrderBy(x => x[0]))
            {
                primes.AddRange(item);
            }
            return primes;
        }

        private bool IsPrime(long num)
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

            for (long i = 3; i <= Math.Sqrt(num); i += 2)
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
