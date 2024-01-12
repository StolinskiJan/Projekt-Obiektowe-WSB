//•1	Napisz program w języku C#, który ilustruje pojęcia programowania obiektowego, takie jak klasy, dziedziczenie, pola, właściwości i metody.
//•2	Zdefiniuj klasę bazową Person, która ma pola name, surname i dateOfBirth oraz konstruktor przyjmujący te wartości jako parametry.
//•3	Dodaj do klasy Person metodę GetFullName, która zwraca pełne imię i nazwisko osoby, oraz właściwość Age, która oblicza wiek osoby na podstawie daty urodzenia.
//•4	Zdefiniuj klasę Address, która ma pola city, street, houseNumber i postalCode jako właściwości oraz konstruktor przyjmujący te wartości jako parametry.
//•5	Dodaj do klasy Person pole address typu Address i zmodyfikuj konstruktor klasy Person, aby przyjmował obiekt klasy Address jako parametr.
//•6	Zdefiniuj klasę pochodną Student, która dziedziczy po klasie Person i ma dodatkowe pole studentNumber oraz konstruktor przyjmujący te wartości jako parametry.
//•7	Zdefiniuj klasę pochodną Teacher, która dziedziczy po klasie Person i ma dodatkowe pole subjects typu List<string> oraz konstruktor przyjmujący te wartości jako parametry.
//•8	Utwórz obiekty każdej klasy, używając słowa kluczowego new i podając odpowiednie wartości w konstruktorach.
//•9	Wyświetl dane utworzonych obiektów, używając metody Console.WriteLine i właściwości obiektów.

//Menu:
//1 Aby dodać do zadania menu, które umożliwia dodawanie użytkowników i
//zapamiętanie ich w pamięci, a następnie odczyt wprowadzonych użytkowników,
//możesz użyć następujących kroków:
//2 Utwórz zmienną typu List<Person>, która będzie przechowywać listę użytkowników.
//3 Utwórz metodę DisplayMenu, która będzie wyświetlać opcje menu na konsoli i
//zwracać wybraną opcję jako liczbę całkowitą.
//4 Utwórz metodę AddUser, która będzie pobierać dane użytkownika z konsoli i
//dodawać je do listy użytkowników.
//5 Utwórz metodę DisplayUsers, która będzie wyświetlać dane użytkowników z listy na
//konsoli.
//6 Utwórz metodę Main, która będzie używać pętli while do wyświetlania menu i
//wykonywania odpowiednich akcji w zależności od wybranej opcji.



//3zad dodatkowo_studenci_nauczyciele
// 1 Zmodyfikuj metodę DisplayMenu, aby dodać nowe opcje menu dla dodawania i
//wyświetlania studentów i nauczycieli. Możesz też zmienić nazwę opcji dla
//dodawania i wyświetlania osób na "Dodaj osobę" i "Wyświetl osoby".
//2 Zmodyfikuj metodę AddUser, aby zapytać użytkownika, czy chce dodać osobę,
//studenta czy nauczyciela, i w zależności od odpowiedzi utworzyć odpowiedni
//obiekt klasy Person, Student lub Teacher. Możesz też poprosić użytkownika o
//podanie dodatkowych danych, takich jak numer indeksu dla studenta lub lista
//przedmiotów dla nauczyciela.
//3 Zmodyfikuj metodę DisplayUsers, aby zapytać użytkownika, czy chce wyświetlić
//wszystkich użytkowników, tylko studentów, tylko nauczycieli czy tylko osoby.
//Możesz też użyć instrukcji if lub switch do sprawdzenia typu obiektu i wyświetlenia
//odpowiednich danych.


namespace Obiekt_dziedziczenie_6_meniu
{
    class Person  // to co facet zrobił
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, DateTime dateOfBirth, Address address) : this(name, surname, dateOfBirth)
        {
            this.Address = address;
        }

        public string GetFullName()
        {
            return Name + " " + Surname;
        }

        public int Age
        {
            get
            {
                TimeSpan difference = DateTime.Now - DateOfBirth;
                return (int)(difference.Days / 365.25);
            }
        }
    }

    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }

        public Address(string city, string street, string houseNumber, string postalCode)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
        }
    }

    class Student : Person
    {
        public int StudentNumber { get; set; }
        public Student(string name, string surname, DateTime dateOfBirth, int studentNumber) : base(name, surname, dateOfBirth)
        {
            this.StudentNumber = studentNumber;
        }
    }

    class Teacher : Person
    {
        public List<string> Subjects { get; set; }
        public Teacher(string name, string surname, DateTime dateOfBirth, List<string> subjects) : base(name, surname, dateOfBirth)
        {
            Subjects = subjects;
        }
    }
    internal class Program
    {
        public static List<Person> users = new List<Person>(); //M2
        static void Main(string[] args)
        {

            int option = 0; //M6

            while (option != 4) //M6
            {
                option = DisplayMenu();
                //Console.WriteLine(option);

                switch(option) //M6
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        DisplayUsers();
                        break;
                    case 3:
                        users.Clear();
                        Console.WriteLine("\nWszyscy użytkownicy zostali usunięci\n");
                        break;
                    case 4:
                        Console.WriteLine("\nDziękujemy za skorzystanie z programu.\n");
                        break;
                    default:
                        Console.WriteLine("\nNieprawidłowa opcja. Spróbuj ponownie.\n");
                        break;
                }
            }
            /*
             * Person p1 = new Person("Janusz", "Nowak", new DateTime(2000, 1, 10), new Address("Poznań", "Polna", "10", "12-345"));

            Student s1 = new Student("Jan", "Kowalski", new DateTime(2001, 2, 13), 12345);

            Teacher t1 = new Teacher("Anna", "Nowak", new DateTime(1998, 10, 5), new List<string>() { "Matematyka", "Programowanie obiektowe" });

            Console.WriteLine($"\nOSOBA:\nImię: {p1.Name}, nazwisko: {p1.Surname}, Data urodzenia:" +
                $" {p1.DateOfBirth.ToShortDateString()} r., adres: {p1.Address.City}, ulica: {p1.Address.Street}" +
                $" {p1.Address.HouseNumber}, {p1.Address.PostalCode}");

            Console.WriteLine($"\nSTUDENT:\nImię: {s1.Name}, nazwisko: {s1.Surname}, Data urodzenia:" +
                $" {s1.DateOfBirth.ToShortDateString()} r., indeks: {s1.StudentNumber}");

            Console.WriteLine($"\nNAUCZYCIEL:\nImię: {t1.Name}, nazwisko: {t1.Surname}, Data urodzenia:" +
                $" {t1.DateOfBirth.ToShortDateString()} r., nauczane przedmioty: {string.Join(", ", t1.Subjects)}");
            */
        }

        public static int DisplayMenu() //M3
        {
            Console.WriteLine("program do zarządzania użytkownikami\n");
            Console.WriteLine("1: Dodaj użytkownika");
            Console.WriteLine("2: Wyświetl użytkowników");
            Console.WriteLine("3: Usuń wszystkich użytkowników");
            Console.WriteLine("4: Wyjdż z programu");
            Console.WriteLine("\nWybierz opcię:");
            return int.Parse( Console.ReadLine() );
        }

        public static void AddUser() //M4
        {
            Console.WriteLine("Podaj imię użytkownika:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko użytkownika:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Podaj datę urodzenia użytkownika (RRRR-MM-DD)");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Person user = new Person(firstName, lastName, dateOfBirth);
            users.Add(user);

            Console.WriteLine($"Użytkownik {firstName}{lastName}zastał dodany.");
        }

        public static void DisplayUsers() //5
        {
            Console.Clear();
            if (users.Count == 0)
            {
                Console.WriteLine("\nNie ma żadnych użytkowników\n");
            }
            else
            {
                Console.WriteLine("\nLista użytkowników:\n");

                int count = 1;
                foreach (Person user in users)
                {
                    Console.WriteLine($"Użytkownik {count}:");
                    Console.WriteLine($"Imię i nazwisko: {user.Name} {user.Surname}\n Data urodzenia: {user.DateOfBirth.ToShortDateString()}\n");
                    count++;
                }
            }
        }
    }
}



















/*  to co facet dał na samym początku bez przer
 * {
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, DateTime dateOfBirth, Address address) : this(name, surname, dateOfBirth)
        {
            this.Address = address;
        }

        public string GetFullName()
        {
            return Name + " " + Surname;
        }

        public int Age
        {
            get
            {
                TimeSpan difference = DateTime.Now - DateOfBirth;
                return (int)(difference.Days / 365.25);
            }
        }
    }

    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }

        public Address (string city, string street, string houseNumber, string postalCode)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
        }
    }

    class Student : Person
    {
        public int StudentNumber { get; set; }
        public Student(string name, string surname, DateTime dateOfBirth, int studentNumber) : base(name, surname, dateOfBirth)
        {
            this.StudentNumber = studentNumber;
        }
    }

    class Teacher : Person
    {
        public List<string> Subjects { get; set; }
        public Teacher(string name, string surname, DateTime dateOfBirth, List<string> subjects) : base(name, surname, dateOfBirth)
        {
            Subjects = subjects;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Janusz", "Nowak", new DateTime(2000, 1, 10), new Address("Poznań", "Polna", "10", "12-345"));

            Student s1 = new Student("Jan", "Kowalski", new DateTime(2001, 2, 13), 12345);

            Teacher t1 = new Teacher("Anna", "Nowak", new DateTime(1998, 10, 5), new List<string>() {"Matematyka", "Programowanie obiektowe"});

            Console.WriteLine($"\nOSOBA:\nImię: {p1.Name}, nazwisko: {p1.Surname}, Data urodzenia: {p1.DateOfBirth.ToShortDateString()} r., adres: {p1.Address.City}, ulica: {p1.Address.Street} {p1.Address.HouseNumber}, {p1.Address.PostalCode}");

            Console.WriteLine($"\nSTUDENT:\nImię: {s1.Name}, nazwisko: {s1.Surname}, Data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., indeks: {s1.StudentNumber}");

            Console.WriteLine($"\nNAUCZYCIEL:\nImię: {t1.Name}, nazwisko: {t1.Surname}, Data urodzenia: {t1.DateOfBirth.ToShortDateString()} r., nauczane przedmioty: {string.Join(", ", t1.Subjects)}");
        }
    }
}
*/