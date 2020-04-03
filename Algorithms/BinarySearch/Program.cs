using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShellSort;

namespace BinarySearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"D:\Coding\unsorted_numbers.csv"))
            {
                var testArr = reader.ReadToEnd()
                    .Split('\n')
                    .SelectMany(s => s.Split(',')
                        .Select(x => int.Parse(x)))
                    .ToArray<int>();

                int n = testArr.Length;

                ShellSort.Program.shellSort(testArr, n);

                PrintVals(testArr);

                SearchNumber(testArr, int.Parse(Console.ReadLine()));


                Console.WriteLine("Testing");
                Console.ReadKey();
            }
        }

        public static void SearchNumber(Array testArr, int Test)
        {
            int testIndex = Array.BinarySearch(testArr, Test);
            if(testIndex < 0)
            {
                Console.WriteLine("The number to search for ({0}) was not found. The next number is at index {1}.", Test, ~testIndex);
            }
            else
            {
                Console.WriteLine("The number to search for ({0}) is at index {1}.", Test, testIndex);
            }
        }

        public static void PrintVals(Array testArr)
        {
            int i = 0;
            int cols = testArr.GetLength(testArr.Rank - 1);
            foreach(object o in testArr)
            {
                if (i < cols)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("\t{0}", o);
            }
            Console.WriteLine();
        }

    }
}
