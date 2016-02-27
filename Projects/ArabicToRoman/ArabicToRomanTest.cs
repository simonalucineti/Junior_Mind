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
        [TestMethod]
        public void NumberIsLessThanAThousand()
        {
            Assert.AreEqual("XLIX", ConvertArabicToRoman(49));
        }
        string ConvertArabicToRoman(int number)
        {

            string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] tens = { "","X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            return tens[number/10]+units[number%10];
        }
    }
}
