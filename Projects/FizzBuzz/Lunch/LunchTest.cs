using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunch
{
    [TestClass]
    public class LunchTest
    {
        [TestMethod]
        public void LunchToTheRestaurant()
        {
            Assert.AreEqual(12, DetermineTheNextMeeting(6, 4));
        }
        int DetermineTheNextMeeting(int hisNumber, int myNumber) {
            //c.m.m.m.c a doua numere
            var friend = hisNumber;
            var i = myNumber;
            while (i != 0)
            {
               int restOfDivison = friend % i;
                friend = i;
                i = restOfDivison;
            }
            return (hisNumber*myNumber)/friend;
        }
    }
}
