using System;
using System.Collections.Generic;
using System.Threading;

namespace rpg2
{
    class Program // основной файл
    {
        static void Main(string[] args)
        {
            int i = 1; // номер хода
            int t; // если игра кончилтся, тут будет сохранен победитель
            Game now = new Game(4); // создание игры от 4 игроков (можно менять)
            do
            {
                Console.WriteLine("Ход {0}", i);
                List<string> turn = now.Step(); // совершаем ходы всеми персонажами
                foreach (string s in turn) // выводим с интервалов 2  секунды
                {
                    Console.WriteLine(s);
                    Thread.Sleep(2000);
                }
                i++;
                t = now.Win();// проверяем кончилась ли игра
            } while (t == 0); // если игра кончилась - выводим итоги
            if (t == 1)
                Console.WriteLine("Победил Разбойник!!!! Теперь он поедет на нары с чувством собственной гордости...");
            else if (t == 2)
                Console.WriteLine("Победил Воин!!!! Но он все еще в ярости...");
            else if (t == 3)
                Console.WriteLine("Победил Колдун!!!! ТЕПЕРЬ ОН ИСПЕПЕЛИТ ВЕСЬ МИР (или нет)...");
        }
    }
}
