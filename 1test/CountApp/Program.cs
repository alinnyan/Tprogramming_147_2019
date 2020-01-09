using System;

namespace CountApp
{
    public class Variant9 : Eqv
    {
        public Variant9(double a, double b, double xS, double xF, double dx,
            double x1, double x2, double x3, double x4, double x5)
            : base(a, b, xS, xF, dx, x1, x2, x3, x4, x5)
        {

        }
        protected override double f(double x)
        {
            return Math.Log((x * x) - 1) / (Math.Log((a * (x * x) - b), 5));
        }
 
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            Eqv eqv = new Variant9(1.1, 0.09, 1.2, 2.2, 0.2, 1.21, 1.76, 2.53, 3.48, 4.52);
            eqv.Count();
            double[,] res = eqv.GetY();
            for (int i = 0; i < eqv.GetCount(); i++)
            {
                Console.WriteLine("Y" + Convert.ToString(i) + " " 
                    + Convert.ToString(res[0,i]) + " " + Convert.ToString(res[1, i])
                    + " " + Convert.ToString(res[2, i]) + " " + Convert.ToString(res[3, i]) 
                    + " " + Convert.ToString(res[4, i]) + " " );
            }
            Console.ReadKey();
        }
    }
}
