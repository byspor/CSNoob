namespace _6._10_Зоопарк
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Aviary> aviaries = new List<Aviary>();
            aviaries.Add(new Aviary("Дикими макаками", 10, "УааААуууАА", Gender.female));
            aviaries.Add(new Aviary("Свирепые пумбы", 1, "Безнадежно крыхтят", Gender.male));
            aviaries.Add(new Aviary("Добродушные тимоны", 1, "Громко попрашайничают", Gender.male));
            aviaries.Add(new Aviary("Одичавшие zuxlet`s", 1, "Кричит \"пое 2 лучшая игра\"", Gender.zadrot));
            aviaries.Add(new Aviary("Змеи", 3, "Шипят", Gender.female));
            aviaries.Add(new Aviary("Непослушные дети", 100, "Майнкрафт это жизнь", Gender.male));            
            
            int number;
            bool isOpne = true;

            while (isOpne)
            {
                Console.WriteLine("Добро пожаловать в удивительный и невероятный ЗООПАРК");
                Console.WriteLine($"На кого вы хотите посмотреть ? Введите номер вольера от 1 до {aviaries.Count}\nЕсли хотите выйти с этого дурдома нажмите 7");
                if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number < aviaries.Count + 1)
                {
                    switch (number)
                    {
                        case 1:
                            aviaries[number - 1].ShowInfo();
                            break;
                        case 2:
                            aviaries[number - 1].ShowInfo();
                            break;
                        case 3:
                            aviaries[number - 1].ShowInfo();
                            break;
                        case 4:
                            aviaries[number - 1].ShowInfo();
                            break;
                        case 5:
                            aviaries[number - 1].ShowInfo();
                            break;
                        case 6:
                            aviaries[number - 1].ShowInfo();
                            break;
                        case 7:
                            isOpne = false;
                            Console.WriteLine("Приходите еще");
                            break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Не корректный ввод, попробуйте снова");                 
                    
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();


            }

           
            

            

            

            //foreach (Aviary aviary in aviaries)
            //{
            //    aviary.ShowInfo();
            //}
        }
    }
}


class Aviary
{
    public Aviary(string name, int value, string sound, Gender gender)
    {
        Name = name;
        Value = value;
        Sound = sound;
        Gender = gender;
    }

    public string Name { get; set; }
    public int Value { get; set; }
    public string Sound { get; set; }
    public Gender Gender { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Вольер с: {Name,-20} | Стая из: {Value,3} | Пол: {Gender,-6} | Издает звук: {Sound}");
    }

}

public enum Gender
{
    female,
    male,
    zadrot
}

//Задача:
//Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать к какому вольеру подойти. 
//При приближении к вольеру пользователю выводится информация о том, что это за вольер, сколько животных там обитает, их пол и какой звук издает животное. +
//Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера. +