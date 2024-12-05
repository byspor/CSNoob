using System.Data;

namespace _7._5._Определение_просрочки
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CanOfStew> canOfStews = new List<CanOfStew>();
            canOfStews.Add(new CanOfStew("Тушенка 'Мясная' ", new DateTime(2022, 1, 1), new DateTime(2020, 1, 1)));
            canOfStews.Add(new CanOfStew("Тушенка 'Охотничья'", new DateTime(2020, 6, 15), new DateTime(2019, 6, 15)));
            canOfStews.Add(new CanOfStew("Тушенка 'Классическая'", new DateTime(2019, 3, 20), new DateTime(2018, 3, 20)));
            canOfStews.Add(new CanOfStew("Тушенка 'Сибирская'", new DateTime(2021, 9, 10), new DateTime(2020, 9, 10)));
            canOfStews.Add(new CanOfStew("Тушенка 'Донская'", new DateTime(2018, 11, 25), new DateTime(2017, 11, 25)));
            canOfStews.Add(new CanOfStew("Тушенка 'Мясная'", new DateTime(2022, 2, 20), new DateTime(2025, 2, 20)));
            canOfStews.Add(new CanOfStew("Тушенка 'Охотничья'", new DateTime(2020, 7, 15), new DateTime(2023, 7, 15)));
            canOfStews.Add(new CanOfStew("Тушенка 'Классическая'", new DateTime(2019, 4, 10), new DateTime(2022, 4, 10)));
            canOfStews.Add(new CanOfStew("Тушенка 'Сибирская'", new DateTime(2021, 10, 5), new DateTime(2024, 10, 5)));
            canOfStews.Add(new CanOfStew("Тушенка 'Донская'", new DateTime(2018, 12, 15), new DateTime(2021, 12, 15)));
            canOfStews.Add(new CanOfStew("Тушенка 'Московская'", new DateTime(2022, 3, 1), new DateTime(2025, 3, 1)));
            canOfStews.Add(new CanOfStew("Тушенка 'Ленинградская'", new DateTime(2020, 8, 20), new DateTime(2023, 8, 20)));
            canOfStews.Add(new CanOfStew("Тушенка 'Кавказская'", new DateTime(2019, 5, 15), new DateTime(2022, 5, 15)));
            canOfStews.Add(new CanOfStew("Тушенка 'Уральская'", new DateTime(2021, 11, 10), new DateTime(2024, 11, 10)));
            canOfStews.Add(new CanOfStew("Тушенка 'Сибирская'", new DateTime(2018, 1, 25), new DateTime(2021, 1, 25)));
            canOfStews.Add(new CanOfStew("Тушенка 'Мясная'", new DateTime(2022, 4, 15), new DateTime(2025, 4, 15)));
            canOfStews.Add(new CanOfStew("Тушенка 'Охотничья'", new DateTime(2020, 9, 10), new DateTime(2023, 9, 10)));
            canOfStews.Add(new CanOfStew("Тушенка 'Классическая'", new DateTime(2019, 6, 20), new DateTime(2022, 6, 20)));
            canOfStews.Add(new CanOfStew("Тушенка 'Сибирская'", new DateTime(2021, 12, 5), new DateTime(2024, 12, 5)));
            canOfStews.Add(new CanOfStew("Тушенка 'Донская'", new DateTime(2018, 2, 15), new DateTime(2021, 2, 15)));

            canOfStews.ForEach(jar => Console.WriteLine(jar));
            
            DateTime currentDate = DateTime.Now;
             
            var expirationCanOfStews = canOfStews.Where(jar => jar.ExpirationDate < currentDate).OrderByDescending(jar => jar.ExpirationDate).ToList();
            Console.WriteLine($"\nАлярма просрочка | Текущая дата: {currentDate.ToString("yyyy-MM-dd"), 78}\n");
            expirationCanOfStews.ForEach(jar => Console.WriteLine(jar));
        }
    }

    record CanOfStew(string Name, DateTime ProductionDate, DateTime ExpirationDate )
    {
        public override string ToString() 
        {
            return $"Название: {Name, -25} | Дата производства: {ProductionDate.ToString("yyyy-MM-dd"), -10} | Дата окончания срока годности: {ExpirationDate.ToString("yyyy-MM-dd"), -10}";
        }
    }
}

//Задача:
//Есть набор тушенки.У тушенки есть название, год производства и срок годности.
//Написать запрос для получения всех просроченных банок тушенки.
//Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.
