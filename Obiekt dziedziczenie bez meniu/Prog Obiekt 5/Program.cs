//•1	Napisz program w języku C#, który ilustruje pojęcia programowania obiektowego, takie jak klasy, dziedziczenie, pola, właściwości i metody.
//•2	Zdefiniuj klasę bazową Person, która ma pola name, surname i dateOfBirth oraz konstruktor przyjmujący te wartości jako parametry.
//•3	Dodaj do klasy Person metodę GetFullName, która zwraca pełne imię i nazwisko osoby, oraz właściwość Age, która oblicza wiek osoby na podstawie daty urodzenia.
//•4	Zdefiniuj klasę Address, która ma pola city, street, houseNumber i postalCode jako właściwości oraz konstruktor przyjmujący te wartości jako parametry.
//•5	Dodaj do klasy Person pole address typu Address i zmodyfikuj konstruktor klasy Person, aby przyjmował obiekt klasy Address jako parametr.
//•6	Zdefiniuj klasę pochodną Student, która dziedziczy po klasie Person i ma dodatkowe pole studentNumber oraz konstruktor przyjmujący te wartości jako parametry.
//•7	Zdefiniuj klasę pochodną Teacher, która dziedziczy po klasie Person i ma dodatkowe pole subjects typu List<string> oraz konstruktor przyjmujący te wartości jako parametry.
//•8	Utwórz obiekty każdej klasy, używając słowa kluczowego new i podając odpowiednie wartości w konstruktorach.
//•9	Wyświetl dane utworzonych obiektów, używając metody Console.WriteLine i właściwości obiektów.
namespace Prog_Obiekt_5
{
    class Person
    {


        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfbirth { get; set; }
        public Address Address { get; set; } //4

        public Person(string name, string surname, DateTime dateOfBirth) 
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfbirth = dateOfBirth;
        }

        public Person(string name, string surname, DateTime dateOfBirth, Address address) : this(name, surname, dateOfBirth) //5
        {
            this.Address = address;
        }

        public string getFullName() //3{
        {
            return Name + " " + Surname;
        }

        /*public int Age //3 Możliwe 
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                    age--;
                return age;
            }
        }*/

        public int Age //3
        {
            get
            {
                TimeSpan difference = DateTime.Now - DateOfbirth;
                return (int)(difference.Days / 365.25);
            }
        }


    }
    class Address //4
    {
        public string City { get; set; }
        public string State { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }

        public Address (string city, string state, string houseNumber, string postalCode)
        {
            this.City = city;
            this.State = state;
            this.HouseNumber = houseNumber;
            this.PostalCode = postalCode;
        }
    }

    class Student : Person   //6
    {
        public string StudentNumber { get; set; }
        public Student(string name, string surname, DateTime dateOfBirth, string studenytNumber) : base (name, surname, dateOfBirth)
        {
            this.StudentNumber = studentNumber;
            
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}