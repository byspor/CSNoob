using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4_Кадровый_учет_продвинутый
{
    internal class DossierManager
    {
        Dictionary<string, string> dossier = new Dictionary<string, string>();

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







//Console.WriteLine("1. Добавить досье");
//Console.WriteLine("2. Вывести список досье");
//Console.WriteLine("3. Удалить досье");
//Console.WriteLine("4. Заменить досье");
//Console.WriteLine("5. Вывести список фамилий");
//Console.WriteLine("6. Вывести список должностей");
