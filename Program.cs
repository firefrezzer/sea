using System;
using System.Collections.Generic;

namespace sea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number greater than 2: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 2)
            {
                List<int> primes = SieveOfEratosthenes(n);
                Console.WriteLine($"Prime numbers up to {n}:");
                Console.WriteLine(string.Join(", ", primes));
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer greater than 2.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static List<int> SieveOfEratosthenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
