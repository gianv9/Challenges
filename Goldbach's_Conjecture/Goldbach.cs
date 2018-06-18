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

            #region set Generation
            List<int> possiblePrimes = new List<int>();
                for (int i = 2; i <= 100000; i++)
                {
                    if (SixK.PrimalityTest(i))
                    {
                        possiblePrimes.Add(i);
                    }
                }

            Console.WriteLine("Primes set size: "+possiblePrimes.Count);
            #endregion

            #region Goldbach's Conjecture testing
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //bool breakFlag = false;
            for (int i = 0; i < T; i++)
            {
                int[] result = new int[3]{0,0,0};
                for (int x = 0; x < possiblePrimes.Count && possiblePrimes[x] < testCases[i]; x++)
                {
                    for (int y = 0; y < possiblePrimes.Count && possiblePrimes[y] < testCases[i]; y++)
                    {
                        for (int j = 0; j < possiblePrimes.Count && possiblePrimes[j] < testCases[i]; j++)
                        {
                            //Console.WriteLine("x: "+possiblePrimes[x]+", y: "+possiblePrimes[y]+", j: "+possiblePrimes[j]);
                            if( (possiblePrimes[x]+possiblePrimes[y]+possiblePrimes[j]) == testCases[i] ){
                                int[] tempResult = new int[]{possiblePrimes[x],possiblePrimes[y],possiblePrimes[j]};
                                //Console.WriteLine(testCases[i] + " = " + possiblePrimes[x] + " + " + possiblePrimes[y] + " + " + possiblePrimes[j] + "->" + Toolbox.LargestSmallestDiff(tempResult) );
                                
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
            int worstCaseScenario = 1000000;
            int[] selected = new int[]{0,0,0};
            int counter = 0;
            for (int i = possiblePrimes.Count; i < 0 ; i--)
            {
                if(possiblePrimes[i] < worstCaseScenario){
                    int temp = possiblePrimes[i];
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
        public static int LargestSmallestDiff(int[] arr){
            int largest = 0, smallest = arr[0];
            for (int i = 0; i < 3; i++)
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
        public static bool PrimalityTest(int number){
                if (number <= 1){
                    return false;
                }
                else if(number <= 3){
                    return true;
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
