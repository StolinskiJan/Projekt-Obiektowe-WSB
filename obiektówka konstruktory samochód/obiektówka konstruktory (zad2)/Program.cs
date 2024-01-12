using System.ComponentModel.Design;
using System.Data;

namespace obiektówka_konstruktory__zad2_zaj4
{
    internal class Program
    {
        class Car
        {
            public string Brand { get; set; } //9
            public string Model { get; set; }
            public Engine silnik { get; set; }

            public Car(string brand, string model, Engine silnik) //10
            {
                this.Brand = brand;
                this.Model = model;
                this.silnik = silnik;
            }

            public Car(string brand, string model, double capacity, double fuelAmount) //10
            {
                this.Brand = brand;
                this.Model = model;
                this.silnik.Capacity = capacity;
                this.silnik.FuelAmount = fuelAmount;
            }
            public Car(string brand, string model, double capacity, double fuelAmount, double fuelTankCapacity)/*:this( brand,  model,  capacity,  fuelAmount)*/ //10
            {
                //this.silnik.FuelTankCapacity = fuelTankCapacity;
                this.Brand = brand;
                this.Model = model;
                this.silnik = new Engine(capacity, fuelAmount, fuelTankCapacity);
            }
            public void Drive(int distance) //9
            {
                Console.WriteLine("Jadę");
                int time = distance * 100;
                Thread.Sleep(time);
                silnik.Work(distance);

            }

            public void Refuel(double fuelAmount) //12
            {
                if (silnik.FuelAmount + fuelAmount > silnik.FuelTankCapacity)
                    throw new Exception("Za duża paliwa");
                silnik.FuelAmount += fuelAmount;
            }

        }

        public void ShowCar()
        {
            Console.WriteLine($"Marka: {Brand}, model: {Model}\nPojemność silnika:" +
                    $"{Engine.silnik.Capacity}, ilość paliwa: {Engine.silnik.FuelAmount}, Pojemnośćbaku:" +
                    $"{Engine.silnik.FuelTankCapacity}\n\n"););
        }


        class Engine
        {
            public double Capacity { get; set; } //3
            public double FuelAmount { get; set; }
            public double FuelTankCapacity { get; } = 50.0;



            public Engine(double capacity, double fuelAmount)
            {
                this.Capacity = capacity;
                this.FuelAmount = fuelAmount;
                this.FuelTankCapacity = 40.0;
            }

            public Engine(double capacity, double fuelAmount, double fuelTankCapacity) : this(capacity, fuelAmount) //5
            {

                this.FuelTankCapacity = fuelTankCapacity;
            }



            public static double COnsvertLinersPer100KmToMilesPerGallon(double literesPer100Km)
            {
                return 235.214583 / literesPer100Km;
            }
            public static double COnsvertsMilesPerGallonToLinersPer100Km(double milesPerGallon)
            {
                return 235.214583 / milesPerGallon;
            }

            /*public void Work(int distance) //9
            {
                double fuelConsumption = Capacity *  4 / 100;
                if (fuelConsumption * distance <= FuelAmount)
                {
                    FuelAmount -= fuelConsumption * distance;
                    Console.WriteLine("Jestem");
                    
                }
                else
                {
                    Console.WriteLine("Brak paliwa na dojazd do celu");
                    
                }
            }*/
            public void Work(int distance) //9
            {
                double fuelConsumption = (Capacity * distance, 4) / 100;
                if (FuelAmount < fuelConsumption)
                    throw new Exception("Brak paliwa");

                FuelAmount -= fuelConsumption * distance;
                Console.WriteLine("Jestem");


            }
            static void Main(string[] args)
            {
                Console.WriteLine(Program.Engine.COnsvertLinersPer100KmToMilesPerGallon(8)); // 29.401822875
                Console.WriteLine(Program.Engine.COnsvertsMilesPerGallonToLinersPer100Km(29.401822875));

                Engine e = new Engine(1, 25.5); //6
                Console.WriteLine(e.FuelTankCapacity); //40

                Engine e2 = new Engine(1, 20, 30); //8
                Console.WriteLine(e2.FuelTankCapacity); //30

                Console.WriteLine("\n###############\n\n");

                Car Engine = new Car("Fiat", "126p", 1, 20, 40); //11
                Console.WriteLine($"Marka: {Engine.Brand}, model: {Engine.Model}\nPojemność silnika:" +
                    $"{Engine.silnik.Capacity}, ilość paliwa: {Engine.silnik.FuelAmount}, Pojemnośćbaku:" +
                    $"{Engine.silnik.FuelTankCapacity}\n\n");

                Engine.Drive(100);

                Console.WriteLine($"\nIlość paliwa: {Engine.silnik.FuelAmount}\n\n");

                Engine.Refuel(7);
                Console.WriteLine($"\nIlość paliwa: {Engine.silnik.FuelAmount}\n\n");


                Console.Clear(); //13
                Console.WriteLine("Witamy w symulatorze jazdy ssamochodem"); //13

                Console.Write("Podaj markę samochodu:");
                string brand = Console.ReadLine();

                Console.Write("Podaj model samochodu:");
                string model = Console.ReadLine();

                Console.Write("Podaj pojemność samochodu (w litrach):");
                double capacity = double.Parse(Console.ReadLine());

                Console.Write("Podaj ilość paliwa samochodu(w litrach):");
                double fuelAmount = double.Parse(Console.ReadLine());

                Console.Write("Podaj pojemność baku samochodu(w litrach):");
                double fuelTankCapacity = double.Parse(Console.ReadLine());

                Car c = new Car(brand, model, capacity, fuelAmount, fuelTankCapacity);

                Thread.Sleep(2000);
                Console.Clear();

                while (true) //13
                {
                    Console.WriteLine("1: Jadę");
                    Console.WriteLine("2: Tankuję");
                    Console.WriteLine("3: Ile mam paliwa");
                    Console.WriteLine("4: Dane mojego auta");
                    Console.WriteLine("5: Wujście z programu");

                    Console.Write("\n\nWybierz opciE:");
                    int choice = int.Parse(Console.ReadLine());

                    
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Podaj dystans do przejechania (w kilometrach):");
                            int distance = int.Parse(Console.ReadLine());
                            c.Drive(distance);
                            break;

                        case 2:
                            Console.WriteLine("Podaj paliwa do zatankowania ( w litrach ):");
                            double fuelToAdd = int.Parse(Console.ReadLine());
                            c.Refuel(fuelToAdd );
                            break;

                        case 3:
                            Console.WriteLine($"Ilość paliwa w zbiorniku ( w litrach ): {c.Engine.FuelAmount}");
                            
                            break;
                        case 4:
                            Console.WriteLine("Dane auta"):
                            c.ShowCar();
                            break;
                        case 5:
                            Console.WriteLine("Koniec");
                            return;
                        default: Console.WriteLine("nieprawidlowy wybór");
                            break;
                    }


                }

            }
        } 
    }

}
// baz pod 4