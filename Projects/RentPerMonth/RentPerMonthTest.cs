using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RentPerMonth
{
    [TestClass]
    public class RentPerMonthTest
    {
        [TestMethod]
        public void AmountOfPaymentForAShortPeriodOfDelay()
        {
            Assert.AreEqual(102, CalculateTotalAmountOfPayment(100,1));
        }
        [TestMethod]
        public void AmountOfPaymentForAMediumPeriodOfDelay()
        {
            Assert.AreEqual(105, CalculateTotalAmountOfPayment(100, 11));
        }

        [TestMethod]
        public void AmountOfPaymentForALongPeriodOfDelay()
        {
            Assert.AreEqual(110, CalculateTotalAmountOfPayment(100, 31));
        }
        decimal CalculateTotalAmountOfPayment(int rentPerMonth, int lateDays)
        {
            var minimumPenalties = rentPerMonth * 2 / 100;
            var mediumPenalties = rentPerMonth * 5 / 100;
            var maximumPenalties = rentPerMonth * 10 / 100;
             
            decimal penalties = minimumPenalties;

            if (IsAMediumPeriodOfDelay(lateDays))
                penalties = mediumPenalties;
            if (IsALongPeriodOfDelay(lateDays))
                penalties = maximumPenalties;
            var totalAmountOfPayment= rentPerMonth + penalties;
            return totalAmountOfPayment;
        }

        private static bool IsAMediumPeriodOfDelay(int lateDays)
        {
            return lateDays > 10;
        }
        private bool IsALongPeriodOfDelay(int lateDays)
        {
            return lateDays > 30;
        }
    }

}
