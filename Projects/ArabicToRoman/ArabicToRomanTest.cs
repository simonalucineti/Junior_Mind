using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArabicToRoman
{
    [TestClass]
    public class ArabicToRomanTest
    {
        [TestMethod]
        public void NumberIsLessThanTen()
        {
            Assert.AreEqual("V", ConvertArabicToRoman(5));
        }
        string ConvertArabicToRoman(int number)
        {

            string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            return units[number];
        }
    }
}
