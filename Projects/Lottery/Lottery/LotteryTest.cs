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
        [TestMethod]
        public void WinAndTicketNumberTest()
        {
            Assert.AreEqual(15, CombinationWinAndTicketNumbers(6, 4));
        }
        [TestMethod]
        public void NotOnTicketAndNotMatches()
        {
            Assert.AreEqual(903, CombinationNotOnTicketToNotMatchesNumbers(43, 2));
        }

        [TestMethod]
        public void FirstCategory()
        {
            Assert.AreEqual(7.15112384201852E-8, CalculateProbabilityToWin(6, 6, 49), 0.00001);
        }

        [TestMethod]
        public void FirstCategoryFiveForForty()
        {
            Assert.AreEqual(1.519738361843625e-6, CalculateProbabilityToWin(5, 5, 40));
        }

        [TestMethod]
        public void SecondCategory()
        {
            Assert.AreEqual(1.844989951240777e-5, CalculateProbabilityToWin(5, 6, 49), 0.00001);
        }

        [TestMethod]
        public void ThirdCategory()
        {
            Assert.AreEqual(9.68054211035818e-4, CalculateProbabilityToWin(4, 6, 49), 0.00001);
        }

        double CalculateProbabilityToWin(double ticketNumbers, double winNumbers, double totalNumbers)
        {
            double NotMatchesNumbers = totalNumbers - winNumbers;
            double NotOnTheTicketNumbers = winNumbers - ticketNumbers;
            double probability;
            double firstNumerator = CombinationWinAndTicketNumbers(winNumbers, ticketNumbers);
            double secondNumerator = CombinationNotOnTicketToNotMatchesNumbers(NotMatchesNumbers, NotOnTheTicketNumbers);
            double denominator = CombinationPossible(totalNumbers, winNumbers);
            return probability = (firstNumerator * secondNumerator) / denominator;
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

        double CombinationWinAndTicketNumbers(double winNumbers, double ticketNumbers)
        {
            double winAndTichetNumbers = Factorial(winNumbers) /
                                        (Factorial(ticketNumbers) * Factorial(winNumbers - ticketNumbers));
            return winAndTichetNumbers;
        }

        double CombinationNotOnTicketToNotMatchesNumbers(double NotMatchesNumbers, double NotOnTheTicketNumbers)
        {
            double NotMatchesAndNotTicketNumbers = Factorial(NotMatchesNumbers) /
            (Factorial(NotOnTheTicketNumbers) * Factorial(NotMatchesNumbers - NotOnTheTicketNumbers));

            return Math.Round(NotMatchesAndNotTicketNumbers);
        }
    }
}
