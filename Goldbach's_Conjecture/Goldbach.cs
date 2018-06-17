using System;
using System.Collections.Generic;

namespace Goldbach_s_Conjecture
{

    class Goldbach
    {
        // Method time measurement in .Net:
        // https://stackoverflow.com/questions/14019510/calculate-the-execution-time-of-a-method
        static void Main(string[] args)
        {
            #region Receiving Input
            Console.WriteLine("Number of Test Cases(T): ");
            int T = int.Parse(Console.ReadLine());
            int[] testCases = new int[T];

            for (int i = 0; i < T; i++)
            {
                Console.WriteLine("TestCase"+i+":");
                testCases[i] = int.Parse(Console.ReadLine());
            }
            #endregion

            #region Goldbach's Conjecture testing
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // 10 tests
            int[][] answers = new int[10][];
            for (int i = 0; i < T; i++)
            {
                // each test migth have 3 numbers as an answer
                answers[i] = new int[3];
                Console.WriteLine("Primes before number " + testCases[i]);
                for (int j = 2; j < testCases[i]-1; j++)
                {
                    if (SixK.PrimalityTest(j))
                    {
                        Console.WriteLine(j);

                    }


                    // find the numbers
                        // if a new combination is found, 
                        // select the one that minimizes the total difference between the smallest and largest prime
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Execution time: " + elapsedMs + " MilliSeconds");
            #endregion
            


        }
    }

    /// <summary>
    /// Simple primality test using the 6k(+/-)1 optimization algorithm:
    /// https://en.wikipedia.org/wiki/Primality_test#Pseudocode
    /// </summary>
    class SixK
    {
        public static bool PrimalityTest(int number){
                if (number <= 1){
                    return false;
                }
                else if(number <= 3){
                    return false;
                }
                else if(number%2 == 0 || number%3 ==0){
                    return false;
                }
                int i = 5;
                while( i * i <= number ){
                    if(number%i == 0 || number%(i+2) == 0){
                        return false;
                    }
                    i = i + 6;
                }
                return true;
        }
    }
}
