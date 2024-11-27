using System;

namespace _6._5_Конфигуратор_пассажирских_поездов
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int inputNumberMenu, numberTownDeparture, numberTownArrival, numberTicket = 0;
            string departureСity = "", arrivalCity = "";  
            Passenger passenger = new Passenger(0);
            while (isOpen)
            {
                Console.WriteLine("Добро пожаловать!\n");
                if (departureСity == "" || arrivalCity == "")
                {
                    Console.WriteLine("В данный момент рейсов нет!\n");
                }
                else 
                {
                    Console.WriteLine($"Текущий рейс: {departureСity} - {arrivalCity}\n");
                    passenger.ShowInfo();
                    //Console.WriteLine($"Кол-во купленных билетов {numberTicket}\n");
                }
                Console.WriteLine($"Выберите действие:\n" +
                    $"1. Создать направление\n" +
                    $"2. Продать билеты\n" +
                    $"3. Сформировать поезд\n" +
                    $"4. Отправить поезд\n");
                inputNumberMenu = Convert.ToInt32(Console.ReadLine());
                switch (inputNumberMenu)
                {
                    case 1:
                        if (City.Free)
                        {
                            Console.WriteLine($"Выберите направление откуда едем:");
                            City.ShowInfo();
                            numberTownDeparture = Convert.ToInt32(Console.ReadLine());
                            departureСity = City.Towns[numberTownDeparture];
                            Console.WriteLine($"Выберите направление куда едем:");
                            City.ShowInfo();
                            numberTownArrival = Convert.ToInt32(Console.ReadLine());
                            if (numberTownDeparture == numberTownArrival)
                            {
                                Console.WriteLine("Невозможно выбрать данный город, так как вы из него отправляетесь. Попробуйте снова.");
                            }
                            else
                            {
                                arrivalCity = City.Towns[numberTownArrival];
                                Console.WriteLine($"Рейс {departureСity} - {arrivalCity} успешно зарегистрирован");
                                City.Free = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не возможно создать рейс, путь занят другим рейсом");
                        }
                        break;
                    case 2:
                        if (departureСity == "" || arrivalCity == "")
                        {
                            Console.WriteLine("В настоящее время рейсов нет. Купить билеты не возможно. Попробуйте позже.");
                        }
                        else
                        {
                            // numberTicket = passenger.ValueTicket;
                            Passenger passenger1 = new Passenger();
                            Passenger passenger = passenger1;
                            passenger.ShowInfo();
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                Console.WriteLine("Нажмите кнопку для продолжения.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
    }

    interface Itrain
    {

        bool FreeDirection { get; set; }
        List<Wagon> vagons { get; set; }


    }

    class Train : Itrain
    {

        public bool FreeDirection { get; set; }
        public List<Wagon> vagons { get; set; }

        public Train()
        {
            vagons = new List<Wagon>();
        }
    }

    interface IWagon
    {
        int NumberOfPlace { get; set; }

    }

    class Wagon : IWagon
    {
        public int NumberOfPlace { get; set; }
        Random random = new Random();

        public Wagon()
        {
            NumberOfPlace = random.Next(10, 21);
        }


    }
    class Passenger
    {
        Random random = new Random();        

        public Passenger()
        {
            ValueTicket = random.Next(20, 101);
        }

        public Passenger(int zero)
        {
            Zero = zero;
        }

        public int ValueTicket { get; set; }
        public int Zero { get; }

        public void ShowInfo()
        {
            Console.WriteLine($"Кол-во купленных билетов {ValueTicket}");
        }

    }

    public enum direction
    {
        Bijsk,
        Barnaul,
        Babrujsk,
        Volgograd
    }

    static class City
    {
        public static Dictionary<int, string> Towns = new Dictionary<int, string>()
            {
                { 1, "Бийск" },
                { 2, "Барнаул"},
                { 3, "Бабруйск"},
                { 4, "Волгоград"}
            };

        public static void ShowInfo()
        {
            foreach (var town in Towns)
            {
                Console.WriteLine($"{town.Key}. Город - {town.Value}");
            }
        }

        public static bool Free = true;

    }


}



//Задача:
//У вас есть программа, которая помогает пользователю составить план поезда.
//Есть 4 основных шага в создании плана:
//-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
//-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
//-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
//-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
//В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.