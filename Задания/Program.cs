using System;
namespace _4._1_Кадровый_учет
{
    public class Program
    {
        static void Main()
        {
            string[] fullName = { "Петров И.М.", "Сидоров А.А", "Иванова А.А." };
            string[] jobTitle = { "Кладовщик", "Уборщик", "Секретарь" };
            string newSurFullName, newJobTitle, surname; 
            bool accountingOpen = true;
            string numberMenu, number;
            int value, numberDossier;
            while (accountingOpen)
            {
                DrawMenu();
                
                numberMenu = Console.ReadLine();
                value = NumberCheck(numberMenu);                
                if (value <= 5 && value > 0)
                    {
                        switch (value)
                        {
                            case 1:
                                Console.Write("Введите ФИО: ");
                                newSurFullName = Console.ReadLine();
                                fullName = AddDossier(fullName, newSurFullName);
                                Console.Write("Введите должность: ");
                                newJobTitle = Console.ReadLine();
                                jobTitle = AddDossier(jobTitle, newJobTitle);
                                break;
                            case 2:
                                DossierOutput(fullName, jobTitle);
                                break;
                            case 3:
                                Console.Write("Введите номер досье для удаления: ");
                                number = Console.ReadLine();
                                numberDossier = NumberCheck(number);                            
                                if (numberDossier == -1)
                                {
                                Console.WriteLine("Введена не верная комманда, попробуйте снова.");
                                break;
                                }
                                else if (fullName.Length == 0)
                                {
                                    Console.WriteLine("Невозможно удалить - Список пуст");
                                    break;
                                }
                                fullName = DeleteDossier(fullName, numberDossier);
                                jobTitle = DeleteDossier(jobTitle, numberDossier);
                                break;
                                                       
                            case 4:
                                Console.Write("Введите фамилию для поиска: ");
                                surname = Console.ReadLine();
                                SearchSurname(fullName, jobTitle, surname);
                                break;
                            case 5:
                                accountingOpen = false;
                                break;
                        }

                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        Console.Clear();
                }
                else
                {

                    Console.WriteLine("Введена не верная комманда, попробуйте снова.\nНажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

        }       

        static void DrawMenu()
        {
            Console.Write($"Добро пожаловать в систему учета.\n" +
                $"Вы можете совершить:\n" +
                $"1) Добавить досье.\n" +
                $"2) Вывести досье.\n" +
                $"3) Удалить досье.\n" +
                $"4) Поиск по фамилии.\n" +
                $"5) Завершить работу\n" +
                $"Выберите комманду: ");
        }
        static void DossierOutput(string[] fullName, string[] jobTitle)
        {
            if (fullName.Length == 0)
            {
                Console.WriteLine("Список пуст");
            }
            
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.Write($"{i + 1}. {fullName[i]} - {jobTitle[i]} ");
            }
            Console.WriteLine();
        }

        static string[] AddDossier(string[] arrayName, string name)
        {
            Array.Resize(ref arrayName, arrayName.Length + 1);
            arrayName[arrayName.Length - 1] = name;
            return arrayName;
        }

        static string[] DeleteDossier(string[] arrayName, int numberDossier)
        {

            
                arrayName[numberDossier - 1] = "-";
                for (int i = 0; i < arrayName.Length - 1; i++)
                {
                    if (arrayName[i] == "-")
                    {
                        arrayName[i] = arrayName[++i];
                        arrayName[i] = "-";
                        --i;
                    }
                }
            

            
            
            Array.Resize(ref arrayName, arrayName.Length - 1);
            return arrayName;
        }

        static void SearchSurname(string[] arrayName, string[] arrayJob, string surname)
        {
            surname = surname.ToLower();
            for (int i = 0; i < arrayName.Length; i++)
            {
                if (surname == arrayName[i].ToLower().Substring(0, arrayName[i].IndexOf(' ')))
                {
                    Console.WriteLine($"{i + 1}. {arrayName[i]} - {arrayJob[i]}");
                }
            }
        }

        static int NumberCheck(string value)
        {
            if (int.TryParse(value, out int number))
            {
                return number;
            }
            else
            {                               
                return -1;
            }
        }
    }
}

/*
Задача:
Будет 2 массива: 1) фио 2) должность.

Описать функцию заполнения массивов – досье, функцию форматированного вывода, функцию поиска по фамилии и функцию удаления досье.

Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.

Программа должна быть с меню, которое содержит пункты:

1) добавить досье.

2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)

3) удалить досье

4) поиск по фамилии

 */



