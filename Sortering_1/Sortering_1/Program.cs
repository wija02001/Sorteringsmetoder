using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listans längd:");
            int length = int.Parse(Console.ReadLine());
            int range = 10;
            int[] list = new int[length];
            Random random = new Random();
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = random.Next(range);
            }


            timer.Start();
            Bubblesort(list);
            timer.Stop();

            Console.WriteLine("Time elapsed: " + timer.ElapsedMilliseconds + " millisekunder");
        }

        private static void Bubblesort(int[] list)
        {
            for (int i = 1; i <= list.Length - 1; ++i)

                for (int j = 0; j < list.Length - i; ++j)

                    if (list[j] > list[j + 1])

                        Swap(ref list[j], ref list[j + 1]);
        }

        private static void Insertionsort(int[] list)
        {
            int n = list.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = key;
            }
        }

        private static void Selectionsort(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int min_index = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[min_index] > list[j])
                    {
                        min_index = j;
                    }
                    Swap(ref list[i], ref list[min_index]);
                }
            }
        }

        private static void Bogosort(int[] list)
        {
            bool sorted = true;
            do
            {
                Shuffle(list);
                sorted = true;
                int i = 0;
                while (i + 1 < list.Length)
                {
                    if (list[i] > list[i + 1])
                    {
                        sorted = false;
                        break;
                    }
                    i++;
                }
            } while (sorted == false);
        }

        private static void Internalsort(int[] list)
        {
            Array.Sort(list);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Shuffle(int[] list)
        {
            Random random = new Random();
            for (int i = 0; i + 1 < list.Length; i++)
            {
                Swap(ref list[i], ref list[random.Next(list.Length)]);
            }
        }
    }
}
