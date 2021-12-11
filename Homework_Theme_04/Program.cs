using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int tmp = 0;

            Console.WriteLine("Приветствуем в дополнительном задании по 4 уроку!");
            Console.WriteLine("1 - Задание 1   (Финансовое приложение)");
            Console.WriteLine("2 - Задание 2   (Треугольник Паскаля)");
            Console.WriteLine("3 - Задание 3.1 (Умножение матрицы на число)");
            Console.WriteLine("4 - Задание 3.2 (Сложение и вычитание матриц");
            Console.WriteLine("5 - Задание 3.3 (Умножение матриц)");

            tmp = int.Parse(Console.ReadLine());

            #region Task_1
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10

            if (tmp == 1)
            {
                // Инициализация двумерного массива
                int[,] arrayData = new int[12, 3]{
                                       { 100_000, 80_000,   20000 },    // 1
                                       { 120_000, 90_000,   30000 },    // 2
                                       { 80_000,  70_000,   10000 },    // 3
                                       { 70_000,  70_000,   0 },        // 4
                                       { 100_000, 80_000,   20000 },    // 5
                                       { 200_000, 120_000,  80000 },    // 6
                                       { 130_000, 140_000, -10000 },    // 7
                                       { 150_000, 65_000,   85000 },    // 8
                                       { 190_000, 90_000,   100000 },   // 9
                                       { 110_000, 70_000,   40000 },    // 10
                                       { 150_000, 120_000,  30000 },    // 11
                                       { 100_000, 80_000,   20000 }     // 12
                                      };

                string msg = "";
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Выбрано задание 1\n");
                    Console.WriteLine("Месяц  Доход, тыс. руб.  Расход, тыс. руб.  Прибыль, тыс. руб.");

                    for (int i = 0; i < 12; i++)
                    {
                        Console.WriteLine($"{i+1, 5} {arrayData[i, 0], 16}   {arrayData[i, 1],16}    {arrayData[i, 2],16}");   
                    }

                    Console.Write(msg);

                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Изменить приходы");
                    Console.WriteLine("2 - Изменить расходы");
                    Console.WriteLine("3 - Вывести худшие месяцы");
                    Console.WriteLine("4 - Вывести количество месяцев с положительной прибылью");
                    Console.WriteLine("0 - Выход");

                    tmp = int.Parse(Console.ReadLine());

                    if(tmp == 1)
                    {
                        for(int i = 0; i < 12; i++)
                        {
                            Console.Write($"Введите приход по месяцу {i + 1}: \n");
                            arrayData[i, 0] = int.Parse(Console.ReadLine());
                            // Сразу считаем прибыль
                            arrayData[i, 2] = arrayData[i, 0] - arrayData[i, 1];
                        }

                        msg = "\nПерезаполнена прибыль";
                    }
                    else if (tmp == 2)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            Console.Write($"Введите расход по месяцу {i + 1}: \n");
                            arrayData[i, 1] = int.Parse(Console.ReadLine());
                            // Сразу считаем прибыль
                            arrayData[i, 2] = arrayData[i, 0] - arrayData[i, 1];
                        }

                        msg = "\nПерезаполнен расход";
                    }
                    else if (tmp == 3)
                    {
                        int[] arrayBadMonth = new int[3];
                        int[] arrayProfit   = new int[12];

                        for (int i = 0; i < 12; i++)
                        {
                            arrayProfit[i] = arrayData[i, 2];
                        }

                        Array.Sort(arrayProfit);

                        // Определяем минимальные значения прибыли
                        int minE = int.MinValue;
                        int thisE = 0;
                        for (int i = 0; i < 12; i++)
                        {
                            if (minE < arrayProfit[i])
                            {
                                minE = arrayProfit[i];
                                arrayBadMonth[thisE] = minE;
                                thisE++;

                                if (thisE > arrayBadMonth.Length - 1) break; // Массив уже заполнен дальнейшая обработка не нужна
                            }
                        }

                        msg = "\nХудшая прибыль по месяцам:";
                        for(int i = 0; i < arrayBadMonth.Length; i++)
                        {
                            string str = "";
                            for(int j = 0; j < 12; j++)
                            {
                                if (arrayBadMonth[i] == arrayData[j, 2]) str = str + ", " + (j+1).ToString();
                            }

                            msg = msg + $"\nПрибыль {arrayBadMonth[i],15} в месяцах: " + str.Substring(2);
                          
                        }
                        msg = msg + "\n";

                    }
                    else if (tmp == 4)
                    {
                        int count = 0;
                        for(int i=0; i < 12; i++)
                        {
                            if (arrayData[i, 2] > 0) count++;
                        }

                        msg = $"\nМесяцев с положительной прибылью: {count}\n";
                    }
                    else if (tmp == 0)
                    {
                        break;
                    }
                }

            }

            #endregion

            #region Task_2
            // * Задание 2
            // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
            // 
            // При N = 9. Треугольник выглядит следующим образом:
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
            //                                                              
            //                                                              
            // Простое решение:                                                             
            // 1
            // 1       1
            // 1       2       1
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1
            // 
            // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля

            else if (tmp == 2)
            {
                int n = 9;

                Console.Clear();
                Console.Write("Введите N(<25): ");
                n = int.Parse(Console.ReadLine());

                if (n >= 25)
                {
                    Console.WriteLine("Введено неверное значение!");
                }
                else
                {

                    int[][] arrayPaskal = new int[n][];

                    arrayPaskal[0] = new int[1];
                    arrayPaskal[0][0] = 1;
                    arrayPaskal[1] = new int[2];
                    arrayPaskal[1][0] = 1;
                    arrayPaskal[1][1] = 1;

                    for (int i = 2; i < n; i++)
                    {

                        arrayPaskal[i] = new int[i + 1];
                        arrayPaskal[i][i] = 1;
                        arrayPaskal[i][0] = 1;
                        for (int j = 1; j < i; j++)
                        {
                            arrayPaskal[i][j] = arrayPaskal[i - 1][j] + arrayPaskal[i - 1][j - 1];
                        }

                    }

                    for (int i = 0; i < arrayPaskal.Length; i++)
                    {
                        for (int j = 0; j < arrayPaskal[i].Length; j++)
                        {
                            // Для красоты выводим в зависимости от n
                            if (n > 5 && n < 10) Console.Write($"{arrayPaskal[i][j],3}");
                            else if (n < 14) Console.Write($"{arrayPaskal[i][j],4}");
                            else if (n < 17) Console.Write($"{arrayPaskal[i][j],5}");
                            else if (n < 21) Console.Write($"{arrayPaskal[i][j],6}");
                            else if (n < 24) Console.Write($"{arrayPaskal[i][j],7}");
                            else Console.Write($"{arrayPaskal[i][j],8}");
                        }

                        Console.WriteLine();
                    }
                }

                Console.ReadKey();

            }

            

            #endregion

            #region Task_3_1
            // 
            // * Задание 3.1
            // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
            // Добавить возможность ввода количество строк и столцов матрицы и число,
            // на которое будет производиться умножение.
            // Матрицы заполняются автоматически. 
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //
            //      |  1  3  5  |   |  5  15  25  |
            //  5 х |  4  5  7  | = | 20  25  35  |
            //      |  5  3  1  |   | 25  15   5  |
            //
            //
            else if (tmp == 3)
            {

                Console.Clear();
                Console.WriteLine("Умножение матрицы на число");
                Console.Write("Введите количество строк: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок: ");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Введите число на которое необходимо умножить матрицу: ");
                int number = int.Parse(Console.ReadLine());

                Random rand = new Random();

                int[,] matrix = new int[n, m];
                int[,] matrixResult = new int[n, m];

                for(int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = rand.Next(9);
                        matrixResult[i, j] = matrix[i, j] * number;
                    }
                }

                Console.WriteLine("\nСгенерированая матрица:");
                for(int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for(int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j], 2} ");
                    }

                    Console.WriteLine("|");
                }

                Console.WriteLine($"\nМатрица умноженная на число {number}:");
                for (int i = 0; i < matrixResult.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrixResult.GetLength(1); j++)
                    {
                        Console.Write($"{matrixResult[i, j], 2} ");
                    }

                    Console.WriteLine("|");
                }

                Console.ReadKey();
            }

            #endregion

            #region Task_3_2
            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            //
            else if (tmp == 4)
            {
                Console.Clear();
                Console.WriteLine("Сложение(вычитание) матриц");
                Console.Write("Введите количество строк: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок: ");
                int m = int.Parse(Console.ReadLine());

                Random rand = new Random();

                int[,] matrix1 = new int[n, m];
                int[,] matrix2 = new int[n, m];
                int[,] matrixAdd = new int[n, m];
                int[,] matrixSub = new int[n, m];

                // Генерация 1 матрицы
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix1[i, j] = rand.Next(9);
                    }
                }

                // Вывод 1 матрицы
                Console.WriteLine("\nМатрица 1:");
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        Console.Write($"{matrix1[i, j],2} ");
                    }

                    Console.WriteLine("|");
                }

                // Генерация 2 матрицы
                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        matrix2[i, j] = rand.Next(9);
                    }
                }

                // Вывод 2 матрицы
                Console.WriteLine("\nМатрица 2:");
                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        Console.Write($"{matrix2[i, j],2} ");
                    }

                    Console.WriteLine("|");
                }

                // Высчитываем матрицу сложения и матрицу вычитания
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrixAdd[i, j] = matrix1[i, j] + matrix2[i, j];
                        matrixSub[i, j] = matrix1[i, j] - matrix2[i, j];
                    }

                }

                Console.WriteLine("\nМатрица1 + Матрица 2:");
                for (int i = 0; i < matrixAdd.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrixAdd.GetLength(1); j++)
                    {
                        Console.Write($"{matrixAdd[i, j],2} ");
                    }

                    Console.WriteLine("|");
                }

                Console.WriteLine("\nМатрица1 - Матрица 2:");
                for (int i = 0; i < matrixSub.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrixSub.GetLength(1); j++)
                    {
                        Console.Write($"{matrixSub[i, j],2} ");
                    }

                    Console.WriteLine("|");
                }

                Console.ReadKey();

            }

            #endregion

            #region Task_3_3
            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  
            //

            else if (tmp == 5)
            {
                Console.Clear();
                Console.WriteLine("Умножение матрицы на число\n");

                //Заполнение и вывод 1 матрицы
                Console.WriteLine("Матрица 1: ");
                Console.Write("Введите количество строк: ");
                int n1 = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок: ");
                int m1 = int.Parse(Console.ReadLine());

                Random rand = new Random();

                int[,] matrix1 = new int[n1, m1];

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix1[i, j] = rand.Next(9);

                        Console.Write($"{matrix1[i, j],2} ");
                    }

                    Console.WriteLine("|");
                }

                //Заполнение и вывод 2 матрицы
                Console.WriteLine("\nМатрица 2: ");
                Console.Write("Введите количество строк: ");
                int n2 = int.Parse(Console.ReadLine());
                Console.Write("Введите количество колонок: ");
                int m2 = int.Parse(Console.ReadLine());

                int[,] matrix2 = new int[n2, m2];

                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        matrix2[i, j] = rand.Next(9);

                        Console.Write($"{matrix2[i, j],2} ");
                    }

                    Console.WriteLine("|");
                }

                if(m1 != n2)
                {
                    Console.WriteLine($"\nКоличество колонок в таблице 1 ({m1}) не равно количеству строк в таблице 2 ({n2}).\nУмножение невозможно!");
                }
                else
                {
                    int[,] matrixRes = new int[n1, m2];

                    for(int i = 0; i < matrixRes.GetLength(0); i++)
                    {
                        for(int j = 0; j < matrixRes.GetLength(1); j++)
                        {

                            //matrixRes[i, j] = 0;
                            for(int k = 0; k < m1; k++)
                            {
                                matrixRes[i, j] = matrixRes[i, j] + matrix1[i, k] * matrix2[k, j];

                            }
                        }

                    }

                    Console.WriteLine("\nУмножение матриц:");
                    for (int i = 0; i < matrixRes.GetLength(0); i++)
                    {
                        Console.Write("| ");
                        for (int j = 0; j < matrixRes.GetLength(1); j++)
                        {

                            Console.Write($"{matrixRes[i, j],2} ");
                        }

                        Console.WriteLine("|");
                    }
                    
                }
                Console.ReadKey();
            }

            #endregion
        }
    }
}
