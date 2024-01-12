using Prog_obiekt;

namespace Obiekt_zad_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Osoba osoba = new Osoba();
            //osoba.Imie = "Franek";
            //osoba.Nazwisko = "Nowak";

            /*Console.WriteLine(osoba.Imie);*/
            //Console.WriteLine("Nazywam się; {0} {1}", osoba.Imie, osoba.Nazwisko);
            //Console.WriteLine(osoba.ToString());

            //osoba.UstawDane("Janusz", "Kowalski");
            //Console.WriteLine(osoba.Przedstawsie());

            //osoba.Imie ="Franek";
            //osoba.Nazwisko = "Pawlak";
            //Console.WriteLine(osoba.Imie);

            //Console.WriteLine(osoba.Przedstawsie);

            /*16
            Adres adres = new Adres
            {
                Ulica = "Polna",
                NumerDomu = "10",
                NumerMieszkania = "2",
                KodPocztowy = "12-345",
                Miasto = "Poznań",
                Panstwo = "Polska",

            };

            Osoba nowak = new Osoba("Franek", "Kowalski", adres);
            Console.WriteLine(nowak.Przedstawsie());
            */

            Console.Write("Podaj liczbę kontaktów do wprowadzenia");
            int n = int.Parse(Console.ReadLine());

            List<string> imiona = new List<string>();
            List<string> nazwiska = new List<string>();

            for(int i = 1; i < n; i++)
            {
                Console.Write("Podaj imię {i} kontaktu: ");
                string imie = Console.ReadLine();

                imiona.Add(imie);

                Console.Write("Podaj imię {i} kontaktu: ");
                string nazwisko = Console.ReadLine();
                nazwiska.Add(nazwisko);
                Console.WriteLine();
            }

            Console.WriteLine("\nLista kontaktów:");

            for(int i = 0;i < n; i++)
            {
                Console.WriteLine($"{i+1} {imiona[i]} {nazwiska[i]}");

            }
            
        }
    }
}