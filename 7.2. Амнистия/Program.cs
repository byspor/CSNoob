using System.Linq;
namespace _7._2._Амнистия
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person("Иван Иванов", "Убийство"));
            people.Add(new Person("Петр Петров", "Кража"));
            people.Add(new Person("Александр Смирнов", "Антиправительственное выступление"));
            people.Add(new Person("Михаил Михайлов", "Нарушение общественного порядка"));
            people.Add(new Person("Сергей Сергеев", "Угон автомобиля"));
            people.Add(new Person("Николай Николаев", "Антиправительственное собрание"));
            people.Add(new Person("Дмитрий Дмитриев", "Нападение на полицейского"));
            people.Add(new Person("Владимир Владимиров", "Кража со взломом"));
            people.Add(new Person("Андрей Андреев", "Антиправительственное заявление"));
            people.Add(new Person("Константин Константинов", "Угроза убийством"));
            people.Add(new Person("Олег Олегов", "Нарушение правил дорожного движения"));
            people.Add(new Person("Игорь Игорев", "Антиправительственное движение"));
            people.Add(new Person("Василий Васильев", "Уничтожение имущества"));
            people.Add(new Person("Георгий Георгиев", "Кража личных данных"));
            people.Add(new Person("Леонид Леонидов", "Антиправительственное выступление на митинге"));
            people.Add(new Person("Юрий Юрьев", "Нарушение правил эксплуатации оружия"));
            people.Add(new Person("Виктор Викторов", "Угон самолета"));
            people.Add(new Person("Анатолий Анатольев", "Антиправительственное заявление в социальных сетях"));
            people.Add(new Person("Борис Борисов", "Нападение на государственное учреждение"));
            people.Add(new Person("Геннадий Геннадиев", "Антиправительственное собрание в парке"));
            
            people.ForEach(person => person.ShowInfo());

            people.RemoveAll(person => person.Offence.StartsWith("Антиправительственное"));

            //var amnesty = people.Where(person => !person.Offence.StartsWith("Антиправительственное")).ToList();
            //amnesty.ForEach(person => person.ShowInfo());

            Console.WriteLine();
            people.ForEach(person => person.ShowInfo());            

        }
    }


    record Person(string Name, string Offence)
    {
        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name,-25} | Преступление: {Offence,-30}");
        }
    }

    //class Person

    //{
    //    public Person(string name, string offence)
    //    {
    //        Name = name;
    //        Offence = offence;
    //    }

    //    public string Name { get; set; }
    //    public string Offence { get; set; }

    //    public void ShowInfo()
    //    {
    //        Console.WriteLine($"ФИО: {Name,-20} | Преступление: {Offence,-30}");
    //    }
    //}
}

//Задача:
//В нашей великой стране Арстоцка произошла амнистия!
//Всех людей заключенных за преступление "Антиправительственное" следует исключить из списка заключенных. 
//Есть список заключенных, каждый заключенный состоит из полей: ФИО, преступление. +
//Вывести список до амнистии и после.