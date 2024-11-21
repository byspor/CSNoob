namespace _6._1._Работа_с_классами_ДЗ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[3] { new Player("spor", Gender.Male, 100, 100, 1), new Player("ZUXLET", Gender.Male, 200, 200, 3), new Player("BANANA", Gender.Female, 100, 500, 1) };

            foreach (Player p in players)
            {
                p.DrawPlayerInfo();
            }
              
        }
    }

    public class Player
    {
        string _name;
        Gender _gender;
        int _health;
        int _mana;
        int _lvl;

        public Player(string name, Gender gender, int health, int mana, int lvl)
        {
            _name = name;
            _gender = gender;
            _health = health;
            _mana = mana;
            _lvl = lvl;
        }

        public void DrawPlayerInfo()
        {
            Console.WriteLine($"Имя игрока: {_name}\n" +
                $"Пол игрока: {_gender}\n" +
                $"Кол-во ХП: {_health}\n" +
                $"Кол-во маны: {_mana}\n" +
                $"Лвл игрока: {_lvl}\n");
        }       
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}




//Задача:
//Создать класс игрока, с полями содержащими информацию об игроке и методом, который выводит информацию на экран.

//В классе обязательно должен быть конструктор