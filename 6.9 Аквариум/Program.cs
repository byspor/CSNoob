namespace _6._9_Аквариум
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fish> aquarium = new List<Fish>();
            aquarium.Add(new Fish("Китовая акула во фритюре", 20));
            aquarium.Add(new Fish("Шпроты в масле", 3));
            aquarium.Add(new Fish("Запеченный карасик", 7));
            aquarium.Add(new Fish("Селедка под шубой", 10));            
            aquarium.Add(new Fish("Килька в томате", 5));

            while (aquarium.Count > 0) 
            {
                foreach (Fish fish in aquarium)
                {
                    fish.ShowInfo();
                    
                }

                for (int i = 0; i < aquarium.Count; i++) 
                {
                    if (aquarium[i].MaxAge > 0)
                    {
                        aquarium[i].MaxAge--;
                    }
                    else 
                    {
                        Console.WriteLine($"{aquarium[i].Name} была сожрана без остатков");
                        aquarium.Remove(aquarium[i]);
                    }
                }
                Thread.Sleep(800);
                Console.Clear();
            }

            Console.WriteLine("Увы всех съели");
            
        }
    }

    class Fish
    {
        public string Name { get; set; }        
        public int MaxAge { get; set; }
        public Fish(string name, int maxAge)
        {
            Name = name;            
            MaxAge = maxAge;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name, -25} | Срок годности: {MaxAge, -3}");
        }
        

    }
}




//Задача:
//Есть аквариум, в котором плавают рыбы. В этом аквариуме может быть максимум определенное кол-во рыб. 
//Рыб можно добавить в аквариум или рыб можно достать из аквариума. (программу делать в цикле для того, чтобы рыбы могли “жить”)
//Все рыбы отображаются списком, у рыб также есть возраст. За 1 итерацию рыбы стареют на определенное кол-во жизней и могут умереть. 
//Рыб также вывести в консоль, чтобы можно было мониторить показатели.