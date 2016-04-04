using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class PasswordTest
    {
        public struct Options
        {
            public int smallChars;
            public int upperChars;
            public int numbers;
            public int symbols;
            public bool notSimilar;
            public bool notAmbiquous;

            public Options(int smallChars, int upperChars, int numbers, int symbols,
                            bool notSimilar, bool notAmbiquous)
            {
                this.smallChars = smallChars;
                this.upperChars = upperChars;
                this.numbers = numbers;
                this.symbols = symbols;
                this.notSimilar = notSimilar;
                this.notAmbiquous = notAmbiquous;
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

        [TestMethod]
        public void ReturnAPassOfAGivenLengthTest()
        {
            var password = new Options {smallChars=8,upperChars= 3,numbers=1, symbols=2, notSimilar =false, notAmbiquous = false };
            Assert.AreEqual(14, GeneratePassword(password).Length);
        }
        [TestMethod]
        public void GeneratePasswordWithoutUpperChars()
        {
            var password = new Options(6, 0, 4, 0, false, true);
            Assert.AreEqual(0, CountUpperLetters(GeneratePassword(password)));
        }

        [TestMethod]
        public void GeneratePasswordWithLowerChars()
        {
            var password = new Options(6, 3, 9, 6, true, false);
            Assert.AreEqual(6, CountLowerLetters(GeneratePassword(password)));
        }

        [TestMethod]
        public void GeneratePasswordWithSymbols()
        {
            var password = new Options(1, 5, 4, 2, false, false);
            Assert.AreEqual(2, CountSymbols(GeneratePassword(password)));
        }

        [TestMethod]
        public void GeneratePasswordWithNumbers()
        {
            var password = new Options(7, 0, 4, 6, false, false);
            Assert.AreEqual(4, CountNumbers(GeneratePassword(password)));
        }

        Random random = new Random();

        int CountNumbers(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
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

        int CountLowerLetters(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i])) count++;
            }
            return count;
        }

        int CountSymbols(string password)
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

        string GenerateString(int length, int lower, int upper, bool notAllowed)
        {
            string pass = "";
            string notAllowedString = "l1IoO0{}[]()/\'\"~,;.<> */ ";


            for (int i = 0; i < length; i++)
            {
                char c = (char)random.Next(lower, upper);
                if (notAllowed)
                {
                    pass = NotRestricted(pass, notAllowedString);
                }
                pass += c;
            }
            return pass;
        }
        string GeneratePassword (Options options)
        {
            string password = "";
            password += GenerateString(options.smallChars, 'a', 'z' + 1, options.notAmbiquous);
            password+= GenerateString(options.upperChars, 'A', 'Z' + 1, options.notAmbiquous);
            password += GenerateString(options.numbers, '0', '9' + 1, options.notAmbiquous);
            password += GenerateString(options.symbols, ' ', '/' + 1, options.notSimilar);

            return password;
        }

       
    }
}
