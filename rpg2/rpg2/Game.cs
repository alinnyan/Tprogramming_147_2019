using System;
using System.Collections.Generic;
using System.Text;

namespace rpg2
{
    public class Game
    {
        private int Count;
        private Person[] Players;
        private int Global_Delay;
        private void Random_Heroes_Generation() // генерация героев
        {
            Random r = new Random();
            int rc = 0, mc = 0, wc = 0;
            for (int i = 0; i < Count; i++)
            {
                int buf = r.Next(0, 4);
                if (buf == 0)
                    Players[i] = new Rogue(Players, i, rc++);
                else
               if (buf == 1)
                    Players[i] = new Mage(Players, i, mc++);
                else
                    Players[i] = new Warrior(Players, i, wc++);
            }
        }

        public int Win() // проверка есть ли победитель
        {
            int count = 0;
            int t = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Players[i].Dead == false)
                {
                    count++;
                    t = Players[i].T;

                }
            }
            if (count > 1)
                return 0;
            else
            {
                return t;
            }
        }

        public Game(int count)
        {
            if (count < 0)
                throw new ArgumentException(string.Format("Count can't be < 0"));
            else
            {
                Global_Delay = 10;
                Count = count;
                Players = new Person[Count];
                Random_Heroes_Generation();
            }
        }

        public List<string> Step()
        {
            // ход
            Person temp; // сортировка по инициативе
            for (int i = 0; i < Players.Length - 1; i++)
            {
                for (int j = 0; j < Players.Length - i - 1; j++)
                {
                    if (Players[j + 1].Init > Players[j].Init)
                    {
                        temp = Players[j + 1];
                        Players[j + 1] = Players[j];
                        Players[j] = temp;
                    }
                }
            }

            List<string> result = new List<string>();
            // все строки текста
            do
            { // ходят все живые герои с инициативой, которой хватит
                for (int i = 0; i < Count; i++)
                {

                    if (Players[i].Dead == false && Players[i].Init >= Global_Delay)
                    {
                        Players[i].Vision(Players, i);
                        Random rand = new Random();
                        Message modificator = new Message(Players[i].NewAction(), Players[i].NewAim(), Players[i].Atak_New(), Players[i].AtkType);
                        if (modificator.action == 1)
                        {
                            result.Add(Players[i].Atack_replic(modificator));
                            if (modificator.aim != -1)
                                result.Add(Players[modificator.aim].Reaction_replic(modificator));
                        }
                        else if (modificator.action == 0)
                        {
                            result.Add(Players[i].Wait_replic());
                        }
                        else if (modificator.action == 2)
                        {
                            result.Add(Players[i].Buff_replic());
                        }
                        Players[i].DownInit(Global_Delay);
                    }
                }
            } while (Check_Init()); // пока у всех не кончится инициатива
            for (int i = 0; i < Count; i++)
            {
                Players[i].UppInit();
            }
            return result;
        }

        private bool Check_Init()
        {
            {
                for (int i = 0; i < Count; i++)
                {
                    if (Players[i].Init >= Global_Delay)
                        return true;
                }
                return false;
            }
        }
    }
}
