using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    public class Program
    {
        static void shellSort(int[] arr, int n)
        {
            int i, j, pos, temp;
            pos = 3;
            while(pos > 0)
            {
                for (i = 0; i < n; i++)
                {
                    j = i;
                    temp = arr[i];
                    while((j>=pos) && (arr[j - pos] > temp))
                    {
                        arr[j] = arr[j - pos];
                        j = j - pos;
                    }
                    arr[j] = temp;
                }

                if (pos / 2 != 0)
                {
                    pos = pos / 2;
                }
                else if (pos == 1)
                {
                    pos = 0;
                }
                else
                {
                    pos = 1;
                }
            }
        }

        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"D:\Coding\unsorted_numbers.csv"))
            {
                var testArr = reader.ReadToEnd()
                    .Split('\n')
                    .SelectMany(s => s.Split(',')
                        .Select(x => int.Parse(x)))
                    .ToArray<int>();

                foreach (var x in testArr)
                {
                    //placeholder
                }

                int n = testArr.Length;
                int i;
                Console.WriteLine("Shell sort");
                Console.WriteLine("Initial Array is: ");

                for(i=0; i < n; i++)
                {
                    Console.Write(testArr[i] + " ");
                }
                shellSort(testArr, n);
                Console.WriteLine("\nSorted Array is: ");
                for (i = 0; i < n; i++)
                {
                    Console.Write(testArr[i] + " ");
                    SaveArrasCSV(testArr, @"D:\Coding\testArrShell.csv");
                }

            }

            Console.WriteLine("End of sort");
            Console.ReadKey();
        }

        public static void SaveArrasCSV(Array arrToSave, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                WriteItemsToFile(arrToSave, file);
            }
        }

        private static void WriteItemsToFile(Array items, TextWriter file)
        {
            foreach (object item in items)
            {
                if (item is Array)
                {
                    WriteItemsToFile(item as Array, file);
                    file.Write(Environment.NewLine);
                }
                else
                {
                    file.Write(item + "\n");
                }
            }
        }
    }
}
