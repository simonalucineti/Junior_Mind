using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goats
{
    [TestClass]
    public class GoatsTest
    {
        [TestMethod]
        public void KilosOfHayForActualNumberOfGoats()
        {
            int actualKilosOfHay = CalculateForageSupply(3, 5, 105, 7, 9);
            Assert.AreEqual(441, actualKilosOfHay);
        }
        int CalculateForageSupply(int initialDays, int initialNumberOfGoats, int initialForage, int actualDays, int actualNumberOfGoats)
        {
            int kilosOfHayForInitialNumberOfGoats = (actualDays * initialForage) / initialDays;
            return (actualNumberOfGoats * kilosOfHayForInitialNumberOfGoats) / initialNumberOfGoats;
        }
    }

}
