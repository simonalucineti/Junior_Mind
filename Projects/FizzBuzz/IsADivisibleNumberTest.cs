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
        string IsDivisible(int number)
        {
            string output = "";
            if (number%3==0)
             output = "Fizz";
            return output;
        }
    }
}
