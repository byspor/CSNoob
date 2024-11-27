using System;
using System.Diagnostics;

namespace _6._5_Конфигуратор_пассажирских_поездов
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int numberTownDeparture, numberTownArrival, inputNumberMenu;
            string departureСity = "", arrivalCity = "";
            Passenger passenger = new Passenger(0);
            Train train = new Train(0);
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
                    Console.WriteLine($"Кол-во необходимых мест для посадки: {passenger.ValueTicket}\n");
                    Console.WriteLine($"Статус поезда - {train.StatusTrain()}");
                }
                Console.WriteLine($"Выберите действие:\n" +
                    $"1. Создать направление\n" +
                    $"2. Продать билеты\n" +
                    $"3. Сформировать поезд\n" +
                    $"4. Отправить поезд\n");

                if (int.TryParse(Console.ReadLine(), out inputNumberMenu) && inputNumberMenu > 0 && inputNumberMenu < 5)
                {
                    switch (inputNumberMenu)
                    {
                        case 1:                            
                            if (City.Free)
                            {
                                Console.WriteLine($"Выберите направление откуда едем:");
                                City.ShowInfo();
                                if (int.TryParse(Console.ReadLine(), out numberTownDeparture) && City.Towns.ContainsKey(numberTownDeparture))
                                {
                                    departureСity = City.Towns[numberTownDeparture];
                                    Console.WriteLine($"Выберите направление куда едем:");
                                    City.ShowInfo();
                                    if (int.TryParse(Console.ReadLine(), out numberTownArrival) && City.Towns.ContainsKey(numberTownArrival))
                                    {
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
                                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не возможно создать рейс, путь занят другим рейсом");
                            }                            
                            break;
                        case 2:
                            if (departureСity == "")
                            {
                                Console.WriteLine("В настоящее время рейсов нет. Купить билеты не возможно. Попробуйте позже.");
                            }
                            else if (train.FreeDirection == false || passenger.ValueTicket > 0)
                            {
                                Console.WriteLine("Билеты распроданы попробуйте позже.");
                            }
                            else
                            {
                                passenger = new Passenger();
                                passenger.ShowInfo();
                            }                            
                            break;
                        case 3:
                            if (passenger.ValueTicket > 0)
                            {
                                train = new Train();
                                train.FreeDirection = false;
                                for (int i = 0; i <= passenger.ValueTicket; i++)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Кол-во необходимых мест для посадки: {passenger.ValueTicket}\n");
                                    Console.WriteLine($"Добавить вагон №{i + 1}");
                                    Wagon wagon = new Wagon();
                                    train.AddWagon(wagon);
                                    passenger.ValueTicket -= wagon.NumberOfPlace;
                                    if (passenger.ValueTicket < 0)
                                    {
                                        passenger.ValueTicket = 0;
                                    }
                                    train.ShowInfo(wagon);
                                    Console.WriteLine($"Кол-во необходимых мест после посадки в вагон №{i + 1}: {passenger.ValueTicket}\n");
                                    Console.WriteLine("\nНажмите кнопку для продолжения.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Купленных билетов нету. Попробуйте позже.");
                            }
                            break;
                        case 4:
                            if (train.FreeDirection)
                            {
                                Console.WriteLine("В данный момент нет поездов для отправления.");
                            }
                            else
                            {
                                train.FreeDirection = true;
                                departureСity = "";
                                arrivalCity = "";
                                Console.WriteLine("Поезд отчалил и путь освободился для нового маршрута.");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
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
        List<Wagon> Wagons { get; set; }


    }

    class Train : Itrain
    {

        public bool FreeDirection { get; set; }
        public List<Wagon> Wagons { get; set; }
        public int Empty { get; set; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public Train(int empty)
        {
            Empty = empty;
            FreeDirection = true;
        }

        public void ShowInfo(Wagon wagon)
        {

            Console.WriteLine($"В вагоне {wagon.NumberOfPlace} пассажиров");            
        }

        public void AddWagon(Wagon wagon)
        {

            Wagons.Add(wagon);
        }

        public string StatusTrain()
        {
            if (FreeDirection)
            {
               return "Путь свободен";
            }
            else
            {
               return "Путь занят";
            }
            
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
        public int Zero { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Кол-во купленных билетов {ValueTicket}");
        }

        
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