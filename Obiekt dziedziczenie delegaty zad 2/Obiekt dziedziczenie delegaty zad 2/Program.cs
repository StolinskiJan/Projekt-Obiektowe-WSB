namespace Obiekt_dziedziczenie_delegaty_7_2_zad_2
{
    delegate bool Logic(bool a, bool b);
    internal class Program
    {
        static bool AND(bool a, bool b) 
        {
            return a && b;
        }
        static bool OR(bool a, bool b)
        {
            return a || b;
        }
        static bool XOR(bool a, bool b)
        {
            return a ^ b;
        }
        static bool NOT(bool a, bool b)
        {
            return !a;
        }

        static void Main(string[] args)
        {
            bool x = GetBoolFromUser();
            bool y = GetBoolFromUser();
            Console.WriteLine();

            DisplayResult(new Logic(AND), x, y);
            DisplayResult(new Logic(OR), x, y);
            DisplayResult(new Logic(XOR), x, y);
            DisplayResult(new Logic(NOT), x, y);
        }

        static void DisplayResult(Logic logic, bool a, bool b)
        {
            try
            {
                bool result = logic(a, b);
                Console.WriteLine($"Wunik {logic.Method.Name} {a} i {b} wynosi {result}");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        static bool GetBoolFromUser() 
        {
            while(true)
            {
                Console.WriteLine("Wprowadż wartość boolowską (true/false):");
                string input = Console.ReadLine();
            }
            
        }
    }
}