using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class PanagramTest
    {
        [TestMethod]
        public void IsAPangram()
        {
            bool expected = true;
            bool actual = DetermineIfIsAPangram("the quick brown fox jumps over the lazy dog");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsAPangramUpperCase()
        {
            bool expected = true;
            bool actual = DetermineIfIsAPangram("The QUICK brown FoX juMPs over the lAZy dog");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotAPangramLessWords()
        {
            bool expected = false;
            bool actual = DetermineIfIsAPangram("FOX jumps over the lazy dog");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotAPangramNumber()
        {
            bool expected = false;
            bool actual = DetermineIfIsAPangram("The QUI12 brown FoX juMPs over the lAZy dog");

            Assert.AreEqual(expected, actual);
        }
        bool DetermineIfIsAPangram(string phrase)
        {
            string phraseLowerCase = phrase.ToLower();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            bool findChar = true;
         for (int i = 0; i < alphabet.Length; i++)
            {
                if (phraseLowerCase.IndexOf(alphabet[i]) == -1)
                {
                    findChar = false;
                }
            }
            return findChar;
        }

        
    }
}

    
