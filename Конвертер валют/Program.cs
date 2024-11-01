using System;

namespace training
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            double balanceRub, balanceEu, balanceDol, countEu, countDol;
            int dol = 100, eu = 120;
            string course = $"Наш курс: DOL = {dol}, EU = {eu}";
            Console.Write("Введите баланс рублей: ");
            balanceRub = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс евро: ");
            balanceEu = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс долларов: ");
            balanceDol = Convert.ToSingle(Console.ReadLine());
            int variant;
            while (true)
            {
                Console.WriteLine($"Ваш баланс RUB = {balanceRub}, EU = {balanceEu}, DOL = {balanceDol}");
                Console.Write("Добрый день, рады видеть в нашем банке.\n" +
                "Мы можем конвертировать следующую валюту:\n" +
                course +
                "\n1. rub => eu\n" +
                "2. eu => rub\n" +
                "3. rub => dol\n" +
                "4. dol => rub\n" +
                "если желаете выйти введите 5\n" +
                "Выполнить операцию: ");
                variant = Convert.ToInt32(Console.ReadLine());
                if (variant == 5)
                {
                    break;
                }
                switch (variant)
                {
                    case 1:
                        Console.Write("Введите кол-во евро: ");
                        countEu = Convert.ToSingle(Console.ReadLine());
                        if (balanceRub < eu * countEu)
                        {
                            Console.WriteLine("Недостаточно средств на балансе, попробуйте другую сумму.");
                            break;
                        }
                        balanceRub -= eu * countEu;
                        balanceEu += countEu;
                        break;
                    case 2:
                        Console.Write("Введите кол-во евро: ");
                        countEu = Convert.ToSingle(Console.ReadLine());
                        if (balanceEu < countEu)
                        {
                            Console.WriteLine("Недостаточно средств на балансе, попробуйте другую сумму.");
                            break;
                        }
                        balanceRub += eu * countEu;
                        balanceEu -= countEu;
                        break;
                    case 3:
                        Console.Write("Введите кол-во долларов: ");
                        countDol = Convert.ToSingle(Console.ReadLine());
                        if (balanceRub < dol * countDol)
                        {
                            Console.WriteLine("Недостаточно средств на балансе, попробуйте другую сумму.");
                            break;
                        }
                        balanceRub -= countDol * dol;
                        balanceDol += countDol;
                        break;
                    case 4:
                        Console.Write("Введите кол-во долларов: ");
                        countDol = Convert.ToSingle(Console.ReadLine());
                        if (balanceDol < countDol)
                        {
                            Console.WriteLine("Недостаточно средств на балансе, попробуйте другую сумму.");
                            break;
                        }
                        balanceRub += dol * countDol;
                        balanceDol -= countDol;
                        break;
                    default:
                        Console.WriteLine("неверная комманда, попробуйте снова");
                        break;
                }
            }
        }
    }
}