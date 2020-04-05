using System;
using System.IO;
using ShellSort;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LinearSearch
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Please enter a number to find.");
            linearIndex(int.Parse(Console.ReadLine()));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        public static int linearIndex(int searchNumber)
        {


            //Initializes the csv as an array
            using (var reader = new StreamReader("unsorted_numbers.csv"))
            {

                int[] testArr = reader.ReadToEnd()
                    .Split('\n')
                    .SelectMany(s => s.Split(',')
                        .Select(x => int.Parse(x)))
                    .ToArray<int>();

                int n = testArr.Length;


                //Referenced from ShellSort Project to sort in preparation for binary search
                ShellSort.Program.shellSort(testArr, n);



                int index = 0;
            searchLine: if (searchNumber == testArr[index])
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Console.WriteLine("Number was found at Index : {0}", index);
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;
                    Console.WriteLine("Total time: " + ts);
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
