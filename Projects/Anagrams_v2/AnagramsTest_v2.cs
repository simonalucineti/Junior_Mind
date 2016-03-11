using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams_v2
{
    [TestClass]
    public class AnagramsTest_v2
    {
        [TestMethod]
        public void AllLettersAreDistinct()
        {
            Assert.AreEqual(24, GenerateAnagrams("wxyz"));
        }
        [TestMethod]
        public void CalculateFactorial()
        {
            Assert.AreEqual(6, Factorial(3));
        }
        [TestMethod]
        public void DetermineMatches()
        {
            Assert.AreEqual(4, CountMatches("anamaria", 'a'));
        }
        [TestMethod]
        public void DetermineUniques()
        {
            Assert.AreEqual("anmri", FindDistinct("anamaria"));
        }

        int GenerateAnagrams(string word)
        {
            int numberOfAnagrams = 0;
            return numberOfAnagrams = Factorial(word.Length);
        }

        int Factorial(int numberOfChar)
        {
            int factorial = 1;
            for (int i = 1; i <= numberOfChar; i++)
                factorial *= i;

            return factorial;
        }
        int CountMatches(string word, char match)
        {
            int matches = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(match))
                    matches++;
            }
            return matches;
        }

        string FindDistinct(string word)
        {
            string distinct = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (!distinct.Contains(word[i].ToString()))
                    distinct += word[i];
            }

            return distinct;
        }
    }
}
