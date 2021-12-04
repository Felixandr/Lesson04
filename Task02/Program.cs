using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            Console.WriteLine("Наименьший элемент в последовательности\n\n");

            Console.Write("Введите количество элементов: ");
            size = int.Parse(Console.ReadLine());

            int[] arr = new int[size];
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Введите {i} число: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int minNumber = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minNumber) minNumber = arr[i];
            }

            Console.WriteLine($"Минимальное число: {minNumber}");
            Console.ReadKey();
        }
    }
}
