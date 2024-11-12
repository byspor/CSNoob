namespace _5._3_Динамический_массив_продвинутый
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<float> list = new List<float>();
            bool isOpen = true;
            string inputMenu;
            
            while (isOpen)
            {
                Console.Clear();
                Menu();
               
                Console.Write("Введите меню команды: ");
                inputMenu = Console.ReadLine();
                if (inputMenu != "exit" && inputMenu != "sum" && inputMenu != "input")
                {
                    Console.WriteLine("Введена не верная команда. Попробуйте снова.");
                }

                switch (inputMenu)
                {
                    case "exit":
                        isOpen = false;
                        break;
                    case "sum":
                        Sum(list);
                        break;
                    case "input":
                        Console.Write("Введите число: ");
                        string input;
                        input = Console.ReadLine();

                        if (float.TryParse(input, out float number))
                        {
                            list.Add(number);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введена не известная команда, попробуйте снова");
                            break;
                        }
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();               
                
            }
        }

        static void Menu()
        {
            Console.WriteLine("Меню программы:");
            Console.WriteLine("input - Ввести число");
            Console.WriteLine("sum - Вывести сумму всех чисел");
            Console.WriteLine("exit - Выход из программы");
        }



        static void Sum(List<float> list)
        {
            float sum = 0;
            foreach (float number in list)
            {
                sum += number;
            }
            Console.WriteLine("Сумма всех чисел = " + sum);
        }

    }
}



//Задача:
//В массивах вы выполняли задание "Динамический массив"
//Используя всё изученное напишите улучшенную версию динамического массива(не обязательно брать своё старое решение)
//Задание нужно чтобы вы освоились с List и прощупали его преимущество.
//Проверка на ввод числа обязательна.

//Пользователь вводит числа, и программа их запоминает.
//Как только пользователь введёт команду sum, программа выведет сумму всех веденных чисел.

//Выход из программы должен происходить только в том случае, если пользователь введет команду exit.