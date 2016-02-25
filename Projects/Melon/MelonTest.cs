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
            Assert.AreEqual("YES", HasAnEvenNumberOfKilos(20));
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
                output = halfPartOfMelon % 2 == 0 ? "YES" : "NO";
            else output = "NO";
            return output;
        }
    }
}
