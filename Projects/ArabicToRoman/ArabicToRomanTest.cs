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
            Assert.AreEqual("V", ConvertArabicNumbersToRomanNumerals(5));
        }
        [TestMethod]
        public void NumberIsLessThanAThousand()
        {
            Assert.AreEqual("XLIX", ConvertArabicNumbersToRomanNumerals(49));
        }
        [TestMethod]
        public void NumberIsEqualToAThousand()
        {
            Assert.AreEqual("C", ConvertArabicNumbersToRomanNumerals(100));
        }
        string ConvertArabicNumbersToRomanNumerals(int number)
        {

            string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] tens = { "","X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] thousand = { "", "C" };
            return thousand[number/100]+tens[(number/10)%10]+units[number%10];
        }
    }
}
