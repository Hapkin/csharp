using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static int minSum = 10000;

        static void Main(string[] args)
        {
            int[] numArr = new int[] { 50, 60, 30, 45 };
            const int baseLine = 100;

            DoKnapsack(numArr, baseLine);
        }

        private static void DoKnapsack(int[] numArr, int baseLine)
        {
            List<int> resultCombination = new List<int>();

            // The stage variable decides the number quantity within a combination, begin with 2.
            for (int stage = 2; stage <= numArr.Length; stage++)
            {
                foreach (IEnumerable<int> currentCombination in Combinations(numArr, stage))
                {
                    Console.WriteLine("Combination: " + string.Join(",", currentCombination.ToArray()) + "\tThe sum total:" + currentCombination.Sum());

                    if (currentCombination.Sum() >= 100 && currentCombination.Sum() < minSum)
                    {
                        resultCombination = currentCombination.ToList<int>();
                        minSum = currentCombination.Sum();
                    }
                }
            }

            PrintResult(resultCombination);
        }

        private static void PrintResult(List<int> resultCombination)
        {
            Console.WriteLine(Environment.NewLine +
                "The closest result is: " + string.Join(",", resultCombination) +
                Environment.NewLine +
                "And the lowest sum total:" + minSum);
        }

        // Get all the possible combinations about a number quantity k out of the target number collection.
        static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
        {
            T[] elem = elements.ToArray();
            int size = elem.Length;

            if (k <= size)
            {
                int[] numbers = new int[k];
                for (int i = 0; i < k; i++)
                {
                    numbers[i] = i;
                }

                do
                {
                    yield return numbers.Select(n => elem[n]);
                }
                while (nextCombination(numbers, size, k));
            }
        }

        // A sub method called by the Combinations<T> method.
        static bool nextCombination(int[] num, int n, int k)
        {
            bool finished, changed;

            changed = finished = false;

            if (k > 0)
            {
                for (int i = k - 1; !finished && !changed; i--)
                {
                    if (num[i] < (n - 1) - (k - 1) + i)
                    {
                        num[i]++;
                        if (i < k - 1)
                        {
                            for (int j = i + 1; j < k; j++)
                            {
                                num[j] = num[j - 1] + 1;
                            }
                        }
                        changed = true;
                    }
                    finished = (i == 0);
                }
            }

            return changed;
        }
    }
}
