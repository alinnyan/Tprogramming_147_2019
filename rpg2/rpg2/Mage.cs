
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg2
{
    public class Mage : Person
    { // класс мага
        int mp;
        // основная механика - магия
        int maxmp;
        public Mage(Person[] players, int i, int n) : base(players, i, n)
        {
            t = 3;
            maxmp = rand.Next(100, 150);
            mp = maxmp;
            visible = true;
            if (n > 0)
                name = "Колдун" + Convert.ToString(i);
            else
                name = "Колдун";
            MaxHP = 20;
            HP = MaxHP;
            fient = 0;
            dead = false;
            StepInit = rand.Next(9, 11);
            init = StepInit;
            Crit = 0;
            Armor = rand.Next(0, 2);
        }
        public override string Wait_replic()
        {
            if (mp < maxmp)
            {
                mp = maxmp;
                return Name + " восстанавливает полный запас магии";
            }
            else
            {
                Armor += 4;
                return Name + " создает ледяной щит!!!";
            }
        }
        public override int Atak_New()
        {// расчет могического урона
            int right;
            int res;
            right = rand.Next(0, mp);
            if (rand.Next(0, 100) > 2)
            {
                mp -= right;
                atkType = true;
                res = mp / 3;
                toggle = 2;
                return res;

            }
            else
            {
                mp -= right;
                atkType = true;
                res = mp / 2;
                toggle = 3;
                return res;
            }
        }
        public override string Buff_replic()
        {
            maxmp += rand.Next(100, 150);
            mp = maxmp;
            return "Колдун " + Name
            + ", занюхнув ОЧЕНЬ мощный нюхательный табак из варпстоуна его МАГИЧЕСКАЯ МОЩЬ теперь равна "
            + Convert.ToString(maxmp) + " еденицы";

        }
        public override string Atack_replic(Message modificator)
        {

            if (modificator.aim == -1 && visible == true)
            {
                Armor += 6;
                return Name + " никого не видит перед собой... От чего ОЧЕНЬ страшно и наскатовывает ОЧЕНЬ большой ледяной щит";
            }

            if (toggle == 2) // обычая атака
                return Name + " кидает СУПЕР НЕСТАБИЛЬНЫЙ МЕГА ФАЕРБОЛ СМЕЕЕРТИИИИ в " + vision[modificator.aim].Name;
            else if (toggle == 3) // промах
                return Name + " кидает СУПЕР НЕСТАБИЛЬНЫЙ МЕГА ФАЕРБОЛ СМЕЕЕРТИИИИ в " + vision[modificator.aim].Name;
            return Name + "произошел троллинг";
        }
        public override string Reaction_replic(Message modificator)
        {

            if (rand.Next(0, 100) < fient)
                return Name + " в последний момент уворачивается от атаки";
            else
            {
                if (modificator.magic)
                {
                    int damage = modificator.damage - mp / 10;
                    if (damage <= 0)
                    {
                        mp -= modificator.damage / 10;
                        damage = 0;
                    }
                    else
                    {
                        HP -= damage;
                        mp = 0;
                    }

                    if (HP <= 0)
                    {

                        Death();
                        return Name + " испепелен магией";

                    }
                    else
                    {

                        if (damage > 0)
                        {
                            return Name + " получает магический удар на "
                            + Convert.ToString(damage) +
                            " у него остается " + Convert.ToString(HP) + "и не остается магии";
                        }
                        else
                        {

                            return Name + "  магический щит поглащает атаку! Осталось " + Convert.ToString(mp) + "магии";
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
                        return Name + " погибает от переизбытка урона в своей тощей тушке....";

                    }
                    else
                    {
                        if (damage > 0)
                        {
                            return Name + " получает удар на "
                                + Convert.ToString(damage) +
                                " у него остается " + Convert.ToString(HP);
                        }
                        else
                        {
                            return Name + " Ледяной щит блокировал атаку!  ";
                        }
                    }
                }
            }
        }
    }
}
