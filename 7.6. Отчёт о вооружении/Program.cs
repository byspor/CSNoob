using System.Linq;

namespace _7._6._Отчёт_о_вооружении
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>()
            {
                new("John Doe", "M4A1", "Private", 12),
                new("Jane Smith", "M16A2", "Corporal", 24),
                new("Bob Johnson", "M249", "Sergeant", 36),
                new("Alice Brown", "M4A1", "Private First Class", 18),
                new("Mike Davis", "M24", "Staff Sergeant", 48),
                new("Emily Chen", "M9", "Lieutenant", 60),
                new("David Lee", "M4A1", "Private", 12),
                new("Sarah Taylor", "M16A2", "Corporal", 24),
                new("Kevin White", "M249", "Sergeant", 36),
                new("Rebecca Hall", "M24", "Captain", 72)
            };

            soldiers.ForEach(soldier => Console.WriteLine(soldier));

            var soldiersRank = soldiers.Select(soldier => new { soldier.Name, soldier.Rank }).OrderBy(soldier => soldier.Name).ToList();
            Console.WriteLine();
            soldiersRank.ForEach(soldier => Console.WriteLine($"Имя солдата: {soldier.Name,-15} | Звание: {soldier.Rank,-20}"));
        }
    }

    record Soldier(string Name, string Weapon, string Rank, int ServiceDuration)
    {
        public override string ToString() 
        {
            return $"Имя солдата: {Name, -15} | Звание: {Rank, -20} | Вооружение: {-5} | Срок службы: {ServiceDuration,-2}";
        }
    }
    
}


//Задача:
//Существует класс солдата.В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
//Написать запрос при помощи которого получить набор данных состоящий из имени и звания.
//Вывести все полученные данные в консоль.
//(Не менее 5 записей)