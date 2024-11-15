﻿namespace Tests
{
    internal class Program
    {
        static void Main()
        {

            Console.Write("Решение на задачу №1 - \n");
            Task1();
            Console.Write("\nРешение на задачу №2 - \n");
            Task2();
            Console.Write("\nРешение на задачу №3 - \n");
            Task3();
            Console.Write("\nРешение на задачу №4 - \n");
            Task4();
            Console.Write("\n\nРешение на задачу №5 - \n");
            Task5();
            Console.Write("\n\nРешение на задачу №6 - \n");
            Task6();
            Console.Write("\nРешение на задачу №7 - \n");
            Task7();
            Console.Write("\n\nРешение на задачу №8 - \n");
            Task8();
            Console.Write("\n\nРешение на задачу №9 - \n");
            Task9();
            Console.Write("\n\nРешение на задачу №10 - \n");
            Task10();
            Console.Write("\n\nРешение на задачу №11 - \n");
            Task11();
            Console.Write("\n\nРешение на задачу №12 - \n");
            Task12();
        }

        /// <summary>
        /// Найти минимальный элемент массива
        /// </summary>
        public static void Task1()
        {
            int[] a = new int[] { 5, 12, 13, 2, 1, 9, 15, 19, 6 };
            int min = int.MaxValue;
            Console.WriteLine("Наш массив: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            Console.WriteLine("\nМинимальное число = " + min);
        }

        /// <summary>
        /// Найти два наибольших элемента массива
        /// </summary>
        public static void Task2()
        {
            int[] a = new int[] { 1, 200, 13, 2, 1, 9, 15, 19, 6000 };
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            Console.WriteLine("Наш массив: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max1)
                {
                    max1 = a[i];
                }

            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max2 && a[i] != max1)
                {
                    max2 = a[i];
                }
            }
            Console.WriteLine("\nПервое максимальное число = " + max1 + "\nВторое максимальное число = " + max2);
        }

        /// <summary>
        /// Посчитать сумму элементов массива
        /// </summary>
        public static void Task3()
        {
            int[] a = new int[] { 5, 12, 13, 2, 1, 9, 15, 19, 6 };
            int sum = 0;

            Console.WriteLine("Наш массив: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }

            foreach (int i in a)
            {
                sum += i;
            }
            Console.WriteLine("\nСумма всех элементов массива = " + sum);
        }

        /// <summary>
        /// Заполнить массив по возрастанию от 1 до 100
        /// </summary>
        public static void Task4()
        {
            int[] a = new int[100];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ++i;
                --i;
                Console.Write(a[i] + " ");
            }
        }

        /// <summary>
        /// Создать и заполнить массив случайными целыми числами
        /// </summary>
        public static void Task5()
        {
            //пример вызова генератора случайных чисел, он понадобится в данной задаче
            Random rnd = new Random();
            int r = rnd.Next(1, 10);//случайное число от 1 до 10

            int[] array = new int[10];

            foreach (int i in array)
            {
                array[i] = rnd.Next(10, 100);
                Console.Write(array[i] + " ");
            }
        }

        /// <summary>
        /// Проверить, что в массиве нет одинаковых чисел
        /// </summary>
        public static void Task6()
        {
            int[] a = new int[] { 5, 12, 13, 2, 1, 9, 15, 19, 6 };

            bool b = true;

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == a[j])
                    {
                        Console.WriteLine("Найдены одинаковые числа");
                        b = false;
                        break;
                    }
                }
            }
            if (b)
            {
                Console.WriteLine("Одинаковых чисел не найдено");
            }

        }

        /// <summary>
        /// Переставить элементы массива в обратном порядке используя вспомогательный массив
        /// </summary>
        public static void Task7()
        {
            int[] a = new int[] { 5, 12, 13, 2, 1, 9, 15, 19, 6 };

            int[] b = new int[a.Length];
            Console.WriteLine("Начальный массив: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nПеревернутый массив: ");
            for (int i = a.Length - 1; i >= 0; i--) 
            {
                b[i] = a[i];
                Console.Write(b[i] + " ");
            }
        }

        /// <summary>
        /// Переставить элементы массива в обратном порядке НЕ используя вспомогательный массив
        /// </summary>
        public static void Task8()
        {
            int[] a = new int[] { 5, 12, 13, 2, 1, 9, 15, 19, 6 };
            Console.WriteLine("Начальный массив: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Array.Reverse(a);            
            Console.WriteLine("\nПеревернутый массив: ");
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// Подсчитать сумму чисел в двухмерном массиве
        /// </summary>
        public static void Task9()
        {
            int[,] m = new int[,] { { 11, 22, 31 }, { 4, 53, 6 }, { 7, 81, 90 } };
            int sum = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    sum += m[i, j];
                }
            }
            Console.WriteLine("Сумма всех чиcел массива = " + sum);
        }

        /// <summary>
        /// Заполнить двумерный массив 10 на 10 случайными числами от 1 до 9 и вывести на экран консоли
        /// </summary>
        public static void Task10()
        {
            Random random = new Random();
            int[,] array = new int[10, 10];
            Console.WriteLine("Наш массив с рандомными числами: ");
            for (int i = 0; i< array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(1, 10);
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Двумерный массив скопировать в одномерный
        /// </summary>
        public static void Task11()
        {
            int[,] m = new int[,] { { 11, 22, 31 }, { 4, 53, 6 }, { 7, 81, 90 } };            
            int[] f = new int[m.Length];
            int k = 0;

            Console.WriteLine("Наш двумерный массив: ");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    f[k] = m[i, j];
                    k++;
                    Console.Write(m[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("С копируемый одномерный массив: ");
            foreach (int i in f)
            {
                Console.Write(i + " ");
            }
        }


        /// <summary>
        /// Заполнить двумерный массив 10 на 10 случайными числами от 1 до 99 и определить количество четных чисел в массиве
        /// </summary>
        public static void Task12()
        {
            //подсказка: для определения остатка от деления используется оператор %
            int ostatok = 4 % 2; //будет равен нулю
            int evenNumbers = 0;
            Random random = new Random();
            int[,] array = new int[10, 10];


            Console.WriteLine("Наш массив с рандомными числами: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(1, 99);
                    Console.Write(array[i, j] + " ");
                    if (array[i, j] % 2 == 0)
                    {
                        evenNumbers++;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Кол-во четных чисел = " + evenNumbers);
        }
    }
}