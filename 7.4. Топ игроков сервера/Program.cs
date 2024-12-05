using System.Linq;

namespace _7._4._Топ_игроков_сервера
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("DarkLord", 10, 100),
                new Person("Pwnz0r", 15, 150),
                new Person("Spartan", 8, 80),
                new Person("Xx_NoScope_xX", 12, 120),
                new Person("KillerQueen", 18, 150),
                new Person("Nemesis", 9, 90),
                new Person("VladTheImpaler", 14, 140),
                new Person("Mystic", 11, 110),
                new Person("Anarchy", 16, 160),
                new Person("Oblivion", 7, 70),
                new Person("Vicious", 13, 130),
                new Person("YuriTheGreat", 17, 170),
                new Person("KGB", 6, 60),
                new Person("GForce", 19, 290),
                new Person("AxeMan", 5, 50),
                new Person("Rampage", 20, 150),
                new Person("Vandal", 4, 40),
                new Person("IceMan", 3, 30),
                new Person("Berserk", 2, 20),
                new Person("Lethal", 1, 10) 
            };

            people.ForEach(person => Console.WriteLine(person));
            var topLvl = people.OrderByDescending(person => person.Lvl).Take(3).ToList();
            Console.WriteLine("\nТоп 3 игрока сервера по Уровню:\n");
            topLvl.ForEach(person => Console.WriteLine(person));
            Console.WriteLine("\nТоп 3 игрока сервера по Силе:\n");
            var topPower = people.OrderByDescending(person => person.Power).Take(3).ToList();
            topPower.ForEach(person => Console.WriteLine(person));
        }
    }

    record Person(string Name, int Lvl, int Power)
    {
        public override string ToString()
        {
            return $"Имя игрока: {Name,-15} | Уровень: {Lvl,-3} | Сила: {Power,-5} ";
        }
    }
}



//Задача:
//У нас есть список всех игроков(минимум 10). У каждого игрока есть поля: имя, уровень, сила.
//Требуется написать запрос для определения топ 3 игроков по уровню и топ 3 игроков по силе, после чего вывести каждый топ.
//2 запроса получится.
