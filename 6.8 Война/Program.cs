using System.Threading;

namespace _6._8_Война
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> squad1 = new List<Soldier>();
            squad1.Add(new Tank());
            squad1.Add(new Soldier());
            squad1.Add(new DD());
            squad1.Add(new Soldier());
            squad1.Add(new Tank());
            squad1.Add(new Soldier());            
            squad1.Add(new DD());
            squad1.Add(new DD());            
            squad1.Add(new Tank());
            

            List<Soldier> squad2 = new List<Soldier>();
            squad2.Add(new Soldier());
            squad2.Add(new Soldier());
            squad2.Add(new Soldier());
            squad2.Add(new DD());
            squad2.Add(new DD());
            squad2.Add(new DD());
            squad2.Add(new Tank());
            squad2.Add(new Tank());
            squad2.Add(new Tank());

            while (squad1.Count > 0 && squad2.Count > 0)
            {

                int i1 = Random.Shared.Next(0, squad1.Count);
                int i2 = Random.Shared.Next(0, squad2.Count);
                Console.WriteLine($"\nБоец 1 отряда №{i1 + 1}");                
                squad1[i1].ShowInfo();
                Console.WriteLine($"\nБоец 2 отряда №{i2 + 1}");
                squad2[i2].ShowInfo();
               
                squad1[i1].Health -= squad2[i2].Damage;
                squad2[i2].Health -= squad1[i1].Damage;
                if (squad1[i1].Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nБоец №{i1 + 1} позорно сдох\n");
                    Console.ResetColor();
                    squad1.RemoveAt(i1);
                }
                if (squad2[i2].Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nБоец №{i2 + 1} позорно сдох\n");
                    Console.ResetColor();
                    squad2.RemoveAt(i2);
                }
                Thread.Sleep(800);                
            }
            if (squad1.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выиграл 2 взвод");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Soldier soldier in squad2)
                {
                    soldier.ShowInfo();
                }
            }
            if (squad2.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выиграл 1 взвод");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Soldier soldier in squad1)
                {
                    soldier.ShowInfo();
                }
            }
            Console.ResetColor();


        }
    }
    

    class Soldier
    {
        public Soldier()
        {
            Name = "Default";
            Damage = 50;
            Health = 100;
        }

        public string Name {get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name, -10} | Урон: {Damage, -3} | Жизни: {Health, -3}");
        }

    }

    class DD : Soldier
    {
        public DD() 
        {
            Name = "DD";
            Damage = 200;
            Health = 50;
        }
    }

    class Tank : Soldier
    {
        public Tank()
        {
            Name = "Tank";
            Damage = 20;
            Health = 500;
        }
    }

}



//Задача:
//Есть 2 взвода. 1 взвод страны один, 2 взвод страны 2.
//Каждый взвод внутри имеет солдат.
//Нужно написать программу которая будет моделировать бой этих взводов.
//Каждый боец - это уникальная единица, он может иметь уникальные способности или же уникальные характеристики, такие как повышенная сила.
//Побеждает та страна, во взводе которой остались выжившие бойцы.
//Не важно какой будет бой, рукопашный, стрелковый.
