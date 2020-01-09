using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfizm
{
    public class Aircraft : Transport
    {
        private double MaxAttitude;

        public double MaxAttitude_p { get => MaxAttitude; set => MaxAttitude = value; }

        public Aircraft() : base()
        {
            MaxAttitude = 100;
        }

        public Aircraft(double speed, double count) : base(speed, count)
        {
            MaxAttitude = 100;
        }

        public sealed override string ToString()
        {
            return "Aircraft";
        }
        public override string Move()
        {
            return "Flying";
        }
    }
}
