using System;
using System.Collections.Generic;
using System.Text;

namespace rpg2
{
    public class Rogue : Person // класс разбойника
    {

        private int premeditation; // основная механика - подготовка



        public Rogue(Person[] players, int i, int n) : base(players, i, n)
        { // конструктор класса
            t = 1;
            premeditation = 0;
            visible = false;
            //name = "Разбойник" + Convert.ToString(i) ;
            if (n > 0)
                name = "Разбойник" + Convert.ToString(i);
            else
                name = "Разбойник";
            MaxHP = 30;
            AtkMax = rand.Next(6, 7);
            AtkMin = rand.Next(2, 4);
            HP = MaxHP;
            fient = 40;
            dead = false;
            StepInit = rand.Next(10, 19);
            init = StepInit;
            Crit = 50;
            Armor = rand.Next(1, 3);
            // пояснения в Person
        }

        public override string Wait_replic()
        {
            premeditation += 2;
            return Name + " готовит свой коварный план, его атака возросла!";
        }
        public override int Atak_New()
        {// расчет урона, считает урон от кинжала в левой и правой руке
            int left;
            int right;
            int res;
            if (rand.Next(0, 100) < Crit)
            {
                left = rand.Next(AtkMin, AtkMax) * 2;
            }
            else
                left = rand.Next(AtkMin, AtkMax);

            if (rand.Next(0, 100) < Crit)
            {
                right = rand.Next(AtkMin, AtkMax) * 2;
            }
            else
                right = rand.Next(AtkMin, AtkMax);
            if (rand.Next(0, 100) > 20)
            {
                if (Visible == false)// атака из невидимости
                {
                    atkType = false;
                    visible = true;
                    res = (left + right) * 2 + premeditation;
                    toggle = 1;
                    return res;
                }
                else // обычная
                {
                    atkType = false;
                    res = left + right + premeditation;
                    toggle = 2;
                    return res;
                }
            }
            else // усиленная атака из невидимости
            {
                if (Visible == false)
                {
                    atkType = true;
                    visible = true;
                    res = (left + right) * 2 + premeditation + 5;
                    toggle = 3;
                    return res;
                }
                else// усиленная атака
                {
                    atkType = true;
                    res = left + right + premeditation + 5;
                    toggle = 4;
                    return res;
                }
            }

        }
        public override string Atack_replic(Message modificator)
        {

            if (modificator.aim == -1 && visible == true)
            { //если никого не видно
                return Name + " никого перед собой, больше не может прятаться....";
            }

            if (toggle == 1)
                return Name + " подло нападает со спины на " + vision[modificator.aim].Name;
            else if (toggle == 2)
                return Name + " нападает на " + vision[modificator.aim].Name;
            else if (toggle == 3)
                return Name + " скрытно вонзает свои отравленные клинки в тушку " + vision[modificator.aim].Name + " нанося магический урон";
            else if (toggle == 4)
                return Name + " вонзает свои отравленные клинки в тушку " + vision[modificator.aim].Name + " нанося магический урон";
            return Name + "произошел троллинг";
        }
        public override string Buff_replic()
        {// усиление
            if (Visible == true)
            {// если видимы - уходит в невидимость

                visible = false;
                return Name + " скрывается в тени!!!!";

            }
            else if (Visible == false)
            {// иначе либо восстанавливает здоровье, если неполное
                if (HP == MaxHP)
                {
                    premeditation += 5;
                    return "Тьма наполняет клинки " + Name + " их сила возросла на 5";
                }
                else
                {// усиливает основную механику
                    HP += premeditation * 2;
                    if (HP > MaxHP)
                    {
                        HP = MaxHP;
                    }
                    return "Тьма залечивает раны " + Name
                     + " он исцеляется на " + Convert.ToString(premeditation)
                       + " здоровья, теперь оно рано " + Convert.ToString(HP);
                }
            }
            return Name + "ожидает";
        }
        public override string Reaction_replic(Message modificator)
        {
            // получение урона 
            if (rand.Next(0, 100) < fient) // уклонение от магии (есть только у разбойника)
                return Name + " в последний момент уворачивается от атаки";
            else
            {
                if (modificator.magic) // если урон магический
                {
                    int damage = modificator.damage;
                    if (damage < 0)
                        damage = 0;
                    if (HP <= 0)// есои урон был смертельный 
                    {
                        if (rand.Next(0, 100) < 10) // 10%, чо выживет
                        {
                            HP = (int)(0.1 * MaxHP);
                            return "Невероятно, " + Name + " обманывает смерть и остается в живых!!! Какая Удача";
                        }
                        else // или умирает от магии
                        {
                            Death();
                            return Name + " испепелен магией";
                        }
                    }
                    else // если урон не смертельный
                    {
                        if (modificator.damage > 0) // ЕСДИ УРОН БЫЛ
                        {
                            return Name + " получает магическое ранение на "
                                + Convert.ToString(damage) +
                                " у него остается " + Convert.ToString(HP);
                        }
                        else // ЕСЛИ УРОНА НЕ БЫЛО  
                        {
                            return Name + " отделался чувством легкого испуга... ";
                        }
                    }
                }
                else // ФИЗИЧЕСКИЙ УРОН (ВСЕ ТОЖЕ САМОЕ)
                {
                    int damage = modificator.damage - Armor;
                    if (damage < 0)
                        damage = 0;
                    HP -= modificator.damage - Armor;
                    if (HP <= 0)
                    {
                        if (rand.Next(0, 100) < 10)
                        {
                            HP = (int)(0.1 * MaxHP);
                            return "Невероятно, " + Name + " обманывает смерть и остается в живых!!! Какая Удача";
                        }
                        else
                        {
                            Death();
                            return Name + " погибает мучительной смертью, так и не став самым великим разбойником....";
                        }
                    }
                    else
                    {
                        if (damage > 0)
                        {
                            return Name + " получает удар на "
                                + Convert.ToString(modificator.damage) +
                                " у него остается " + Convert.ToString(HP);
                        }
                        else
                        {

                            return Name + " избегает урона ";
                        }
                    }
                }
            }


        }
    }
}
