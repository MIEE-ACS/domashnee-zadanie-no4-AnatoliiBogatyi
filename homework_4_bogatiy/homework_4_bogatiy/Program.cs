using System;

namespace DZ4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            while (n < 0)
            {
                Console.WriteLine("Неверно введен размер массива, повторите ввод!");
                n = int.Parse(Console.ReadLine());
            }
            double[] array = new double[n];
            double SumOfPositiveElsem = InitArray(ref array);
            Console.WriteLine($"Сумма положительных элементов массива = {SumOfPositiveElsem:##.###}");
            double MultiplicationOfElem = Multiplication(ref array);
            Console.WriteLine($"Произведение элементов между максимальным и минимальным элементами массива = {MultiplicationOfElem: ##.###}.\n" +
                $"Если равно 1, то элементов между максимальным и минимальным элементами массива не существует.");
            Console.WriteLine("-------Массив--------");
            PrintArray(ref array);
            Sort(ref array);
            Console.WriteLine("-------Отсортированный Массив--------");
            PrintArray(ref array);


        }

        /// Забивает массив вещественными числами и возвращает сумму положительных элементов
        static double InitArray(ref double[] array)
        {
            int i = 0;
            var r = new Random();
            double SumOfPositiveElsem = 0;
            while (i != array.Length)
            {
                array[i] = r.NextDouble() * Math.Pow(-1, (r.Next(1, 3)));
                if (array[i] > 0)
                    SumOfPositiveElsem += array[i];
                i++;
            }
            return SumOfPositiveElsem;
        }

        /// Выводит массив на консоль
        static void PrintArray(ref double[] array)
        {
            int i = 0;
            while (i != array.Length)
            {
                Console.WriteLine(Math.Round(array[i++], 2) + "  ");
            }
        }

        /// Возвращает произведение элементов между максимальным и минимальным элементами массива
        static double Multiplication(ref double[] array)
        {
            double Multiplication = 1;
            double max = 0;
            double min = 1;
            int IndexOfMax = 0;
            int IndexOfMin = array.Length - 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    IndexOfMax = i;
                }
                if (array[i] < min)
                {
                    min = array[i];
                    IndexOfMin = i;
                }
            }
            if (IndexOfMax < IndexOfMin)
            {
                int temp = IndexOfMax;
                IndexOfMax = IndexOfMin;
                IndexOfMin = temp;
            }
            for (int i = IndexOfMin; i < IndexOfMax; i++)
                Multiplication *= array[i];
            return Multiplication;
        }

        /// Упорядовачивание элементов по убыванию
        static void Sort(ref double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        double temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
