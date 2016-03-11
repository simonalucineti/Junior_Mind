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
    }
}
