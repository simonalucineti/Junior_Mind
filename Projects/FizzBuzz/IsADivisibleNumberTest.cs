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
        public void IsDivisibleByThreeAndFiveAndFifteen()
        {
            Assert.AreEqual("FizzBuzz", IsDivisible(30));
        }

        [TestMethod]
        public void IsNotDivisible()
        {
            Assert.AreEqual("Not Divisible", IsDivisible(26));
        }
        string IsDivisible(int number)
        {
            string output = "";
            if ((number % 3 == 0) && (number % 5 == 0) && (number % 15 == 0))
                output = "FizzBuzz";
            else  if (number % 3 == 0)
                output = "Fizz";
            else if (number % 5 == 0)
                output = "Buzz";
            else output = "Not Divisible";
            return output;
        }
    }
}
