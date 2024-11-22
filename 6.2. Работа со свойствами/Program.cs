namespace _6._2._Работа_со_свойствами
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5, 5);
            Render drawPlayer = new Render();

            drawPlayer.Draw(player.X, player.Y);
        }

        class Player
        {
            //int _x;
            //int _y;

            public int X { get; private set; }
            public int Y { get; private set; }

            //public int X
            //{
            //    get { return _x; }
            //    set { _x = value; }
            //}

            //public int Y
            //{
            //    get { return _y; }
            //    set { _y = value; }
            //}

            public Player(int x, int y)
            {
                X = x;
                Y = y;
            }

        }

        class Render
        {
            public void Draw(int x, int y, char sym = '$')
            {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(sym);
            }
        }
    }
}








//Задача:
//Создать класс игрока, у которого есть поля с его положением в x, y.
//Создать класс отрисовщик, с методом который отрисует игрока.

//Попрактиковаться в работе со свойствами.