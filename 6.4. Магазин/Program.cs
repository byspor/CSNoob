﻿namespace _6._4._Магазин
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Player player1 = new Player("Max", 1000);

            
            Vendor.Welcome(player1);

        }
    }

    static class Vendor
    {
        private static List<Item> items = new List<Item>() { new Item("banana", 10, 5), new("orange", 20, 3), new("persimmon", 5, 10) };
        private static bool _isOpen = true;

        public static bool IsOpen { get => _isOpen; set => _isOpen = value; }

        public static void ShowProductList()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Наименование: {items[i].Name,-10} | Кол-во товара: {items[i].Value,3} | Цена за 1 штуку: {items[i].Price}");
            }
        }

        public static void Welcome(Player player)
        {
            while (IsOpen)
            {
                Console.WriteLine($"Добро пожаловать в наш магазин\n" +
                    $"Что бы вы хотели сделать у нас в магазине?\n" +
                    $"1. Посмотреть список товаров\n" +
                    $"2. Купить товар\n" +
                    $"3. Посмотреть свой инвентарь\n" +
                    $"4. Покинуть лавку");                
                int numberMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (numberMenu)
                {
                    case 1:
                        ShowProductList();
                        break;
                    case 2:
                        BuyItem(player);
                        break;
                    case 3:
                        player.ShowInventory();
                        break;
                    case 4:
                        IsOpen = false;
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void BuyItem(Player player)
        {
            int numberItem;
            int valueItem;
            Console.Write("Введите номер товара для покупки: ");
            numberItem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите кол-во {items[numberItem - 1].Name} для покупки");
            valueItem = Convert.ToInt32(Console.ReadLine());
            if (valueItem <= items[numberItem - 1].Value)
            {
                if (player.Money >= valueItem * items[numberItem - 1].Price)
                {
                    player.Money -= valueItem * items[numberItem - 1].Price;
                    items[numberItem - 1].Value -= valueItem;
                    player.AddItem(items[numberItem - 1]);
                    Console.WriteLine("Покупка прошла успешно");
                }
                else
                {
                    Console.WriteLine("Недостаточно золота на балансе");
                }
            }
            else
            {
                Console.WriteLine("Столько товара нет в наличии");
            }
        }

    }

    class Player
    {
        List<Item> _buyItems = new List<Item>();
        private string _name;
        private int _money;

        public Player(string name, int money)
        {
            _name = name;
            _money = money;
        }

        public string Name { get => _name; set => _name = value; }
        public int Money { get => _money; set => _money = value; }

        public void AddItem(Item item)
        {
            _buyItems.Add(item);
        }

        public void ShowInventory()
        {
            for (int i = 0; i < _buyItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Наименование: {_buyItems[i].Name,-10} | Кол-во товара: {_buyItems[i].Value,3}");
            }
        }
    }

    class Item
    {
        private string _name;
        private int _value;
        private int _price;

        public string Name { get => _name; private set => _name = value; }
        public int Value { get => _value; set => _value = value; }
        public int Price { get => _price; private set => _price = value; }

        public Item(string name, int value, int price)
        {
            Name = name;
            Value = value;
            Price = price;
        }
    }
}


//Задача:
//Существует продавец, он имеет у себя список товаров и при нужде может вам его показать, также продавец может продать вам товар. После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.

//Возможные классы – игрок, продавец, товар.

//Вы можете сделать так, как вы видите это.