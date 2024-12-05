using System.Linq;

namespace _7._3._Анархия_в_больнице
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> patients = new List<Person>();
            patients.Add(new Person("Иванов Иван Иванович", 25, "Грипп"));
            patients.Add(new Person("Петрова Мария Сергеевна", 30, "Пневмония"));
            patients.Add(new Person("Васильев Сергей Михайлович", 40, "Диабет"));
            patients.Add(new Person("Михайлова Елена Васильевна", 28, "Аллергия"));
            patients.Add(new Person("Николаев Алексей Иванович", 35, "Гастрит"));
            patients.Add(new Person("Сергеева Ольга Михайловна", 22, "Тонзиллит"));
            patients.Add(new Person("Иванов Дмитрий Васильевич", 45, "Артериосклероз"));
            patients.Add(new Person("Васильева Наталья Сергеевна", 38, "Пневмония"));
            patients.Add(new Person("Михайлов Владимир Иванович", 50, "Инсульт"));
            patients.Add(new Person("Петрова Юлия Михайловна", 32, "Эндометриоз"));
            patients.Add(new Person("Сергеев Александр Васильевич", 42, "Простатит"));
            patients.Add(new Person("Иванова Екатерина Сергеевна", 29, "Миома"));
            patients.Add(new Person("Васильевич Игорь Михайлович", 48, "Остеохондроз"));
            patients.Add(new Person("Михайлова Татьяна Ивановна", 36, "Гипертония"));
            patients.Add(new Person("Сергеева Светлана Васильевна", 24, "Астма"));
            patients.Add(new Person("Иванович Николай Михайлович", 52, "Сахарный диабет"));
            patients.Add(new Person("Васильева Вера Ивановна", 34, "Экзема"));
            patients.Add(new Person("Михайлович Владимир Сергеевич", 46, "Гепатит"));
            patients.Add(new Person("Сергеева Оксана Михайловна", 26, "Псориаз"));
            patients.Add(new Person("Иванов Денис Васильевич", 44, "Ревматизм"));
            patients.Add(new Person("Сидорова Анна Викторовна", 31, "Грипп"));
            patients.Add(new Person("Кузнецов Алексей Петрович", 29, "Диабет"));
            patients.Add(new Person("Смирнова Наталья Александровна", 37, "Аллергия"));
            patients.Add(new Person("Федоров Сергей Николаевич", 41, "Гастрит"));
            patients.Add(new Person("Лебедева Ольга Андреевна", 33, "Тонзиллит"));
            patients.Add(new Person("Ковалев Дмитрий Сергеевич", 39, "Артериосклероз"));
            patients.Add(new Person("Соловьев Владимир Игоревич", 48, "Инсульт"));
            patients.Add(new Person("Григорьева Юлия Валерьевна", 27, "Эндометриоз"));
            patients.Add(new Person("Тихонов Александр Владимирович", 43, "Простатит"));
            patients.Add(new Person("Кузьмина Екатерина Алексеевна", 30, "Миома"));
            patients.Add(new Person("Семенов Игорь Викторович", 49, "Остеохондроз"));
            patients.Add(new Person("Павлова Татьяна Сергеевна", 35, "Гипертония"));
            patients.Add(new Person("Сидорова Светлана Петровна", 26, "Астма"));
            patients.Add(new Person("Ковалев Николай Андреевич", 53, "Сахарный диабет"));
            patients.Add(new Person("Громова Вера Николаевна", 34, "Экзема"));
            patients.Add(new Person("Смирнов Владимир Анатольевич", 47, "Гепатит"));
            patients.Add(new Person("Лебедев Денис Сергеевич", 45, "Ревматизм"));

            while (true)
            {
                Console.WriteLine("Добро пожаловать. Выберите, что сделать: ");
                Console.WriteLine("1. Отсортировать всех больных по ФИО\n" +
                    "2. Отсортировать всех больных по возрасту\n" +
                    "3. Вывести больных с определенным заболеванием\n");

                if (!(int.TryParse(Console.ReadLine(), out int number) && number > 0 && number < 4))
                {
                    Console.WriteLine("Не корректный ввод. Попробуйте снова.\n");
                }
                else
                {
                    Console.Clear();
                    switch (number)
                    {
                        case 1:
                            var orderPatients = patients.OrderBy(patient => patient.Name).ToList();
                            orderPatients.ForEach(patient => Console.WriteLine(patient));
                            break;
                        case 2:
                            var orderAge = patients.OrderBy(patient => patient.Age).ToList();
                            orderAge.ForEach(patient => Console.WriteLine(patient));
                            break;
                        case 3:
                            var districtPatients = patients.Select(patient => patient.Disease).Distinct().OrderBy(Disease => Disease).ToList();
                            districtPatients.ForEach(patient => Console.WriteLine(patient));
                            Console.WriteLine($"\nВведите заболевание из списка:");
                            string inputDisease = Console.ReadLine();
                            Console.Clear();
                            if ( districtPatients.Any(patient => patient.ToLower() == inputDisease.ToLower()))
                                {
                                var diseasePatients = patients.Where(patient => patient.Disease.ToLower() == inputDisease.ToLower()).ToList();
                                Console.WriteLine($"Все пациенты с заболеванием {inputDisease}\n");
                                diseasePatients.ForEach (patient => Console.WriteLine(patient));
                                Console.WriteLine();
                            }
                            else 
                            {
                                Console.WriteLine("Не корректный ввод заболевания. Попробуйте снова.\n");
                            }

                            break;
                    }
                }
            }
        }

    }

    record Person(string Name, int Age, string Disease)
    {
        public override string ToString()
        {
            return $"Пациент: {Name,-30} | Возраст: {Age,-3} | Заболевание: {Disease,-10}";
        }
    }

}




//Задача:
//У вас есть список больных(минимум 10 записей) +
//Класс больного состоит из полей: ФИО, возраст, заболевание. +
//Требуется написать программу больницы, в которой перед пользователем будет меню со следующими пунктами:
//1)Отсортировать всех больных по фио
//2)Отсортировать всех больных по возрасту
//3)Вывести больных с определенным заболеванием
//(название заболевания вводится пользователем с клавиатуры)