namespace _5._1._Толковый_словарь
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string>() { "Рыба - Язь", "Насекомое - Комар", "Птица - Курица" };
            List<string> list2 = new List<string>() { "Язь", "Комар", "Курица" };
            string name = " ", result = " ", n;
            bool isOpen = true;


            while (isOpen)
            {
                Console.WriteLine("Слова для поиска:");
                foreach (string item in list1)
                {
                    Console.Write(item + " \n");
                }

                Console.Write("Введите слово: ");
                name = Console.ReadLine();
                name = name.ToLower();

                if (name == "выход")
                {
                    isOpen = false;
                }

                foreach (string item in list1)
                {
                    var k = item.Split(new char[] { ' ' });
                    if (k[0].ToLower() == name)
                    {
                        result = k[2];                        
                    }
                    else
                    {
                        result = "Такого слова нет. Попробуйте снова.";
                    }
                }
                
                Console.WriteLine(result + "\n");


                //for (int i = 0; i < list1.Count; i++)
                //{
                //    if (name == list1[i].ToLower())
                //    {
                //        result = list2[i];
                //        break;
                //    }
                //    else
                //    {
                //        result = "Такого слова нет. Попробуйте снова.";
                //    }
                //}

                //Console.WriteLine(result);
            }
        }
    }
}


/*
 * 
 *Задача:
 *Создать программу, которая принимает от пользователя слово и выводит его значение. Если такого слова нет, то следует вывести соответствующее сообщение.
 * 
 * 
 * 
 * 
 */