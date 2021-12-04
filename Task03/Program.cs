using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int tmpNumber = 0;
            int Number = 0;
            int count = 1;
            Random rand = new Random();

            Console.WriteLine("Игра Угадай число\n\n");

            Console.Write("Введите максимальное число: ");
            tmpNumber = int.Parse(Console.ReadLine());
            Number = rand.Next(0, tmpNumber);

            Console.WriteLine($"\nЯ загадал число от 0 до {tmpNumber}. Давай играть! ");

            while (true)
            {
                Console.Write("Введите число: ");
                tmpNumber = int.Parse(Console.ReadLine());

                if(tmpNumber < Number) Console.WriteLine("Жаль. Это число меньше моего!");
                else if(tmpNumber > Number) Console.WriteLine("Немного больше чем надо. Попробуй еще раз!");
                else
                {
                    Console.WriteLine($"Абсолютно верно! Попыток: {count}");
                    break;
                }

                count++;
            }
            Console.ReadKey();
        }
    }
}
