using System;

namespace DZ4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размеры матрицы: ");
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            while (rows < 0 || cols < 0)
            {
                Console.WriteLine("Неверно введены размеры матрицы, повторите ввод!");
                rows = int.Parse(Console.ReadLine());
                cols = int.Parse(Console.ReadLine());
            }
            int[,] array = new int[rows, cols];
            int counterForCol = InitArray(ref array);
            Console.WriteLine($"Количество столбцов, не содержащих ни одного нулевого элемента = {counterForCol}");
            Console.WriteLine("-------Матрица--------");
            PrintArray(ref array);
            Sort(ref array);
            Console.WriteLine("-------Отсортированный Массив--------");
            PrintArray(ref array);
        }

        /// Забивает массив вещественными числами и возвращает количество столбцов, не содержащих ни одного нулевого элемента
        static int InitArray(ref int[,] array)
        {
            int counter = 0;
            bool indicator = true;
            var r = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                indicator = true;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(-10, 11);
                    if (!indicator && array[i, j] == 0)
                        indicator = false;
                }
                if (indicator) counter++;
            }
            return counter;
        }

        /// Выводит матрицу на консоль
        static void PrintArray(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        /// Сортировка матрицы
        static void Sort(ref int[,] array)
        {
            int[] arOfCharacter = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                arOfCharacter[i] = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % 2 == 0 && array[i, j] > 0)
                        arOfCharacter[i]++;
                }
            }
            for (int k = 0; k < array.GetLength(0); k++)
            {
                for (int i = 0; i < array.GetLength(0) - 1; i++)
                {
                    if (arOfCharacter[i] > arOfCharacter[i + 1])
                    {
                        int temp = 0;
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            temp = array[i, j];
                            array[i, j] = array[i + 1, j];
                            array[i + 1, j] = temp;
                        }
                        temp = arOfCharacter[i];
                        arOfCharacter[i] = arOfCharacter[i + 1];
                        arOfCharacter[i + 1] = temp;
                    }
                }
            }
        }
    }
}
