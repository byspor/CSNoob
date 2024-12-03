namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Задача:
Написать конвертер валют (3 валюты).

У пользователя есть баланс в каждой из представленных валют. Он может попросить сконвертировать часть баланса в одной валюты в другую. 
Тогда у него с баланса одной валюты снимет X и зачислится на баланс другой Y. Курс конвертации должен быть просто прописан в программе.

Программа должна завершиться тогда, когда это решит пользователь.*/
            var rubUSD = 100.0;
            var usdRUB = 0.01;
            var rubYEN = 50.00;
            var yenRUB = 0.02;
            var usdYEN = 2.00;
            var yenUSD = 0.50;
            Console.Write("Сколько у вас рублей:");
            var rubHave = Convert.ToDouble(Console.ReadLine());
            Console.Write("Сколько у вас долларов:");
            var usdHave = Convert.ToDouble(Console.ReadLine());
            Console.Write("Сколько у вас йен:");
            var yenHave = Convert.ToDouble(Console.ReadLine());
            var okey = 0;
            while (true)
            {
                Console.WriteLine("Что вы хотите конвертировать:/n1. Рубли/n2.Доллары/n3.Йены");
                var convVALUTE = int.Parse(Console.ReadLine());
                Console.WriteLine("В какую валюту вы хотите конвретировать:/n1. Рубли/n2.Доллары\n3.Йены");
                var toCONVERT = int.Parse(Console.ReadLine());
                Console.Write("Сколько вы хотите сконвертировать:");
                var countCONV = Convert.ToDouble(Console.ReadLine());
                switch (convVALUTE)
                {
                    case 1:
                        switch (toCONVERT)
                        {
                            case 1:
                                Console.Write($"Вы хотите конвертировать рубли в рубли. Комисия составит 10%. На вашем счету будет {rubHave - (countCONV * 1.1)} рублей. Подтверждаете перевод: 1.да 2.нет");
                                okey = int.Parse(Console.ReadLine());
                                if (okey == 1)
                                {
                                    rubHave -= countCONV * 1.1;
                                }
                                Console.WriteLine("Попробуйте еще раз!");
                                continue;
                            case 2:
                                Console.Write($"Вы хотите конвертировать рубли в доллары. Комисия составит 10%. На вашем счету будет {rubHave - countCONV * 1.1} рублей и {usdHave + countCONV * rubUSD} долларов. Подтверждаете перевод: 1.да 2.нет");
                                okey = int.Parse(Console.ReadLine());
                                if (okey == 1)
                                {
                                    rubHave -= countCONV * 1.1;
                                    usdHave += countCONV * rubUSD;
                                }
                                else
                                    Console.WriteLine("Попробуйте еще раз!");
                                continue;
                            case 3:
                                Console.Write($"Вы хотите конвертировать рубли в йены. Комисия составит 10%. На вашем счету будет {rubHave - countCONV * 1.1} рублей и {usdHave + countCONV * rubUSD} йен. Подтверждаете перевод: 1.да 2.нет");
                                okey = int.Parse(Console.ReadLine());
                                if (okey == 1)
                                {
                                    rubHave -= countCONV * 1.1;
                                    yenHave += countCONV * rubYEN;
                                }
                                else
                                    Console.WriteLine("Попробуйте еще раз!");
                                continue;
                        }
                        break;
                    case 2:
                        switch (toCONVERT)
                        {
                            case 2:
                                Console.Write($"Вы хотите конвертировать доллары в рубли. Комисия составит 10%. На вашем счету будет {usdHave - (countCONV * 1.1)} долларов. Подтверждаете перевод: 1.да 2.нет");
                                okey = int.Parse(Console.ReadLine());
                                if (okey == 1)
                                {
                                    usdHave -= countCONV * 1.1;
                                }
                                Console.WriteLine("Попробуйте еще раз!");
                                continue;
                            case 1:
                                Console.Write($"Вы хотите конвертировать доллары в доллары. Комисия составит 10%. На вашем счету будет {usdHave - countCONV * 1.1} долларов и {rubHave + countCONV * usdRUB} долларов. Подтверждаете перевод: 1.да 2.нет");
                                okey = int.Parse(Console.ReadLine());
                                if (okey == 1)
                                {
                                    usdHave -= countCONV * 1.1;
                                    rubHave += countCONV * usdRUB;
                                }
                                else
                                    Console.WriteLine("Попробуйте еще раз!");
                                continue;
                            case 3:
                                Console.Write($"Вы хотите конвертировать доллары в йены. Комисия составит 10%. На вашем счету будет {usdHave - countCONV * 1.1} долларов и {yenHave + countCONV * usdYEN} йен. Подтверждаете перевод: 1.да 2.нет");
                                okey = int.Parse(Console.ReadLine());
                                if (okey == 1)
                                {
                                    usdHave -= countCONV * 1.1;
                                    yenHave += countCONV * usdYEN;
                                }
                                else
                                    Console.WriteLine("Попробуйте еще раз!");
                                continue;
                        }
                        break;
                }
            }



        }
    }
}
