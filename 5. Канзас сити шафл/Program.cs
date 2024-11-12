namespace _5._Канзас_сити_шафл
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Оригинальный массив: ");
            PrintArray(array);

            Random.Shared.Shuffle(array);

            Console.WriteLine("Перемешанный массив: ");
            PrintArray(array);

        }


        static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}


//Задача:
//Реализуйте метод Shuffle, который перемешивает элементы массива в случайном порядке.
