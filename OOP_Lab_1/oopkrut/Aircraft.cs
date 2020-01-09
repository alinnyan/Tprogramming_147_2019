using System;
using System.Collections.Generic;
using System.Text;

// Тут будут описано все, что происходит


namespace oopkrut
{
    public class Aircraft
    {
        private const double V = 3.6; // константа для перевода в км/ч
        private double Speed; // скорость (в м\с)
        private double Count; // кол-во пассажиров 
        private double Max_Attitude; // максимальная высота (в метрах)
        // свойства
        public double Max_Attitude_p
        {
            get => Max_Attitude;
            set
            {
                if (value < 0)// дополнение к заданию(исключение)
                    throw new ArgumentException(string.Format("Max_Attitude can't be < 0"));
                else
                    Max_Attitude = value;
            }
        }
        public double Count_p
        {
            get => Count;
            set
            {
                if (value < 0) // дополнение к заданию (исключение)
                    throw new ArgumentException(string.Format("Count can't be < 0"));
                else
                    Count = value;
            }
        }

        public override string ToString()// дополнение к заданию (переопределение)
        {
            return "Aircraft";
        }
        // методы
        public double Get_Speed_kmh() => Speed * V;
        public double Get_Speed_ms() => Speed;
        public void Set_Speed_ms(double Speed) => this.Speed = Speed;
        public Aircraft() // конструктор пустой
        {
            Speed = 0;
            Count = 1;
            Max_Attitude = 1;
        }

        public Aircraft(double speed, double count, double max_Attitude) // конструктор с параметрами
        {
            Speed = speed;
            Count_p = count;
            Max_Attitude_p = max_Attitude;
        }
    }
}
