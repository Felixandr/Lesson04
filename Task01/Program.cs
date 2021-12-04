using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация переменных
            int colSize = 0;
            int strSize = 0;
            Random rand = new Random();

            Console.WriteLine("Случайная матрица\n\n");

            Console.Write("Введите количество строк: ");
            strSize = int.Parse(Console.ReadLine());

            Console.Write("Введите количество колонок: ");
            colSize = int.Parse(Console.ReadLine());

            int[,] array = new int[strSize, colSize];

            for(int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 10);
                    sum = sum + array[i, j];
                    Console.Write($"{array[i, j]} ");
                    
                }

                Console.WriteLine($" - {sum}");

            }

            Console.ReadKey();
        }
    }
}
