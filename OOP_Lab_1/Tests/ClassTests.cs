using System;
using Xunit;
using oopkrut;

namespace Tests
{
    public class ClassTests
    {
        public const string CountExceedsBalanceMessage =
            "Count can't be < 0";
        private const string ActualString = "Aircraft";

        [Fact]
        public void Creation()
        {
            Aircraft test = new Aircraft();
            Assert.Contains(test.ToString(), ActualString);// правильно ли переопределяется метод
        }
        [Fact]
        public void WrongCount()
        {
            Aircraft test = new Aircraft();
            try
            {
                test.Count_p = -1;// задаем неверное значение
            }
            catch (ArgumentException e)
            {
                Assert.Contains(
                    e.Message,
                    CountExceedsBalanceMessage); // проверяем то ли значение показало исключение
            }
          
        }

    }
}
