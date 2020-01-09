using System;

namespace proga1beztesta
{

    class Program
    {
        const double a = 2.0;
        const double b = 3.0;
        const double xS = 0.11;
        const double xF = 0.36;
        const double dx = 0.05;
        static int count;

        static double f(double x)
        {
            return Math.Asin(Math.Pow(x, a)) + Math.Acos(Math.Pow(x, b));
        }
        static void Main(string[] args)
        {
            double x1 = 0.08;
            double x2 = 0.26;
            double x3 = 0.35;
            double x4 = 0.41;
            double x5 = 0.53;
            double[,] Y;
            count = (int)((xF - xS) / dx) + 1;
            Y = new double[5, count];
            for (int i = 0; i < count; i++)
            {
                Y[0, i] = f(x1);
                Y[1, i] = f(x2);
                Y[2, i] = f(x3);
                Y[3, i] = f(x4);
                Y[4, i] = f(x5);
                x1 += dx;
                x2 += dx;
                x3 += dx;
                x4 += dx;
                x5 += dx;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Y" + Convert.ToString(i) + " "
                    + Convert.ToString(Y[0, i]) + " " + Convert.ToString(Y[1, i])
                    + " " + Convert.ToString(Y[2, i]) + " " + Convert.ToString(Y[3, i])
                    + " " + Convert.ToString(Y[4, i]) + " ");
            }
            Console.ReadKey();
        }
    }
}
