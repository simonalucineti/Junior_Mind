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
        int DetermineTheNextMeeting(int frequentedByFriend, int frequentedByMe) {
            //c.m.m.m.c a doua numere
            var fFriend = frequentedByFriend;
            var fMe = frequentedByMe;
            while (fMe != 0)
            {
               int restOfDivison = fFriend % fMe;
                fFriend = fMe;
                fMe = restOfDivison;
            }
            return (frequentedByFriend*frequentedByMe)/fFriend;
        }
    }
}
