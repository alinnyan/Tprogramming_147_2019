using System;
using System.Collections.Generic;
using System.Text;

namespace Polimorfizm
{
    public abstract class Transport
    {
        private const double V = (3.6); // константа для перевода в км/ч
        private double Speed; // скорость (в м\с)
        private double Count; // кол-во пассажиров 
        // свойства
        public double Count_p
        {
            get => Count;
            set
            {
                if (value < 0) // дополнение к заданию (исключение)
                    throw new ArgumentException(String.Format("Count can't be < 0"));
                else
                    Count = value;
            }
        }
        public abstract string Move();// абстрактный метод
        
        public override string ToString()// дополнение к заданию (переопределение)
        {
            return "Transport";
        }
        // методы
        public double Get_Speed_kmh() => Speed * V;
        public double Get_Speed_ms() => Speed;
        public void Set_Speed_ms(double Speed) => this.Speed = Speed;
        public Transport() // конструктор пустой
        {
            Speed = 0;
            Count = 1;
            
        }

        public Transport(double speed, double count) // конструктор с параметрами
        {
            Speed = speed;
            if (count < 0) // дополнение к заданию (исключение)
                throw new ArgumentException(String.Format("Count can't be < 0"));
            else
                Count = count;
        }
    }
}
