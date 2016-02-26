using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Melon
{
    [TestClass]
    public class MelonTest
    {
        [TestMethod]
        public void AnEvenNumberOfKilos()
        {
            Assert.AreEqual("YES", HasAnEvenNumberOfKilos(26));
        }

        [TestMethod]
        public void AnOddNumberOfKilos()
        {
            Assert.AreEqual("NO", HasAnEvenNumberOfKilos(15));
        }
        string HasAnEvenNumberOfKilos(int numberOfKilos)
        {
            string output = "";
            int halfPartOfMelon = numberOfKilos / 2;
            if (numberOfKilos % 2 == 0)
            {
                if (halfPartOfMelon % 2 != 0)
                {
                    int halfPartForFirstFriend = halfPartOfMelon + halfPartOfMelon % 2;
                    int halfPartForSecondFriend = halfPartOfMelon - halfPartOfMelon % 2;
                    return output = "YES";
                }
                else return output = "YES";
            }
            else output = "NO";
            return output;
        }
    }
}
