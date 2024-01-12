using System.Media;
using System;
using System.Runtime.CompilerServices;

namespace Obiekt_Dziedziczenie_zad3
{
    abstract class Song
    {
        protected string title;
        protected string artist;
        protected string sound;

        public Song (string title, string artist, string sound)
        {
            this.title = title;
            this.artist = artist;
            this.sound = sound;
        }

        public abstract void Play();
    }

    class Rock : Song
    {
        protected string guitar;

        public Rock (string title, string artist, string guitar) : base(title, artist, "bębny")
        {
            this.guitar = guitar;
        }
        public override void Play ()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {guitar}");
        }
    }
    class Pop : Song
    {
        protected string synth;

        public Pop(string title, string artist, string synth) : base(title, artist, "vokal")
        {
            this.synth = synth;
        }
        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {synth}");
        }
    }
    class Jaz : Song
    {
        protected string saksofon;

        public Jaz(string title, string artist, string saksofon) : base(title, artist, "saksofon")
        {
            this.saksofon = saksofon;
        }
        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {saksofon}");
        }
    }
    

    class Metal : Song
    {
        protected string mguitar;

        public Metal(string title, string artist, string mguitar) : base(title, artist, "bębny")
        {
            this.mguitar = mguitar;
        }
        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {mguitar}");
        }
    }

    class Rap : Song
    {
        protected string guitar;

        public Rap(string title, string artist, string guitar) : base(title, artist, "bębny")
        {
            this.guitar = guitar;
        }
        public override void Play()
        {
            Console.WriteLine($"Odtwarzanie {title} przez {artist}");
            Console.WriteLine($"Dźwięki {sound} {guitar}");
        }
    }



    internal class Program
    {
        /*public static List<Muzyka> users = new List<Muzyka>();
        static void Main(string[] args)
        {
            int option = 0;

            while (option != 4)
            {
                option = DisplayMenu();


                switch (option)
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
        }
    */
    }
}


