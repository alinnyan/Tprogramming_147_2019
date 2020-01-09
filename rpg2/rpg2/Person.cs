using System;
using System.Collections.Generic;
using System.Text;

namespace rpg2
{
    public struct Message // СООБЩЕНИЕ ДЛЯ ОБМЕНА ДАННЫМИ МЕЖДУ КЛАССАМИ
    {
        //0-ждать 1-атака 2-бафф
        public int action;
        public int aim; // цель
        public int damage; // урон
        public bool magic; // тип урона (магия или нет)

        public Message(int action, int aim, int damage, bool magic)
        {
            this.action = action;
            this.aim = aim;
            this.damage = damage;
            this.magic = magic;
        }
    }
    abstract public class Person
    { // класс интерфейс
        protected int t; // тип класса
        public int T { get => t; }
        protected int toggle; // тип атаки
        protected int fient; // шанс уклонения 
        protected bool visible; // видим или невидим
        protected string name; // имя персонажа
        protected bool dead; // предикат жив или мертв
        protected Person[] vision; // остальные персонажи
        protected int num; // номер в массиве
        protected int HP; // здоровье
        protected bool atkType; //тип атаки (магия или нет)
        protected int MaxHP; // максимальное здоровье
        protected int StepInit; // сколько инициативы востанавливается за ход
        protected int init;
        // ВАЖНО!!!!!!!! инициатива определяет очередность хода (персонаж МОЖЕТ ХОДИТЬ ДВАЖДЫ ЗА ХОД ИЛИ НЕ ХОДИТЬ ВООБЩЕ)
        protected int Armor;// защита
        protected int AtkMax; // максимальная атака
        protected int AtkMin;// минимальная атака
        protected int Crit; // шанс на критическую атаку
        protected Random rand;
        public Person(Person[] players, int i, int N)
        {
            rand = new Random();
            vision = players;
            num = i;
            visible = true;
            toggle = -1;
            atkType = false;
        }

        public bool Dead { get => dead; }
        public int Init { get => init; }
        public string Name { get => name; }
        public bool Visible { get => visible; }
        public bool AtkType { get => atkType; }

        virtual public string Wait_replic()
        {
            throw new NotImplementedException();
        }

        virtual public string Atack_replic(Message modificator)
        {
            throw new NotImplementedException();
        }

        virtual public void Vision(Person[] players, int i)
        {
            vision = players;
            num = i;
        }

        virtual public string Reaction_replic(Message modificator)
        {
            throw new NotImplementedException();
        }

        virtual public int Atak_New()
        {
            throw new NotImplementedException();
        }

        public virtual int NewAim()
        { // нахождение цели
            bool invis = false;
            for (int i = 0; i < vision.Length; i++)
            {
                if (i == num)
                    continue;
                if (vision[i].Visible && vision[i].Dead == false)
                {
                    invis = true;
                    break;
                }
            }
            if (invis == false)
                return -1;
            int res;
            do
            {
                res = rand.Next(0, vision.Length);
            } while (res == num || vision[res].Visible == false || vision[res].Dead == true);
            return res;

        }
        public virtual int NewAction()
        {
            int aim = NewAim();
            if (aim == -1)
            {
                int r = rand.Next(0, 100);
                if (r > 30)
                    return 0;
                else
                    return 2;
            }
            else if (rand.Next(0, 100) > 20)
            {
                return 1;
            }
            else
                return 0;
        }

        virtual public void Death()
        {// смерть
            dead = true;
            init = 0;
            StepInit = 0;
        }

        virtual public string Buff_replic()
        {
            throw new NotImplementedException();
        }
        virtual public void DownInit(int global_Delay)
        {
            init -= global_Delay;
        }

        virtual public void UppInit()
        {
            init += StepInit;
        }

        virtual public string DeBuff_replic(Message modificator)
        {
            throw new NotImplementedException();
        }
    }
}
