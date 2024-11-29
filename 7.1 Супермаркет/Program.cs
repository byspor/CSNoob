namespace _7._1_Супермаркет
{
    internal class Program
    {
        static void Main(string[] args)
        {
                        
            List<Buyer> buyers = new List<Buyer>();
            buyers.Add(new Buyer(400, "Max"));
            buyers.Add(new Buyer(1000, "Alex"));
            buyers.Add(new Buyer(800, "Pedro"));
            buyers.Add(new Buyer(2000, "Svetlana"));
            buyers.Add(new Buyer(900, "Valentina"));

            List<Product> products = new List<Product>();
            products.Add(new Product("Orange", 100));
            products.Add(new Product("Banana", 200));
            products.Add(new Product("Lemon", 150));
            products.Add(new Product("Cherry", 300));
            products.Add(new Product("Strawberries", 500));

            foreach (var buyer in buyers)
            {
                for (int i = 0; i < Random.Shared.Next(3, 10); i++)
                {
                    buyer.basket.Add(products[Random.Shared.Next(0, products.Count)]);
                }                
            }

            Console.WriteLine("До оплаты:");
            foreach (var buyer in buyers)
            {
                Console.WriteLine($"Покупатель - {buyer.Name,-10} | На карте: {buyer.Money,-5}\n\tКорзина товаров:\n");
                buyer.InfoBasket();
                Console.WriteLine();
            }




            foreach (var buyer in buyers)
            {
                int i = 0;
                while (i < buyer.basket.Count)
                {
                    if (buyer.Money >= buyer.basket[i].Price)
                    {
                        buyer.Money -= buyer.basket[i].Price;
                        i++;
                    }
                    else
                    {
                        buyer.basket.RemoveAt(i);
                    }
                }
            }

            Console.WriteLine("После оплаты:");
            foreach (var buyer in buyers)
            {
                Console.WriteLine($"Покупатель - {buyer.Name,-10} | На карте: {buyer.Money,-5}\n\tКорзина товаров:\n");
                buyer.InfoBasket();
                Console.WriteLine();
            }


        }
    }
}

class Buyer
{
    public List<Product> basket = new List<Product>();

    public Buyer(float money, string name)
    {
        Money = money;
        Name = name;
    }

    public float Money { get; set; }
    public string Name { get; set; }

    public void BuyProduct(Product product)
    {
        basket.Add(product);
    }

    public void InfoBasket()
    {
        foreach (Product product in basket)
        {
            Console.WriteLine($"Наименование: {product.Name, -15} | Цена: {product.Price, -5}");
        }
    }  

}

class Product
{
    public Product(string name, float price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public float Price { get; set; }
    
}




//Задача:
//Написать программу администрирования супермаркетом.
//В супермаркете есть очередь клиентов.
//У каждого клиента в корзине есть товары, также у клиентов есть деньги.
//Клиент когда подходит на кассу получает итоговую сумму покупки и старается её оплатить.
//Если оплатить клиент не может, то он рандомный товар из корзины выкидывает до тех пор пока его денег не хватит для оплаты.
//Клиентов можно делать ограниченное число на старте программы.
