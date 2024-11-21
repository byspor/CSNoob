namespace _5._4_Кадровый_учет_продвинутый
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossier = new Dictionary<string, string>();

            dossier.Add("Петров А.А.", "Кладовщик");
            dossier.Add("Семенова А.Г.", "Секретарь");
            dossier.Add("Малинина Г.Г.", "Бухгалтер");
            bool isOpen = true;
            string input;            
            while (isOpen)
            {
                Console.Clear();
                Menu();

                input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    switch (number)
                    {
                        case 1:
                            dossier.Add(Surname(), Post());
                            break;
                        case 2:
                            DrawDossier(dossier);
                            break;
                        case 3:                           
                            RemoveDossier(dossier);
                            break;
                        case 4:
                            ModifyDossier(dossier);
                            break;
                        case 5:
                            DrawSurname(dossier);
                            break;
                        case 6:
                            DrawPost(dossier);
                            break;
                        case 0:
                            isOpen = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введена не верная команда. Попробуйте снова.");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();

            }
        }
        

        static void Menu()
        {
            Console.WriteLine("Вас приветствует программа по кадровому учёту");
            Console.WriteLine("1. Добавить досье");
            Console.WriteLine("2. Вывести список досье");
            Console.WriteLine("3. Удалить досье");
            Console.WriteLine("4. Заменить досье");
            Console.WriteLine("5. Вывести список фамилий");
            Console.WriteLine("6. Вывести список должностей");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Выберите команду: ");
        }

        static void DrawDossier(Dictionary<string, string> dossier)
        {
            foreach (var s in dossier)
            {
                Console.Write(s.Key + " - " + s.Value + " ");
            }
        }

        static void DrawSurname(Dictionary<string, string> dossier)
        {
            Console.WriteLine("Список фамилий: ");
            foreach (var s in dossier)
            {
                Console.WriteLine(s.Key);
            }
        }

        static void DrawPost(Dictionary<string, string> dossier)
        {
            Console.WriteLine("Список должностей: ");
            foreach (var s in dossier)
            {
                Console.WriteLine(s.Value);
            }
        }

        static string Surname()
        {
            string name;
            Console.Write("Введите Фамилию И.О. : ");
            name = Console.ReadLine();
            return name;
        }

        static string Post()
        {
            string name;
            Console.Write("Введите должность : ");
            name = Console.ReadLine();
            return name;
        }

        static Dictionary<string, string> RemoveDossier(Dictionary<string, string> dossier)
        {
            string name, name1 = "";
            Console.WriteLine("Введите досье для удаления (Фамилия)");
            name = Console.ReadLine();
            name = name.ToLower();
            foreach (var s in dossier)
            {
                if (s.Key.ToLower().Contains(name))
                {
                    dossier.Remove(s.Key);
                    name1 = "Досье удалено";
                    break;
                }
                else
                {
                    name1 = "Такой фамилии в досье нету.";
                }
            }
            Console.WriteLine(name1);
            return dossier;
        }

        static Dictionary<string, string> ModifyDossier(Dictionary<string, string> dossier)
        {
            string name, name1 = "", surname = "", post = "";
            Console.WriteLine("Введите досье для замены (Фамилия)");
            name = Console.ReadLine();
            name = name.ToLower();
            foreach (var s in dossier)
            {
                if (s.Key.ToLower().Contains(name))
                {
                    dossier.Remove(s.Key);
                    name1 = "Досье заменено";
                    break;
                }
                else
                {
                    name1 = "Такой фамилии в досье нету.";
                }
            }
            surname = Surname();
            post = Post();
            dossier.Add(surname, post);
            Console.WriteLine(name1);
            return dossier;
        }
    }
}



//Задача:
//В функциях вы выполняли задание "Кадровый учёт"
//Используя одну из изученных коллекций вы смогли бы сильно себе упростить код выполненной программы, ведь у нас данные это ФИО и позиция.
//Поиск в данном задании не нужен.

//1) добавить досье.

//2) вывести все досье (в одну строку через “-” фио и должность)

//3) удалить досье

//4) выход
