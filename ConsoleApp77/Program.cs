using System;

namespace ConsoleApp77
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a1, b1, c1 coefficients by a space:");
                string[] equation_1 = Console.ReadLine().Trim().Split();
                double a1 = double.Parse(equation_1[0]);
                double b1 = double.Parse(equation_1[1]);
                double c1 = double.Parse(equation_1[2]);
                Console.WriteLine("Enter a2, b2, c2 coefficients by a space:");
                string[] equation_2 = Console.ReadLine().Trim().Split();
                double a2 = double.Parse(equation_2[0]);
                double b2 = double.Parse(equation_2[1]);
                double c2 = double.Parse(equation_2[2]);
                LinearSystem system = new LinearSystem(a1, b1, c1, a2, b2, c2);

                Console.WriteLine("System of equations:");
                Console.WriteLine(system.ToString());

                Console.WriteLine("Get an answer - 1. Check the solution - 2.");
                int ans = int.Parse(Console.ReadLine());
                if (ans == 1)
                {
                    system.Solve();
                }
                else if (ans == 2)
                {
                    Console.WriteLine("Enter x and y:");
                    string[] coef = Console.ReadLine().Trim().Split();
                    double x = double.Parse(coef[0]);
                    double y = double.Parse(coef[1]);
                    Console.WriteLine(system.IsSolution(x, y) ? "Point is a solution" : "Point is not a solution");
                }
                else
                {
                    Console.WriteLine("Unable to process response.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}