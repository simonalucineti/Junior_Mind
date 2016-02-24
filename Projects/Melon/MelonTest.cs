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
            Assert.AreEqual("YES", HasAnEvenNumberOfKilos(12));
        }
        string HasAnEvenNumberOfKilos(int numberOfKilos)
        {
            string output = "";
            output = numberOfKilos % 2 == 0 ? "YES" : "NO";
            return output;
        }
    }
}
