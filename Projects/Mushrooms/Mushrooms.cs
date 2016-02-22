using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mushrooms
{
    [TestClass]
    public class Mushrooms
    {
        [TestMethod]
        public void RedMushrooms()
        {
            int redMushrooms = CalculateRedMushrooms(320, 7);
            Assert.AreEqual(280, redMushrooms);
        }
        int CalculateRedMushrooms( int total, int multiplier)
        {
            int whiteMushrooms = total / (multiplier + 1);
            return multiplier*whiteMushrooms;
        }
    }
}
