using System;
using System.IO;
using ShellSort;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearch
{
    public class Program
    {

        static void Main(string[] args)
        {
            linearIndex(int.Parse(Console.ReadLine()));
            Console.ReadLine();

            Console.WriteLine("test");
            Console.ReadKey();
        }


        public static int linearIndex(int searchNumber)
        {


            using (var reader = new StreamReader(@"D:\Coding\unsorted_numbers.csv"))
            {

                int[] testArr = reader.ReadToEnd()
                    .Split('\n')
                    .SelectMany(s => s.Split(',')
                        .Select(x => int.Parse(x)))
                    .ToArray<int>();

                int n = testArr.Length;

                ShellSort.Program.shellSort(testArr, n);

                int index = 0;

            searchLine: if (searchNumber == testArr[index])
                {
                    Console.WriteLine("found at! : {0}", index);
                    return index;
                }

                index++;
                if (index < testArr.Length)
                {
                    goto searchLine;
                }
                else
                {
                    Console.WriteLine("Not found at any Index");
                }

                return 0;
            }        
        }






    }
}
