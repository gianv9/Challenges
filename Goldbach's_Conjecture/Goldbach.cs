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
            long T = long.Parse(Console.ReadLine());
            long[] testCases = new long[T];
            //long highest = 0;
            for (long i = 0; i < T; i++)
            {
                Console.WriteLine("TestCase"+i+":");
                testCases[i] = long.Parse(Console.ReadLine());
                // if(testCases[i] > highest){
                //     highest = testCases[i];
                // }
            }
            #endregion

            #region set Generation
            // List<long> possiblePrimes = new List<long>();
            // highest = (long)(highest*0.55);
            //     for (long i = 2; i <= highest; i++)
            //     {
            //         if (SixK.PrimalityTest(i))
            //         {
            //             possiblePrimes.Add(i);
            //         }
            //     }

            // Console.WriteLine("Primes set size: "+possiblePrimes.Count);
            #endregion

            #region Goldbach's Conjecture testing
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //bool breakFlag = false;
            for (long i = 0; i < T; i++)
            {

                List<long> possiblePrimes = new List<long>();
                long limit = (long)(testCases[i]*0.55);
                    for (long x = 2; x <= limit; x++)
                    {
                        if (SixK.PrimalityTest(x))
                        {
                            possiblePrimes.Add(x);
                        }
                    }

                Console.WriteLine("Primes set size: "+possiblePrimes.Count);

                long[] result = new long[3]{0,0,0};
                for (long x = 0; x < possiblePrimes.Count && possiblePrimes[(int)x] < testCases[(int)i]; x++)
                {
                    for (long y = 0; y < possiblePrimes.Count && possiblePrimes[(int)y] < testCases[(int)i]; y++)
                    {
                        for (long j = 0; j < possiblePrimes.Count && possiblePrimes[(int)j] < testCases[(int)i]; j++)
                        {
                            //Console.WriteLine("x: "+possiblePrimes[x]+", y: "+possiblePrimes[y]+", j: "+possiblePrimes[j]);
                            if( (possiblePrimes[(int)x]+possiblePrimes[(int)y]+possiblePrimes[(int)j]) == testCases[(int)i] ){
                                long[] tempResult = new long[]{possiblePrimes[(int)x],possiblePrimes[(int)y],possiblePrimes[(int)j]};
                                //Console.WriteLine(testCases[(int)i] + " = " + possiblePrimes[(int)x] + " + " + possiblePrimes[(int)y] + " + " + possiblePrimes[(int)j] + "->" + Toolbox.LargestSmallestDiff(tempResult) );
                                
                                if(result[0] == 0){
                                    result = tempResult;
                                }
                                else if(Toolbox.LargestSmallestDiff(tempResult) < Toolbox.LargestSmallestDiff(result) ){
                                    result = tempResult;
                                }

                            }
                        }
                    }
                }

                Console.WriteLine(testCases[i] + " = " + result[0] + " + " + result[1] + " + " + result[2]);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Execution time: " + elapsedMs + " MilliSeconds");
            #endregion


/* 
            long worstCaseScenario = 1000000;
            long[] selected = new long[]{0,0,0};
            long counter = 0;
            for (long i = possiblePrimes.Count; i < 0 ; i--)
            {
                if(possiblePrimes[i] < worstCaseScenario){
                    long temp = possiblePrimes[i];
                    if(counter == 0){
                        selected[counter]=possiblePrimes[i];
                        counter++;
                    }
                    else if( temp + selected[counter-1] < worstCaseScenario && counter != 3){
                        selected[counter]=possiblePrimes[i];
                        counter++;
                    }
                    else{
                        if(selected[0] + selected[1] + selected[2] == worstCaseScenario){
                            Console.WriteLine(testCases[i] + " = " + selected[0] + " + " + selected[1] + " + " + selected[2]);
                        }
                        else
                        {
                            counter = 
                        }
                    }
                    

                }
            }*/
        }
    }

    class Toolbox
    {
        public static long LargestSmallestDiff(long[] arr){
            long largest = 0, smallest = arr[0];
            for (long i = 0; i < 3; i++)
            {
                if (arr[i] > largest){
                    largest = arr[i];
                }
                if(arr[i] < smallest){
                    smallest = arr[i];
                }
            }
            return (largest-smallest);
        }
    }

    /// <summary>
    /// Simple primality test using the 6k(+/-)1 optimization algorithm:
    /// https://en.wikipedia.org/wiki/Primality_test#Pseudocode
    /// </summary>
    class SixK
    {
        public static bool PrimalityTest(long number){
                if (number <= 1){
                    return false;
                }
                else if(number <= 3){
                    return true;
                }
                else if(number%2 == 0 || number%3 ==0){
                    return false;
                }
                long i = 5;
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
