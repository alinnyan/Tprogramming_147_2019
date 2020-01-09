using System;
using Xunit;
using Polimorfizm;
using System.Collections.Generic;
namespace Tests
{
    public class ClassesTests
    {
        [Fact]
        public void Creation()
        {
            try
            {
                Aircraft test = new Aircraft(10, -2);
                Car tests = new Car(10, -3);
            }
            catch (ArgumentException e)
            {
                Assert.Contains(e.Message,
                      "Count can't be < 0");
            }
        }
        [Fact]
        public void ToString_Test()
        {

            Aircraft test_air = new Aircraft();
            Car test_car = new Car();
            Assert.Contains(test_car.ToString(),
                      "Car");
            Assert.Contains(test_air.ToString(),
                     "Aircraft");
        }
        [Fact]
        public void Move_Test()
        {

            Aircraft test_air = new Aircraft();
            Car test_car = new Car();
            Assert.Contains(test_car.Move(),
                      "Ride");
            Assert.Contains(test_air.Move(),
                     "Flying");
        }

    }
}
