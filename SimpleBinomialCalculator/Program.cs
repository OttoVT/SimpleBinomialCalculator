using System;
using System.Numerics;

namespace SimpleBinomialCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamicArr[0] = 1;
            double probability = 0;

            Console.Write("Enter n: ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("Enter k: ");
            var k = int.Parse(Console.ReadLine());
            Console.Write("Enter p: ");
            var p = double.Parse(Console.ReadLine());
            Console.Write("Enter start of the range: ");
            var start = int.Parse(Console.ReadLine());
            Console.Write("Enter end of the range: ");
            var end = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                probability += CalculateBinomialRandomValue(15, i, 0.45);
            }

            Console.WriteLine("Probability: " + probability);
            Console.WriteLine("Reversed probability: " + (1 - probability));
        }

        private static double CalculateBinomialRandomValue(int n, int k, double p)
        {
            var calculated = (double)((decimal)Factorial(n) / (decimal)(Factorial(k) * Factorial(n - k)));
            var binomial = calculated * Math.Pow(p, (double)k) * Math.Pow(1 - p, (double)n - k);

            return binomial;
        }

        private static readonly int _lastCached = 0;
        private static readonly BigInteger[] dynamicArr = new BigInteger[100];
        private static BigInteger Factorial(int n)
        {
            var cached = dynamicArr[n];
            if (cached != 0)
                return cached;

            var temp = dynamicArr[_lastCached];
            for (int i = _lastCached + 1; i <= n; i++)
            {
                temp *= i;
                dynamicArr[i] = temp;
            }

            return dynamicArr[n];
        }
    }
}
