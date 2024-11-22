namespace _6._3._База_данных_игроков
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int numberMenu, playerSelection;

            List<Player> players = new List<Player>() { new Player("Alex", 1), new Player("Kris", 5) };
        //    players.Add(new Player("Kris", 5));   
                   
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
                        players.Add(AddPlayer());
                        break;
                    case 2:
                        Console.Write($"Введите номер игрока для бана: ");
                        playerSelection = Convert.ToInt32(Console.ReadLine());
                        players[playerSelection - 1].banPlayer();
                        break;
                    case 3:
                        Console.Write($"Введите номер игрока для разбана: ");
                        playerSelection = Convert.ToInt32(Console.ReadLine());
                        players[playerSelection - 1].unBanPlayer();
                        break;
                    case 4:
                        Console.Write($"Введите номер игрока для удаления: ");
                        playerSelection = Convert.ToInt32(Console.ReadLine());
                        players.RemoveAt(playerSelection - 1);
                        break;
                    case 5:
                        isOpen = false;
                        break;
                }

                Console.Clear();
            }


            
        }

        public static Player AddPlayer()
        {
            string nameNew;
            int lvlNew;
            Console.WriteLine("Введите имя игрока: ");
            nameNew = Console.ReadLine();
            Console.WriteLine("Введите лвл игрока: ");
            lvlNew = Convert.ToInt32(Console.ReadLine());
            return new Player(nameNew, lvlNew);
        }

        public class Player
        {

            string _name;
            int _lvl;
            bool _ban;            

            public Player(string name, int lvl)
            {
                _name = name;
                _lvl = lvl;
            }
            void DrawBan()
            {
                if (_ban)
                {
                    Console.Write("Забанен");
                }
                else 
                {
                    Console.Write("Не забанен");
                }
            }
            public void ShowPlayer()
            {
                Console.WriteLine($"Имя игрока: {_name} | Уровень = {_lvl} | Доступ к учетной записи - {DrawBan}");
            }

            public void banPlayer()
            {
                _ban = true;
            }

            public void unBanPlayer()
            {
                _ban = false;
            }
        }
    }








    //    Задача:
    //Реализовать базу данных игроков и методы для работы с ней.
    //У игрока может быть порядковый номер, ник, уровень, флаг – забанен ли он(флаг - bool). +
    //Реализовать возможность добавления игрока, бана игрока по порядковому номеру, разбана игрока по порядковому номеру и удаление игрока.
}
