namespace _4._2_Brave_new_world
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            char[,] map = new char[12, 22]
            {
            {'|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|'},
            {'|','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','|'},
            {'|','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','|'},
            {'|','#','#','#','#','#',' ','#','#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#','#','#','|'},
            {'|','#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#','|'},
            {'|','#','#','#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#','#','|'},
            {'|','#',' ',' ',' ','T',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ',' ','#','|'},
            {'|','#','#',' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ',' ',' ','#','|'},
            {'|','#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#','|'},
            {'|','#',' ',' ','#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ',' ','#','|'},
            {'|','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','|'},
            {'|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|','|'},
            };
            int playerX = 2, playerY = 4;
            int playerDX = 0, playerDY = 1;
            bool buff = false;
            bool isOpen = true;

            
            DrawMap(map);

            

            while (isOpen)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key) 
                    { 
                        case ConsoleKey.UpArrow:
                            playerDX = -1; playerDY = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            playerDX = 1; playerDY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            playerDX = 0; playerDY = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            playerDX = 0; playerDY = 1;
                            break;
                    }                    
                }
                if (buff == false)
                {
                    if (map[playerX + playerDX, playerY + playerDY] != '#')
                    {
                        if (map[playerX + playerDX, playerY + playerDY] == 'T')
                        {
                            buff = true;
                        }
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write(' ');

                        playerX += playerDX;
                        playerY += playerDY;

                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('*');
                    }
                }
                else
                {
                    if (map[playerX + playerDX, playerY + playerDY] != '|')
                    {
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write(' ');

                        playerX += playerDX;
                        playerY += playerDY;

                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('*');
                        if (map[playerX + playerDX, playerY + playerDY] == '|')
                        {
                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write(' ');

                            playerX += playerDX;
                            playerY += playerDY;

                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write(' ');
                            playerDY = 0;
                            playerX += playerDX;
                            playerDY = 0;
                            playerY += playerDY;                            
                            Console.SetCursorPosition(100, 20);
                            Console.Write('*' + "     Свобода");                         
                            isOpen = false;
                        }
                    }
                }

                System.Threading.Thread.Sleep(200);
            }

            static void DrawMap(char[,] arrayMap)
            {                
                for (int i = 0; i < arrayMap.GetLength(0); i++)
                {
                    for (int j = 0; j < arrayMap.GetLength(1); j++)
                    {
                        Console.Write(arrayMap[i,j]);
                    }
                    Console.WriteLine();
                }
            }
            
        }
    }
}




//Задача:
//Сделать игровую карту с помощью двумерного массива. Сделать функцию рисования карты.
//Помимо этого, дать пользователю возможность перемещаться по карте и взаимодействовать с элементами (например пользователь не может пройти сквозь стену)

//Все элементы являются обычными символами

//усложнение  1.1 - грибочек. +
//Усложнение 1.2 - баф от грибочка (например перестает работать автопилот или там на какую-нибудь клавишу стоя у стены можно пробить ее под бафом грибочка)
//1.3 - если пробить стену в конце карты звездочка летит до конца экрана и вылазит сообщение "Свобода"