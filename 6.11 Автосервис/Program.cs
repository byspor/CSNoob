using System.Security.Cryptography;

namespace _6._11_Автосервис
{
    internal class Program
    {

        static void Main(string[] args)
        {
            CarService service1 = new CarService(10000);
            double dailyRevenue = service1.CashDesk;

            //список брендов машин
            List<CarBrand> carBrands = new List<CarBrand>();
            carBrands.Add(new CarBrand(CarBrands.Toyota));
            carBrands.Add(new CarBrand(CarBrands.Ford));
            carBrands.Add(new CarBrand(CarBrands.Volkswagen));
            carBrands.Add(new CarBrand(CarBrands.Honda));
            carBrands.Add(new CarBrand(CarBrands.Nissan));
            carBrands.Add(new CarBrand(CarBrands.BMW));
            carBrands.Add(new CarBrand(CarBrands.MercedesBenz));
            carBrands.Add(new CarBrand(CarBrands.Audi));
            carBrands.Add(new CarBrand(CarBrands.Kia));
            carBrands.Add(new CarBrand(CarBrands.Hyundai));

            //список запчестей
            List<Detail> details = new List<Detail>();
            details.Add(new Detail("Радиатор", 3, 5000));
            details.Add(new Detail("Тормозные колодки", 3, 2000));
            details.Add(new Detail("Свечи зажигания", 3, 1500));
            details.Add(new Detail("Масляный фильтр", 3, 1000));
            details.Add(new Detail("Воздушный фильтр", 3, 800));
            details.Add(new Detail("Аккумулятор", 3, 4000));
            details.Add(new Detail("Ремень генератора", 3, 2500));
            details.Add(new Detail("Шаровая опора", 3, 3000));
            details.Add(new Detail("Тормозной диск", 3, 3500));


            //Машины с поломками
            List<Car> cars = new List<Car>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                CarBrands randomBrand = (CarBrands)random.Next(carBrands.Count);
                string randomFailure = details[random.Next(details.Count)].NameDetail;
                cars.Add(new Car(randomBrand, randomFailure));
            }

            //склад запчестей
            //foreach (var brands in carBrands)
            //{
            //    brands.ShowInfo();
            //    for (int i = 0; i < details.Count; i++)
            //    {
            //        details[i].ShowInfo();
            //    }
            //    Console.WriteLine();
            //}


            //наполнение склада деталей по брендам
            foreach (var brands in carBrands)
            {
                for (int i = 0; i < details.Count; i++)
                {
                    brands.partsWarehouse.Add(details[i]);
                }
            }

           

            while (cars.Count > 0)
            {
                for (int j = 0; j <cars.Count; j++)
                {
                    Console.WriteLine("Добро пожаловать в наш автосервис ;)");
                    service1.ShowInfo();
                    foreach (Car car in cars)
                    {
                        car.ShowInfo();
                    }
                    Console.WriteLine();
                    cars[j].ShowInfo();                    
                    foreach (var brand in carBrands)
                    {
                        int countCars = cars.Count;
                        for (int i = 0; i < details.Count; i++)
                        {
                            if (cars[j].BrandName == brand.Name && cars[j].TypeOfFailure == brand.partsWarehouse[i].NameDetail && brand.partsWarehouse[i].Value > 0)
                            {
                                Console.WriteLine($"\nЦена ремонта: {brand.partsWarehouse[i].Price + service1.WorkPrice}");
                                brand.partsWarehouse[i].Value--;
                                service1.CashDesk += service1.WorkPrice + brand.partsWarehouse[i].Price;                                
                                Console.WriteLine("Успешная починка");
                                cars.Remove(cars[j]);
                                break;
                            }
                            else if (cars[j].BrandName == brand.Name && cars[j].TypeOfFailure == brand.partsWarehouse[i].NameDetail && brand.partsWarehouse[i].Value == 0)
                            {
                                Console.WriteLine($"Данной детали {cars[j].TypeOfFailure} марки {cars[j].BrandName} нету в наличии, мы готовы оплатить штраф в размере 10000");
                                service1.CashDesk -= 10000;
                                cars.Remove(cars[j]);
                                break;
                            }
                        }
                        if (countCars != cars.Count)
                        {
                            break;
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();                    
                }

            }
            Console.WriteLine($"Выручка за день: {service1.CashDesk - dailyRevenue}");

            //склад запчестей
            //foreach (var brands in carBrands)
            //{
            //    brands.ShowInfo();
            //    for (int i = 0; i < details.Count; i++)
            //    {
            //        details[i].ShowInfo();
            //    }
            //    Console.WriteLine();
            //}

        }
    }

    class CarService
    {
        public CarService(double cashDesk)
        {
            CashDesk = cashDesk;
            WorkPrice = 5000;
        }

        public double CashDesk { get; set; }
        public double WorkPrice { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Касса: {CashDesk} | Цена работы: {WorkPrice}\n");
        }
    }


    class CarBrand
    {
        public List<Detail> partsWarehouse = new List<Detail>();
        public CarBrand(CarBrands name)
        {
            Name = name;
        }

        public CarBrands Name { get; set; }

        public void AddDetail(Detail detail)
        {
            partsWarehouse.Add(detail);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название марки: {Name,-10}\n");
        }        

    }
    class Detail
    {
        public string NameDetail { get; set; }
        public int Value { get; set; }
        public double Price { get; set; }
        public Detail(string name, int value, double price)
        {
            NameDetail = name;
            Value = value;
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Тип детали: {NameDetail,-30} | Кол-во: {Value,-3} | Цена за штуку: {Price,-5}");
        }

    }

    class Car
    {
        public CarBrands BrandName { get; set; }
        public string TypeOfFailure { get; set; }
        public Car(CarBrands brandName, string typeOfFailure)
        {
            BrandName = brandName;
            TypeOfFailure = typeOfFailure;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Названия бренда: {BrandName,-20} | Тип поломки: {TypeOfFailure,-10}");
        }
    }

    public enum CarBrands
    {
        Toyota,
        Ford,
        Volkswagen,
        Honda,
        Nissan,
        BMW,
        MercedesBenz,
        Audi,
        Kia,
        Hyundai
    }

}


//Задача:
//У вас есть автосервис в который приезжают люди чтобы починить свои автомобили.
//У вашего автосервиса есть баланс денег и склад деталей.
//Когда приезжает автомобиль у него сразу ясна его поломка и эта поломка отображается у вас в консоли вместе с ценой за починку(цена за починку складывается из цены детали + цена за работу).
//Поломка всегда чинится заменой детали, но количество деталей ограничено тем, что находится на вашем складе деталей.
//Если у вас нет нужной детали на складе, то вы можете отказать клиенту и в этом случае вам придется выплатить штраф.
//Если вы замените не ту деталь, то вам придется возместить ущерб клиенту. ???
//За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки.

/*
 * Класс автосервис, класс склад деталей наследуемый.
 * Класс автомобиль 
 * 
 */