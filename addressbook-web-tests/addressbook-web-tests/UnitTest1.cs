using System;
using addressbook_web_tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAddressbookTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);

            s1.Colored = true;

            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);

            Assert.IsTrue(s1.Colored);
        }

        [TestMethod]
        public void TestMethodRadiu()
        {
            Circle s1 = new Circle(5);
            Circle s2 = new Circle(10);

            s1.Colored = true;

            Assert.AreEqual(s1.Radius, 5);
            Assert.AreEqual(s2.Radius, 10);

            Assert.IsTrue(s1.Colored);
        }
    }
}
