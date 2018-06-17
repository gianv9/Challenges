using System;
using System.Collections.Generic;

namespace Goldbach_s_Conjecture
{
    class Goldbach
    {
        // MethodAccessException time measurement in .Net:
        // https://stackoverflow.com/questions/14019510/calculate-the-execution-time-of-a-method
        static void Main(string[] args)
        {
            List<int> primes = new List<int>();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                if(SixK.PrimalityTest(i)){
                    primes.Add(i);
                }   
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Execution time: " + elapsedMs + " MilliSeconds");
            Console.WriteLine(primes.Count + " primes found!");
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
