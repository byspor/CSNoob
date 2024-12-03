namespace _6._1._Работа_с_классами
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table[] kafe = new Table[3] { new Table(1, 10), new Table(2, 20), new Table(3,30) };

            bool isOpen = true;
            int numberTable;
            int numberPlace;

            while (isOpen)
            {
                Console.WriteLine("Добро пожаловать в кафе ;)");
                
                for (int i = 0; i < kafe.Length; i++)
                {
                    kafe[i].ShowInfo();
                }

                Console.Write("Забронировать столик: ");
                numberTable = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nКол-во мест для брони: "); 
                numberPlace = Convert.ToInt32(Console.ReadLine());

                kafe[numberTable - 1].Reserve(numberTable, numberPlace);                

                Console.ReadKey();
                Console.Clear();

            }
        }
    }

    public class Table
    {
        int _number;
        int _maxPlace;
        int _freePlace;

        public int Number { get => _number; set => _number = value; }

        public Table(int number, int maxPlace) 
        {
            Number = number;
            _maxPlace = maxPlace;
            _freePlace = maxPlace;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Стол - {Number}\n | Кол-во мест - {_freePlace}/{_maxPlace}");
        }

        public void Reserve(int number, int numberPlace)
        {
            if (numberPlace <= _freePlace)
            {
                _freePlace -= numberPlace;
                Console.WriteLine("Места забронированы");
                //return true;
            }
            else 
            {
                Console.WriteLine("Бронь не удалась");
               // return false;
            }
            
        }


    }

}




//Задача:
//Создать класс игрока, с полями содержащими информацию об игроке и методом, который выводит информацию на экран.

//В классе обязательно должен быть конструктор
