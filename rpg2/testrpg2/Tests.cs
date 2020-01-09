using System;
using Xunit;
using rpg2;

namespace testrp2
{
    public class Tests
    {
        Person[] test = new Person[3];
        [Fact]
        public void Test_Mage()
        {

            Person p = new Mage(test, 0, 0);
            Assert.Contains(p.Name, "Колдун");
        }
        [Fact]
        public void Test_Rogue()
        {
            Person p = new Rogue(test, 0, 0);
            Assert.Contains(p.Name, "Разбойник");
        }
        [Fact]
        public void Test_Warrior()
        {
            Person p = new Warrior(test, 0, 0);
            Assert.Contains(p.Name, "Воин");
        }
        [Fact]
        public void Test_Game()
        {
            try
            {
                Game t = new Game(-2);
            }
            catch (ArgumentException e)
            {
                Assert.Contains(e.Message,
                      "Count can't be < 0");
            }
        }
        [Fact]
        public void Test_Game_Right()
        {

            Game t = new Game(4);


        }
    }
}
