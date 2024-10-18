using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp77
{
    class LinearSystem
    {
        private double[,] coefficients = new double[2, 3];

        // конструктор
        public LinearSystem(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            coefficients[0, 0] = a1; coefficients[0, 1] = b1; coefficients[0, 2] = c1;
            coefficients[1, 0] = a2; coefficients[1, 1] = b2; coefficients[1, 2] = c2;
        }
        // індексатор
        public double this[int equationIndex, int coefficientIndex]
        {
            get
            {
                if (equationIndex < 0 || equationIndex > 1 || coefficientIndex < 0 || coefficientIndex > 2)
                    throw new ArgumentOutOfRangeException();
                return coefficients[equationIndex, coefficientIndex];
            }
            set
            {
                if (equationIndex < 0 || equationIndex > 1 || coefficientIndex < 0 || coefficientIndex > 2)
                    throw new ArgumentOutOfRangeException();
                coefficients[equationIndex, coefficientIndex] = value;
            }
        }

        public override string ToString()
        {
            return $"{coefficients[0, 0]}x + {coefficients[0, 1]}y = {coefficients[0, 2]}\n" +
                   $"{coefficients[1, 0]}x + {coefficients[1, 1]}y = {coefficients[1, 2]}";
        }

        // метод для розв'язку системи методом Гаусса
        public void Solve()
        {
            double[,] augmentedMatrix = (double[,])coefficients.Clone();

            // прямий хід
            double factor = augmentedMatrix[1, 0] / augmentedMatrix[0, 0];
            for (int j = 0; j < 3; j++)
            {
                augmentedMatrix[1, j] -= factor * augmentedMatrix[0, j];
            }

            if (Math.Abs(augmentedMatrix[1, 1]) < 1e-6)
            {
                if (Math.Abs(augmentedMatrix[1, 2]) < 1e-6)
                    Console.WriteLine("The system has many solution.");
                else
                    Console.WriteLine("The system has no solution.");
                return;
            }

            // зворотній хід 
            double y = augmentedMatrix[1, 2] / augmentedMatrix[1, 1];
            double x = (augmentedMatrix[0, 2] - augmentedMatrix[0, 1] * y) / augmentedMatrix[0, 0];

            Console.WriteLine($"Solution: x = {x}, y = {y}");
        }

        // метод для перевірки, чи є точка розв'язком системи
        public bool IsSolution(double x, double y)
        {
            return Math.Abs(coefficients[0, 0] * x + coefficients[0, 1] * y - coefficients[0, 2]) < 1e-6 &&
                   Math.Abs(coefficients[1, 0] * x + coefficients[1, 1] * y - coefficients[1, 2]) < 1e-6;
        }
    }
}
