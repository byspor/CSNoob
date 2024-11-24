namespace _6._3._База_данных_игроков
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int numberMenu, playerSelection;

            List<Player> players = new List<Player>() { new Player("Alex", 1), new Player("Kris", 5) };         
                   
            while (isOpen)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.Write($"{++i}. ");
                    i--;
                    players[i].ShowPlayer();
                }


                Console.WriteLine("\nДобро пожаловать в админку.\nВыберите действие:\n");
                Console.Write($"1. Добавить игрока\n" +
                    $"2. Забанить игрока\n" +
                    $"3. Разбанить игрока\n" +
                    $"4. Удаление игрока\n" +
                    $"5. Завершить работу\n");
                numberMenu = Convert.ToInt32(Console.ReadLine());
                switch (numberMenu)
                {
                    case 1:
                        players.Add(Player.AddPlayer());
                        break;
                    case 2:                        
                        players[Player.PlayerNumber()].Ban = true;
                        break;
                    case 3:                        
                        players[Player.PlayerNumber()].Ban = false;
                        break;
                    case 4:                        
                        players.RemoveAt(Player.PlayerNumber());
                        break;
                    case 5:
                        isOpen = false;
                        break;
                }

                Console.Clear();                
            }            
        }     

        public class Player
        {

            string _name;
            int _lvl;
            bool _ban;

            public bool Ban
            {
                get { return _ban; }
                set { _ban = value; }
            }
            


            public Player(string name, int lvl)
            {
                _name = name;
                _lvl = lvl;
            }
            string DrawBan()
            {
                if (_ban)
                {
                   return "Забанен";
                }
                else 
                {
                    return "Не забанен";
                }
            }
            public void ShowPlayer()
            {
                Console.WriteLine($"Имя игрока: {_name,-15} | Уровень: {_lvl,3} | Статус: {DrawBan()}");

            }
            

            public static Player AddPlayer()
            {
                string name;
                int lvl;
                Console.WriteLine("Введите имя игрока: ");
                name = Console.ReadLine();
                Console.WriteLine("Введите лвл игрока: ");
                lvl = Convert.ToInt32(Console.ReadLine());
                return new Player(name, lvl);
            }

            public static int PlayerNumber()
            {
                int number;
                Console.Write("Введите номер игрока: ");
                number = Convert.ToInt32(Console.ReadLine());
                return number - 1;
            }
        }
    }








    //    Задача:
    //Реализовать базу данных игроков и методы для работы с ней.
    //У игрока может быть порядковый номер, ник, уровень, флаг – забанен ли он(флаг - bool). +
    //Реализовать возможность добавления игрока, бана игрока по порядковому номеру, разбана игрока по порядковому номеру и удаление игрока.
}
