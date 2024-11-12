using System;
namespace _4._2._UIElement

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 5, maxHealth = 100;
            int mana = 10, maxMana = 100;
            int menu, shiftHealth, shiftMana;
            string nameHealth = "жизни", nameMana = "мана";
            bool isOpen = true;

            while (isOpen) 
            {
                DrawBar(health, maxHealth, ConsoleColor.Red, 0, nameHealth, '#');
                DrawBar(mana, maxMana, ConsoleColor.DarkBlue, 1, nameMana, '#');

                Console.SetCursorPosition(0, 5);

                Console.Write("Введите 1 - что бы продолжить или 0 - что бы выйти. ");
                menu = Convert.ToInt32(Console.ReadLine());
                if (menu == 0)
                {
                    isOpen = false;
                    break;
                }                

                Console.Write($"Введите число, на которое изменятся {nameHealth}: ");
                shiftHealth = Convert.ToInt32(((Convert.ToSingle(Console.ReadLine()))/100) * maxHealth);
                shiftHealth = GuardValue(health,maxHealth,shiftHealth);                
                health += shiftHealth;
                Console.Write($"Введите число, на которое изменится {nameMana}: ");                
                shiftMana = Convert.ToInt32(((Convert.ToSingle(Console.ReadLine())) / 100) * maxMana);
                shiftMana = GuardValue(mana,maxMana,shiftMana);
                mana += shiftMana;
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
            }

            
        }

        static void DrawBar(int value, int maxValue,ConsoleColor color, int position, string name, char symbol = ' ')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";            
            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "_";

            for (int i = value; i < maxValue; i++)
            {
                bar += "_";
            }
            Console.Write(bar + ']' + "\t" + value + "%/" + maxValue + "% " + name);
        }

        static int GuardValue(int value, int maxValue, int shift)
        {
            if (shift + value < value)
            {
                shift = -value;
                return shift;
            }
            else if (shift + value > maxValue)
            {
                shift = maxValue - value;
                return shift;
            }
            return shift;
        }
       
    }
}

/*Задача:
Разработайте функцию, которая рисует некий бар(Healthbar, Manabar)в определённой позиции. Она также принимает некий закрашенный процент.

При 40% бар выглядит так:

[####_____]
*/