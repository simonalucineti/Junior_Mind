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
       decimal CalculateTotalAmountOfPayment(int rentPerMonth, int lateDays)
        {

            decimal penalties = rentPerMonth * 2/100;
            return rentPerMonth + penalties;
        }
    }
}
