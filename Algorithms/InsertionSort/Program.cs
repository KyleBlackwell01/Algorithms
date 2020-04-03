using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("unsorted_numbers.csv"))
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

                int n = testArr.Length, i, j, val, flag;
                Console.WriteLine("Insertion Sort, this may take awhile...");
                Console.WriteLine("Initial array is: ");
                //Displays current csv as an array
                for (i = 0; i < n; i++)
                {
                    Console.Write(testArr[i] + " ");
                }
                //Sorts initial csv array via insertionsort
                for (i = 1; i < n; i++)
                {
                    val = testArr[i];
                    flag = 0;
                    for (j = i - 1; j >= 0 && flag != 1;)
                    {
                        if (val < testArr[j])
                        {
                            testArr[j + 1] = testArr[j];
                            j--;
                            testArr[j + 1] = val;
                        }
                        else flag = 1;
                    }
                }



                //Insertion Sorting is slow, please don't use it.
                Console.WriteLine("\nSorted Array is, this will take a bit...");

                for(i=0; i < n; i++)
                {
                    Console.Write(testArr[i] + " ");

                    //SaveArrasCSV(testArr, @"D:\Coding\testArr2.csv");
                }

            }

            Console.WriteLine("End of Sort");
            Console.ReadKey();

        }

        //public static void SaveArrasCSV(Array arrToSave, string fileName)
        //{
        //    using (StreamWriter file = new StreamWriter(fileName))
        //    {
        //        WriteItemsToFile(arrToSave, file);
        //    }
        //}

        //private static void WriteItemsToFile(Array items, TextWriter file)
        //{
        //    foreach (object item in items)
        //    {
        //        if (item is Array)
        //        {
        //            WriteItemsToFile(item as Array, file);
        //            file.Write(Environment.NewLine);
        //        }
        //        else
        //        {
        //            file.Write(item + "\n");
        //        }
        //    }
        //}


    }
}
