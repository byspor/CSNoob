using System;

namespace _5._2_Очередь_в_магазине
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> purchaseQueue = new Queue<int>(10);
            int totalSum = 0;

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                purchaseQueue.Enqueue(rnd.Next(1, 101));
            }




            while (purchaseQueue.Count > 0)
            {
                
                Console.Clear();

                
                Console.WriteLine("Очередь покупок:");
                foreach (var purchase in purchaseQueue)
                {
                    Console.WriteLine(purchase);
                }

                
                Console.WriteLine("\nПредыдущий баланс: {0}", totalSum);

                
                int currentPurchase = purchaseQueue.Dequeue();
                totalSum += currentPurchase;

                
                Console.WriteLine("Текущий баланс: {0}\n", totalSum);

                
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }

            
            Console.WriteLine("Все клиенты обслужены! Финальный баланс: {0}", totalSum);
            Console.ReadKey();
        }
    }
}









//Задача:
//У вас есть множество целых чисел. Каждое целое число это сумма покупки.
//Вам нужно обслуживать клиентов до тех пор пока очередь не станет пуста.
//После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.
//После обслуживания каждого клиента программа ожидает нажатия любой клавиши, после чего затирает консоль и по новой выводит всю информацию, только уже со следующим клиентом