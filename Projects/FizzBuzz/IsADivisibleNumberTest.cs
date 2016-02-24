using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsDivisibleByThree()
        {
            Assert.AreEqual("Fizz", IsDivisible(9));
        }
        [TestMethod]
        public void IsDivisibleByFive()
        {
            Assert.AreEqual("Buzz", IsDivisible(10));
        }
        [TestMethod]
        public void IsDivisibleByThreeAndFive()
        {
            Assert.AreEqual("FizzBuzz", IsDivisible(30));
        }
        string IsDivisible(int number)
        {
            string output = "";
            if (number % 3 == 0)
                output = "Fizz";
            if (number % 5 == 0)
                output = "Buzz";
            if ((number % 3 == 0) && (number % 5 == 0))
                output = "FizzBuzz";
            return output;
        }
    }
}
