using System;

namespace Balloon_Mess
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Testcases: ");
            int T = int.Parse(Console.ReadLine());
            int[][] input = new int[T][];
            for (int i = 0; i < T; i++)
            {
                string str = Console.ReadLine();
                Console.WriteLine("\n"+str+"\n");
                // source: https://stackoverflow.com/questions/3665757/how-to-convert-char-to-int
                input[i] = new int[]{(int)Char.GetNumericValue(str[0]),(int)Char.GetNumericValue(str[2])};
            }

            for (int i = 0; i < T; i++)
            {
                Console.WriteLine(input[i][0]);
            Console.WriteLine("Answer i="+(i+1)+": " + ((input[i][0])+1) );
            }
            
        }
    }
}
