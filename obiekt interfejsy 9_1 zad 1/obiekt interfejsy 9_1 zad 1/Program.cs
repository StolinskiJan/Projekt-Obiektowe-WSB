namespace obiekt_interfejsy_9_1_zad_1
{
    class Book : IComparable<Book>  //1:2
    {

        string title; //1
        public string author;
        public int yearOfPublication;
        public double price;

        public Book(string title, string author, int yearOfPublication, double price) //3
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }

        //public int CompareTo([AllowNull] Book other) //2
        public int CompareTo(Book? other)  //to samo
        {
            if (other == null) return 1;
            return price.CompareTo(other.price);
        }
        public override string ToString() //4
        {
            return $"{title}, {author}, {yearOfPublication}, {price} zł";
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>(); //5

            books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
            books.Add(new Book("Hobbit2", "Pawlak", 2000, 145.99));
            books.Add(new Book("Hobbit3", "Antosiak", 2000, 5.99));
            books.Add(new Book("Hobbit4", "Antosiak", 1948, 5.99));

            Console.WriteLine("Lista książek:"); 
            foreach (Book book in books)//5
            {
                Console.WriteLine(book);
            }
            Console.WriteLine(); //6

            books.Sort();//6
            Console.WriteLine("Posortowana lista książek:");

            foreach(Book book in books)//6
            {
                //Console.WriteLine(book.ToString());
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie według daty publikacji:"); //7
            var sortedByYear = books.OrderBy(b => b.yearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie według autor");
            var sortedByAuthorDesc = books.OrderByDescending(b => b.author);
            foreach (Book book in sortedByAuthorDesc)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie według ceny nierosnąco a następnie według roku od najstarszej książki");
            var sortedByPricedescAndYear = books.OrderByDescending(b =>b.price).ThenBy(b => b.yearOfPublication);
            foreach (Book book in sortedByPricedescAndYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
        }
    }
}