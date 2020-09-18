using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compulsory1PrimeFinderLogic
{
    public class ParallelPrimeFinder
    {
        public List<int> GetPrimesBetween(int start, int end)
        {
            Object lockObj = new Object();
            List<List<int>> parallelResults = new List<List<int>>();
            Parallel.ForEach(Partitioner.Create(start, end + 1),
                (range) =>
                {
                    List<int> primes = new List<int>();

                    for (int i = range.Item1; i < range.Item2; i++)
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

            List<int> primes = new List<int>();
            foreach (var item in parallelResults.Where(x => x.Count > 0).OrderBy(x => x[0]))
            {
                primes.AddRange(item);
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
