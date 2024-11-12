namespace _4._3._ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;
            bool isOpen= true;

            while (isOpen)
            {
                isOpen = CheckNumber(isOpen);
            }
        }

        static bool CheckNumber(bool isOpen)
        {
            Console.Write("Введите любое число: ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                Console.WriteLine("Поздравляю вы справились и ввели число - " + number);
                
                return isOpen = false;
            }
            Console.WriteLine("Введено не число, попробуйте снова.");
           return isOpen;
        }
    }
}


//Задача:
//Написать функцию, которая запрашивает число у пользователя (с помощью метода Console.ReadLine() ) и пытается сконвертировать его в тип int (с помощью int.TryParse())



//Если конвертация не удалась у пользователя запрашивается число повторно до тех пор, пока не будет введено верно. После ввода, который удалось преобразовать в число, число возвращается.

//P.S Задача решается с помощью циклов

//P.S Также в TryParse используется модфикатор параметра out