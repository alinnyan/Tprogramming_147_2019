using System;
using System.Collections.Generic;
using System.Text;

namespace rpg2
{
    public class Warrior : Person
    {
        int RAGE; // ярость воина уменьшает входящий урон и увелечивает исходящий
        public Warrior(Person[] players, int i, int n) : base(players, i, n)
        {
            t = 2;
            RAGE = 0;
            visible = true;
            if (n > 0)
                name = "Воин" + Convert.ToString(i);
            else
                name = "Воин";
            MaxHP = 50;
            AtkMax = rand.Next(8, 11);
            AtkMin = rand.Next(6, 7);
            HP = MaxHP;
            fient = 10;
            dead = false;
            StepInit = rand.Next(10, 15);
            init = StepInit;
            Crit = 10;
            Armor = rand.Next(3, 6);
        }
        public override string Wait_replic()
        {
            RAGE += 2;
            return Name + " вспоминает о всех своих детских обидах и СВИРЕПЕЕТ";
        }
        public override int Atak_New()
        {
            int right;
            int res;
            if (rand.Next(0, 100) < Crit)
            {
                right = rand.Next(AtkMin, AtkMax) * 4;
            }
            else
                right = rand.Next(AtkMin, AtkMax);
            if (rand.Next(0, 100) > 20) // обычный удар
            {
                RAGE += 2;
                atkType = false;
                res = right + RAGE;
                toggle = 2;
                return res;

            }
            else // супер удар
            {
                RAGE += 3;
                atkType = false;
                res = right * 4 + RAGE * (MaxHP - HP);
                toggle = 4;
                return res;

            }

        }
        public override string Atack_replic(Message modificator)
        {

            if (modificator.aim == -1 && visible == true)
            {
                RAGE += 5;
                return Name + " никого не видит перед собой... ОТ ЧЕГО СТАНОВИТСЯ ДЕЙСТВИТЕЛЬНО ЗЛЫМ!!!!!";
            }

            if (toggle == 2)
                return Name + " нападает на " + vision[modificator.aim].Name;
            else if (toggle == 4)
                return Name + " засовывает свой ботинок ТАК глубоко в гладко выбритую задницу это глупого " + vision[modificator.aim].Name + " что у него изо рта начинает пахнуть гуталином!!!";
            return Name + "произошел троллинг";
        }
        public override string Buff_replic()
        {
            if (RAGE < 10)
            {
                RAGE += 4;
                return "Ярость " + Name + " НЕ ЗНАЕТ ГРАНИЦ И РАСТЕТ";
            }
            else if (HP < MaxHP)
            {
                RAGE += 2;
                HP += RAGE / 2;
                if (HP > MaxHP)
                    HP = MaxHP;
                return "Пыл битвы исцеляет " + Name + " нa "
                    + Convert.ToString(RAGE / 2)
                    + " еденицы здоровья. Теперь у него " + Convert.ToString(HP);
            }
            else
            {
                RAGE += 3;
                return Name + " Открывает ВЕЛИКУЮ книгу обид и читает...(естественно, пропитываясь яростью)";
            }
        }
        public override string Reaction_replic(Message modificator)
        {

            if (rand.Next(0, 100) < fient && modificator.magic == false)
                return Name + " в последний момент уворачивается от атаки";
            else
            {
                if (modificator.magic)
                {

                    int damage = modificator.damage - RAGE / 2;
                    if (damage < 0)
                        damage = 0;
                    HP -= damage;
                    if (HP <= 0)
                    {

                        Death();
                        return Name + " испепелен гнусной магией";

                    }
                    else
                    {

                        if (modificator.damage - RAGE / 2 > 0)
                        {
                            RAGE += 1;
                            return Name + " получает магический удар на "
                            + Convert.ToString(damage) +
                            " у него остается " + Convert.ToString(HP);
                        }
                        else
                        {
                            RAGE += 2;
                            return Name + " не почувствовал атаку!  ";
                        }
                    }
                }
                else
                {
                    int damage = modificator.damage - Armor;
                    if (damage < 0)
                        damage = 0;
                    HP -= damage;
                    if (HP <= 0)
                    {

                        Death();
                        return Name + " погибает в честном (относительно) бою, как и следует настоящему воину.....";

                    }
                    else
                    {
                        if (damage > 0)
                        {
                            RAGE += 2;
                            return Name + " получает удар на "
                                + Convert.ToString(damage) +
                                " у него остается " + Convert.ToString(HP);
                        }
                        else
                        {
                            RAGE += 1;
                            return Name + " не почувствовал атаку!  ";
                        }
                    }
                }
            }


        }
    }
}
