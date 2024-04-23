using TestingLR2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestingLR2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int r = 163;
            int expected = 1;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int r = 234;
            int expected = 2;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int r = 349;
            int expected = 3;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            int r = 578;
            int expected = 5;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            int r = 689;
            int expected = 6;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            int r = 405;
            int expected = 0;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod7()
        {
            int r = 978;
            int expected = 7;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod8()
        {
            int r = 798;
            int expected = 7;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod9()
        {
            int r = 899;
            int expected = 8;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod10()
        {
            int r = 999;
            int expected = 9;

            int actual = MinDigit.Minim(r);
            Assert.AreEqual(expected, actual);
        }
    }
}