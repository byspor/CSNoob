using System.Linq;

namespace _7._7._Объединение_войск
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> squad1 = new List<string>();
            List<string> squad2 = new List<string>();

            // Squad 1
            
            squad1.Add("Богдан");
            squad1.Add("Иван");
            squad1.Add("Борис");
            squad1.Add("Петр");
            squad1.Add("Сергей");
            squad1.Add("Алексей");
            squad1.Add("Богумил");
            squad1.Add("Дмитрий");
            squad1.Add("Николай");
            squad1.Add("Борислав");
            squad1.Add("Владимир");
            squad1.Add("Бронислав");
            squad1.Add("Александр");
            squad1.Add("Михаил");
            squad1.Add("Андрей");

            // Squad 2
            squad2.Add("Богдан");
            squad2.Add("Борислав");
            squad2.Add("Бронислав");
            squad2.Add("Борис");
            squad2.Add("Богумил");
            squad2.Add("Игорь");
            squad2.Add("Павел");
            squad2.Add("Сергей");
            squad2.Add("Алексей");

            squad2.AddRange(squad1.Where(soldier => soldier.StartsWith('Б') ));
            squad2.ForEach(soldier => Console.WriteLine(soldier));

        }
    }

    class Soldier
    {
        public Soldier(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}

//Задача:
//Есть 2 списка в солдатами.
//Всех бойцов из отряда 1 у которых фамилия начинается на букву Б требуется перевести в отряд 2.
