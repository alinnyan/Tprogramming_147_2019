using System;
using Xunit;
using CountApp;

namespace CourseApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Eqv eqv = new Variant9(1.1,
                                   0.09,
                                   1.2,
                                   2.2,
                                   0.2,
                                   1.21,
                                   1.76,
                                   2.53,
                                   3.48,
                                   4.52);
        }
    }
}
