using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication46
{
    class RadixSorting
    {
        public static void sorting(ref int[] arr, int range, int length, out int comparisons, out int moves) //Поразрядная сортировка
        {
            moves = comparisons = 0;
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();

            for (int step = 0; step < length; ++step)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; ++i)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                                                  (int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        moves++;
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }
        }
    }
    class Vibor
    {
        public static void ViborSort(ref int[] mas, out int comparisons, out int moves)
        {
            moves = comparisons = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    comparisons++;
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mas[min];
                moves++;
                mas[min] = mas[i];
                moves++;
                mas[i] = temp;
            }

        }
    }
    class Test
    {
        static void Try(out int inputnumber)//проверка правильности ввода числа
        {
            inputnumber = 0;
            bool flag = true;
            while (flag == true)
            {
                try
                {

                    string x = Console.ReadLine();
                    inputnumber = int.Parse(x);
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("Неверное значение! Введите целое число");
                    flag = true;
                }
            }
        }
        static void Main(string[] args)
        {
            string answer = "yes";

            while (answer == "yes")
            {


                Console.WriteLine("Введите количество элементов массива");
                int n;
                bool f1 = true;
                Try(out n);
                while (f1 && n < 0)
                {
                    Console.WriteLine("Неверное значение! Введите положительное число");
                    Try(out n);
                    if (n >= 0)
                    {
                        f1 = false;
                    }
                }
                if (n == 0)
                {
                    Console.WriteLine("Массив пуст");
                }
                else
                {
                    int comparisons, moves;
                    int[] arr = new int[n];
                    int[] arr1 = new int[n];
                    int[] arr2 = new int[n];
                    int[] arr3 = new int[n];
                    int[] arr4 = new int[n];
                    int[] arr5 = new int[n];
                    //fill the array with random numbers
                    Random rd = new Random();
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        arr[i] = rd.Next(0, 100);
                        arr1[i] = rd.Next(0, 100);
                        arr2[i] = rd.Next(0, 100);
                        arr3[i] = arr[i];
                        arr4[i] = arr1[i];
                        arr5[i] = arr2[i];
                    }
                    Array.Sort(arr1);
                    Array.Sort(arr2);
                    Array.Reverse(arr2);


                    Console.WriteLine("\nНеупорядоченный массив:");
                    foreach (double x in arr)
                    {
                        System.Console.Write(x + " ");
                    }

                    Console.WriteLine("\nМассив, упорядоченный по возрастанию:");
                    foreach (double x in arr1)
                    {
                        System.Console.Write(x + " ");
                    }

                    Console.WriteLine("\nМассив, упорядоченный по убыванию:");
                    foreach (double x in arr2)
                    {
                        System.Console.Write(x + " ");
                    }
                    #region
                    Console.WriteLine();
                    Console.WriteLine("\nПоразрядная сортировка");
                    RadixSorting.sorting(ref arr, 10, 2, out comparisons, out moves);
                    System.Console.WriteLine("\nНеупорядоченный массив после сортировки:");
                    foreach (double x in arr)
                    {
                        System.Console.Write(x + " ");
                    }
                    Console.WriteLine($"\nКоличество сравнений: {comparisons}, количество перемещений: {moves}");
                    RadixSorting.sorting(ref arr1, 10, 2, out comparisons, out moves);
                    System.Console.WriteLine("\nУпорядоченный по возрастанию массив после сортировки:");
                    foreach (double x in arr1)
                    {
                        System.Console.Write(x + " ");
                    }
                    Console.WriteLine($"\nКоличество сравнений: {comparisons}, количество перемещений: {moves}");
                    RadixSorting.sorting(ref arr2, 10, 2, out comparisons, out moves);
                    System.Console.WriteLine("\nУпорядоченный по убыванию массив после сортировки:");
                    foreach (double x in arr2)
                    {
                        System.Console.Write(x + " ");
                    }
                    Console.WriteLine($"\nКоличество сравнений: {comparisons}, количество перемещений: {moves}");
                    #endregion
                    #region
                    Console.WriteLine();
                    Console.WriteLine("\nСортировка простым выбором");
                    Vibor.ViborSort(ref arr3, out comparisons, out moves);
                    System.Console.WriteLine("\nНеупорядоченный массив после сортировки:");
                    foreach (double x in arr3)
                    {
                        System.Console.Write(x + " ");
                    }
                    Console.WriteLine($"\nКоличество сравнений: {comparisons}, количество перемещений: {moves}");
                    Vibor.ViborSort(ref arr4, out comparisons, out moves);
                    System.Console.WriteLine("\nУпорядоченный по возрастанию массив после сортировки:");
                    foreach (double x in arr4)
                    {
                        System.Console.Write(x + " ");
                    }
                    Console.WriteLine($"\nКоличество сравнений: {comparisons}, количество перемещений: {moves}");
                    Vibor.ViborSort(ref arr5, out comparisons, out moves);
                    System.Console.WriteLine("\nУпорядоченный по убыванию массив после сортировки:");
                    foreach (double x in arr5)
                    {
                        System.Console.Write(x + " ");
                    }
                    Console.WriteLine($"\nКоличество сравнений: {comparisons}, количество перемещений: {moves}");
                    #endregion
                }
                Console.WriteLine("Продолжить? yes/no");
                answer = Console.ReadLine();

            }

        }
    }
}

