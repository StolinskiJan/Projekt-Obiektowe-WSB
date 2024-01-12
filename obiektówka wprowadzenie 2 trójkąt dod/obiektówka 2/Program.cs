namespace obiektówka_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = false;
            do
            {
                Console.Write("Podaj dlugosc 1 boku");
                double a;
                while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
                {
                    Console.Write("nieporawidlowe dane. Podaja liczbe wiekszza od zera:");
                }

                Console.Write("Podaj dlugosc 2 boku");
                double b;
                while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
                {
                    Console.Write("nieporawidlowe dane. Podaja liczbe wiekszza od zera:");
                }

                Console.Write("Podaj dlugosc 3 boku");
                double c;
                while (!double.TryParse(Console.ReadLine(), out c) || c <= 0)
                {
                    Console.Write("nieporawidlowe dane. Podaja liczbe wiekszza od zera:");

                }

                if (IsTriangle(a, b, c))
                {
                    double area = CalculateTriangleArea(a, b, c);
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    Console.Write($"\nPodane trójkąta o bokach {a}, {b}, {c} wynosi:"/*{area:F5}cm\u00B2*/);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{area:F5} cm2");
                    Console.ResetColor();
                    isCorrect = true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodane długości boków nie utworzA trójkata");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.Clear();
                }

                static bool IsTriangle(double a, double b, double c)
                {
                    return a + b > c && a + c > b && b + c > a;
                }

                static double CalculateTriangleArea(double a, double b, double c)
                {
                    double p = (a + b + c) / 2;
                    return Math.Sqrt(p * (p - a) + p * (p - b) * (p - c));
                }
            } while (!isCorrect);
            


        }
    }
}