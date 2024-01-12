﻿namespace Objekt_wyjątki_10_1_zad_1
{
    class EngineFailureExeption : Exception  //1
    {
        public EngineFailureExeption(string message) : base(message)
        {

        }
    }

    interface IMovable
    {
        void Drive(int distance);
        event EventHandler<Car> Broken;
    }

    class Car : IMovable
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Mileage { get; set; }

        public Car(string brand, string model, string color, int capacity, int mileage)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Capacity = capacity;
            Broken += (sender, args) => Console.WriteLine("Samochód jest zepsuty!");
        }

        public void Drive(int distance)
        {
            Mileage += distance;

            Random random = new Random();
            int num = random.Next(100);   // lub Next(1, 100);

            if (num > 10)
            {
                throw new EngineFailureExeption("Silnik się zepsuł!");
            }
        }

        public event EventHandler<Car> Broken;

        public void OnBroken()
        {
            if (Broken != null)
            {
                Broken(this, this);
            }
        }

        public override string ToString()
        {
            return $"{Brand}, {Model}, {Color}, {Capacity}, {Mileage}";
        }
    }

    class Mechanic
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Mechanic(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public delegate bool Repair(Car c);

        public void PerformRepair(Car c, Repair r)
        {
            bool result = r(c);

            Console.WriteLine($"{Name} {Surname} naprawiał {c.Brand} {c.Model} {(result ?"naprawiony" : "nieprawiony")}");
        }

        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("Ford", "Fiesta", "Czerwony", 1600);
            Car c2 = new Car("Fiat", "126p", "Biały", 650);
            Car c3 = new Car("Ford", "Focus", "Czarny", 1600);

            Mechanic m1 = new Mechanic("Janusz", "Nowak");
            Mechanic m2 = new Mechanic("Anna", "Kowalska");
            Mechanic m3 = new Mechanic("Paweł", "Kowal");

            Mechanic.Repair r1 = c => { c.Capacity += 100; return true; };
            Mechanic.Repair r2 = c => { c.Color = "Zielony"; return true; };
            Mechanic.Repair r3 = c => { return false; };

            List<Car> cars = new List<Car>() { c1, c2, c3 };
            List<Mechanic> mechanic = new List<Mechanic>() { m1, m2, m3 };
            List<Mechanic.Repair> repairs = new List<Mechanic.Repair>() { r1, r2, r3 };


        }
    }
}