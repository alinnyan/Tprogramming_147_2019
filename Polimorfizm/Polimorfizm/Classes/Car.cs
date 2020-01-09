using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfizm
{
    public class Car : Transport
    {
        public Car() : base()
        {
        }

        public Car(double speed, double count) : base(speed, count)
        {
        }
        public sealed override string ToString()
        {
            return "Car";
        }
        public override string Move()
        {
            return "Ride";
        }
    }
}
