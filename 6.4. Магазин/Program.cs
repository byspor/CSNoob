namespace _6._4._Магазин
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
        private static List<Item> items = new List<Item>() { new Item("banana", 10, 5), new("orange", 20, 300), new("persimmon", 5, 10) };
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
                Console.WriteLine($"Добро пожаловать в наш магазин уважаемый | {player.Name, -3} | на вашем счету | {player.Money, -4} |\n" +
                    $"Что бы вы хотели сделать у нас в магазине?\n" +
                    $"1. Посмотреть список товаров\n" +
                    $"2. Купить товар\n" +
                    $"3. Посмотреть свой инвентарь\n" +
                    $"4. Покинуть лавку");
                string inputNumberMenu = Console.ReadLine();
                if (!int.TryParse(inputNumberMenu, out int numberMenu) || numberMenu < 1 || numberMenu > 4)
                {
                    Console.WriteLine("Некорректный номер меню, попробуйте снова");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (numberMenu)
                    {
                        case 1:
                            ShowProductList();
                            break;
                        case 2:
                            BuyItem(player);
                            break;
                        case 3:
                            player.ShowBackpack();
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
        }

        public static void BuyItem(Player player)
        {
            int numberItem;
            int valueItem;
            Console.Write("Введите номер товара для покупки: ");
            string inputNumberItem = Console.ReadLine();
            if (!int.TryParse(inputNumberItem, out numberItem) || numberItem < 1 || numberItem > items.Count)
            {
                Console.WriteLine("Некорректный номер товара, попробуйте снова.");
                return;
            }
            Console.WriteLine($"Введите кол-во {items[numberItem - 1].Name} для покупки");
            string inputValueItem = Console.ReadLine();
            if (!int.TryParse(inputValueItem, out valueItem) || valueItem <= 0)
            {
                Console.WriteLine("Некорректное кол-во товара, попробуйте снова.");
                return;
            }
            if (valueItem <= items[numberItem - 1].Value)
            {
                if (player.Money >= valueItem * items[numberItem - 1].Price)
                {
                    player.Money -= valueItem * items[numberItem - 1].Price;
                    items[numberItem - 1].Value -= valueItem;
                    Item purchasedItem = new Item(items[numberItem - 1].Name, valueItem);
                    player.AddItem(purchasedItem);
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
        internal List<Item> Backpack { get => _buyItems; set => _buyItems = value; }

        public void AddItem(Item item)
        {
            Backpack.Add(item);
        }

        public void ShowBackpack()
        {
            if (Backpack.Count == 0)
            {
                Console.WriteLine("Ваша сумка пуста");
            }
            for (int i = 0; i < Backpack.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Наименование: {Backpack[i].Name,-10} | Кол-во товара: {Backpack[i].Value,3}");
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

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}


//Задача:
//Существует продавец, он имеет у себя список товаров и при нужде может вам его показать, также продавец может продать вам товар. После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.

//Возможные классы – игрок, продавец, товар.

//Вы можете сделать так, как вы видите это.