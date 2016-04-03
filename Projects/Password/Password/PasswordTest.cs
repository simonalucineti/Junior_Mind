using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class PasswordTest
    {
        public struct PasswordOptions
        {
            public int smallChars;
            public int upperChars;
            public int numbers;
            public int symbols;
            public bool notSimilar;
            public bool notAmbigue;

            public PasswordOptions (int smallChars, int upperChars, int numbers, int symbols,
                            bool notSimilar, bool notAmbigue)
            {
                this.smallChars = smallChars;
                this.upperChars = upperChars;
                this.numbers = numbers;
                this.symbols = symbols;
                this.notSimilar = notSimilar;
                this.notAmbigue = notAmbigue;
            }

        }

        [TestMethod]
        public void TestCountNumbers()
        {
            Assert.AreEqual(4, CountNumbers("ana23are56mere"));
        }

        [TestMethod]
        public void TestCountUpperLetters()
        {
            Assert.AreEqual(6, CountUpperLetters("aNA23aRe56mERE"));
        }

        [TestMethod]
        public void CountSymbolsTest()
        {
            Assert.AreEqual(7, CountSymbols("{}ls@uOpo0er[]r()"));
        }

        [TestMethod]
        public void NotRestrictedTest()
        {
            Assert.AreEqual("superr", NotRestricted("{}ls1uOpo0er[]r()~", "{}[]()/\'~,;.<>l1IoO0"));
        }

        Random random = new Random();

        int CountNumbers(string password)
        {
            int count = 0;
            for (int i=0; i< password.Length; i++)
            {
                if (char.IsDigit(password[i])) count++;
            }
            return count;
        }

        int CountUpperLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i])) count++;
            }
            return count;
        }

       int CountSymbols( string password)
        {
            int count = 0;
            string symbol = "!@#$%^&*()_\\-+={}[]:;'\"|,./<>?~";
            foreach (char c in password)
            {

                if (symbol.Contains(c.ToString())) count++;
            }
            
            return count;
        }

        string NotRestricted(string password, string restricts)
        {
            string result = "";
            foreach (char c in password)
            {

                if (!restricts.Contains(c.ToString())) result += c;
            }
            return result;
        }

        
    }
}
