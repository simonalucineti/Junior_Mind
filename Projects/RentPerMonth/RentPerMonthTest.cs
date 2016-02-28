using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RentPerMonth
{
    [TestClass]
    public class RentPerMonthTest
    {
        [TestMethod]
        public void AmountOfPaymentForAMinimumPeriodOfDelay()
        {
            Assert.AreEqual(102, CalculateTotalAmountOfPayment(100,1));
        }
        [TestMethod]
        public void AmountOfPaymentForAMediumPeriodOfDelay()
        {
            Assert.AreEqual(105, CalculateTotalAmountOfPayment(100, 11));
        }
        decimal CalculateTotalAmountOfPayment(int rentPerMonth, int lateDays)
        {
            var minimumPenalties = rentPerMonth * 2 / 100;
            var mediumPenalties = rentPerMonth * 5 / 100;
            var maximumPenalties = rentPerMonth * 10 / 100;
            decimal penalties = lateDays > 10 ? mediumPenalties : minimumPenalties;
            return rentPerMonth + penalties;
        }
    }
}
