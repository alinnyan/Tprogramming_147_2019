using System;

namespace oopkrut
{
    class Program
    {
        static void Main(string[] args)
        {
            Aircraft air = new Aircraft();
            Console.WriteLine("I am an {0}", air.ToString());
        }
    }
}
