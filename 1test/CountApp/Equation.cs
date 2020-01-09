namespace CountApp
{
    public class Eqv
    {
        protected double a;
        protected double b;
        private double xS;
        private double xF;
        protected double dx;
        protected double x1;
        protected double x2;
        protected double x3;
        protected double x4;
        protected double x5;
        protected int count;
        protected double[,] Y;
        public Eqv(double a, double b, double xS, double xF, double dx,
            double x1, double x2, double x3, double x4, double x5)
        {
            Eqv e = this;
            e.a = a;
            e.b = b;
            e.dx = dx;
            e.x1 = x1;
            e.x2 = x2;
            e.x3 = x3;
            e.x4 = x4;
            e.x5 = x5;
            e.xF = xF;
            e.xS = xS;
            count = (int)((xF - xS) / dx) + 1;
            Y = new double[5, count];
        }
        protected virtual double f(double x) => x;
        public double[,] GetY() => Y;
        public int GetCount() => count;
        public  void Count()
        {
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
        }
    }
}
