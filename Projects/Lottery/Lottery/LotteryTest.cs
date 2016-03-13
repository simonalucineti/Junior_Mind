using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class LotteryTest
    {
        [TestMethod]
        public void TestFactorial()
        {
            Assert.AreEqual(24, Factorial(4));
        }
        [TestMethod]
        public void CombinationPossibleTest()
        {
            Assert.AreEqual(13983816, CombinationPossible(49, 6));
        } 

        double CalculateProbabilityToWin(double ticketNumbers, double winNumbers, double totalNumbers)
        {
            return 0;
        }
        double Factorial(double number)
        {
            double factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial *= i;

            return factorial;
        }

        double CombinationPossible(double totalNumbers, double winNumbers)
        {
            double combinatorics = Factorial(totalNumbers) /
                                   (Factorial(winNumbers) * Factorial((totalNumbers - winNumbers)));

            return combinatorics;
        }
    }
}
