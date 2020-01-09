using System;
using System.Collections.Generic;

namespace Polimorfizm
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Transport> transports = new List<Transport>();
            transports.Add(new Aircraft(10, 2));
            transports.Add(new Car(10, 4));
            foreach (Transport t in transports)
                Console.WriteLine(t.Move());
        }
    }
}
