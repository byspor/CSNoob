using System.Linq;
namespace _7._1._Поиск_преступника
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Perpetrator> perpetrators = new List<Perpetrator>();
            perpetrators.Add(new Perpetrator("Аль Капоне", true, 175, 90, "Американец"));
            perpetrators.Add(new Perpetrator("Педро Лопес", true, 170, 60, "Колумбиец"));
            perpetrators.Add(new Perpetrator("Тед Банди", false, 180, 70, "Американец"));
            perpetrators.Add(new Perpetrator("Андрей Чикатило", true, 170, 65, "Россиянин"));
            perpetrators.Add(new Perpetrator("Джеффри Дамер", false, 185, 80, "Американец"));
            perpetrators.Add(new Perpetrator("Карлос Эскобар", false, 175, 75, "Колумбиец"));
            perpetrators.Add(new Perpetrator("Сергей Романов", false, 185, 85, "Россиянин"));
            perpetrators.Add(new Perpetrator("Иван Милат", false, 180, 80, "Австралиец"));
            perpetrators.Add(new Perpetrator("Деннис Рейдер", false, 185, 90, "Американец"));
            perpetrators.Add(new Perpetrator("Питер Сатклифф", false, 175, 70, "Британец"));

            Console.WriteLine("Список подозреваемых");
            foreach (var redperpetrator in perpetrators)
            {
                redperpetrator.ShowInfo();
            }

            int inputWeight, inputGrowth;
            string inputNationality;

            Console.WriteLine("Отфильтровать список по росту, весу, национальности");
            Console.Write("Введите рост: ");
            inputGrowth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вес: ");
            inputWeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите национальность: ");
            inputNationality = Console.ReadLine();

            var filteredperpetrators = perpetrators.Where(player => player.Growth > inputGrowth - 5 && player.Growth > inputGrowth + 5 && player.Weight > inputWeight - 5 && player.Weight > inputWeight + 5
                                                            && player.Nationality.ToLower() == inputNationality.ToLower() && player.Concluded == false);

            foreach (var redperpetrator in filteredperpetrators)
            {
                redperpetrator.ShowInfo();
            }
        }
    }

    class Perpetrator
    {
        public Perpetrator(string name, bool concluded, int growth, int weight, string nationality)
        {
            Name = name;
            Concluded = concluded;
            Growth = growth;
            Weight = weight;
            Nationality = nationality;
        }

        public string Name { get; set; }
        public bool Concluded { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public string Nationality { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО заключенного: {Name,-20} | Вес: {Weight,-3} | Рост: {Growth,-3} | Национальность: {Nationality,-10} | Арестован: {(Concluded ? "Да" : "Нет")}");
        }


    }
}


//Задача:
//У нас есть список всех преступников. +
//В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность. +
//Вашей программой будут пользоваться детективы.
//У детектива запрашиваются данные (рост, вес, национальность) и детективу выводятся все преступники которые подходят под эти параметры, но уже заключенные под стражу выводиться не должны.