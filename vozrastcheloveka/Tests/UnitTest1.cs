using System;
using Xunit;
using AgeApp;
namespace Tests
{
    public class UnitTest1
    {
        AgeCheak age = new AgeCheak();
        [Fact]
        public void Test_less()
        {
            try
            {
                DateTime date1 = new DateTime(2020, 1, 1, 8, 0, 15);
                age.Cheak(date1);
            }
            catch (ArgumentException e)
            {
                Assert.Contains(e.Message,
                      "Age can't be less than null");
            }
        }
        [Fact]
        public void Test_Equel()
        {
            try
            {
                age.Cheak(age.Now);
            }
            catch (ArgumentException e)
            {
                Assert.Contains(e.Message,
                      "Age can't be equel to now");
            }
        }
        [Fact]
        public void Test_Normal()
        {
            DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);
            age.Cheak(date2);
          
        }
    }
}
