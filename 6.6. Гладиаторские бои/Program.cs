using System.Xml.Linq;

namespace _6._6._Гладиаторские_бои
{
    internal class Program
    {
        public static readonly Random random = new Random();
        static void Main(string[] args)
        {
            int inputNumberLeftFighter, inputNumberRightFighter;
            Fighter leftFighter;
            Fighter rightFighter;
            int UnBuff = 3;
            List<Fighter> fighters = new List<Fighter>() { new Barbarian("ZUXLET"), new Mage("SPOR"), new Warrior("androidggg") };

            for (int i = 0; i < fighters.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                fighters[i].ShowInfo();
            }

            while (true)
            {
                Console.WriteLine("Добро пожаловать в бойцовский клуб");
                Console.Write("Выберите бойца из списка кто будет в левом углу ринга: ");
                inputNumberLeftFighter = Convert.ToInt32(Console.ReadLine());
                leftFighter = fighters[inputNumberLeftFighter - 1];
                Console.Write("Выберите бойца из списка кто будет в правом углу ринга: ");
                inputNumberRightFighter = Convert.ToInt32(Console.ReadLine());
                if (inputNumberLeftFighter == inputNumberRightFighter)
                {
                    Console.WriteLine("Вы не можете выбрать бойца так как он уже в левом краю ринга. Попробуйте снова.");
                }
                else
                {
                    rightFighter = fighters[inputNumberRightFighter - 1];
                    break;
                }
            }
            Console.Clear();           

            while (rightFighter.Health > 0 && leftFighter.Health > 0)
            {
                
                
                rightFighter.ShowInfo();
                leftFighter.ShowInfo();
                if (UnBuff == 0)
                {
                    rightFighter.UnSkill();
                    leftFighter.UnSkill();
                    UnBuff = 2;
                }
                --UnBuff;
                if (rightFighter.Buff == 0 && leftFighter.Buff == 0)
                {
                    rightFighter.Skill();
                    leftFighter.Skill();
                }
                else 
                {
                    rightFighter.Buff -= 1;
                    leftFighter.Buff -= 1;
                }               
                
                leftFighter.Fight(leftFighter, rightFighter);
                rightFighter.Fight(rightFighter, leftFighter);

            }
            Console.WriteLine();
            rightFighter.ShowInfo();
            leftFighter.ShowInfo();
            if (rightFighter.Health <= 0)
            {
                Console.WriteLine("\nВыжил " + leftFighter.Name);
            }
            else
            {
                Console.WriteLine("\nВыжил " + rightFighter.Name);
            }
            
        }
    }

    abstract class Fighter
    {
        public float Health { get; set; }
        public float Damage { get; set; }
        public float Armor { get; set; }
        public string Name { get; set; }
        public int Buff { get; set; }

        public abstract void Skill();
        public abstract void UnSkill();
        public void ShowInfo()
        {
            Console.WriteLine($"Имя бойца: {Name,-10} | HP = {Health.ToString("f1"),-6} | DMG = {Damage.ToString("f1"),-6} | Armor = {Armor,-3}");
        }

        public void Fight(Fighter leftFighter, Fighter rightFighter)
        {
            leftFighter.Health -= rightFighter.Damage - ArmorPercentage(leftFighter,rightFighter);                                 
        }

        private float ArmorPercentage(Fighter leftFighter, Fighter rightFighter)
        {
            return (rightFighter.Damage * (leftFighter.Armor / 100));
        }

    }

    class Barbarian : Fighter
    {
        
        public Barbarian(string name)
        {
            Name = name;
            Health = 500;
            Damage = Program.random.Next(50, 101);
            Armor = 0;
            Buff = 0;
        }

        public override void Skill()
        {
            Damage += Damage / 2;
            Buff += 2;
        }

        public override void UnSkill()
        {
            Damage = Damage / 2;
        }
    }

    class Mage : Fighter
    {
        public Mage(string name)
        {
            Name = name;
            Health = 200;
            Damage = 0;
            Armor = 20;
            Buff = 0;
        }
        public override void Skill()
        {
            Damage = Program.random.Next(10, 500);
            Buff += 2;
        }

        public override void UnSkill()
        {
            Damage = 0;
        }
    }

    class Warrior : Fighter
    {
        public Warrior(string name)
        {
            Name = name;
            Health = Program.random.Next(200, 401);
            Damage = Program.random.Next(20, 61);
            Armor = 25;
            Buff = 0;
        }
        public override void Skill()
        {
            Armor += 50;
            Buff += 2;
        }

        public override void UnSkill()
        {
            Armor = 25;
        }
    }
}



//Задача:
//Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти. У каждого бойца могут быть свои статы.
//Каждый игрок должен иметь особую способность для атаки, которая свойственна только его классу!
//Max XP 1000, 



//Пожелание народа
//Сделай моего перса. Урон рандомиться от 0 до 10. 
//Абилка применяеться с каждым ударом у которой рандомиться шанс на инстакил с 1% до 20%, 
//и каждую потеренную 0.1 от хп если учитывать фулл как 1, то минимальный порог шанса на инстакил увеличиваеться на 1%