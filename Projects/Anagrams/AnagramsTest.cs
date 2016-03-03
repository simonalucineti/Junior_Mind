using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class AnagramsTest
    {
        [TestMethod]
        public void CannotGenerateAnagrams()
        {
            Assert.AreEqual(1, GenerateAnagrams("aaaa"));
        }
        [TestMethod]
        public void AllLettersOfTheWordAreDifferent()
        {
            Assert.AreEqual(6, GenerateAnagrams("xyz"));
        }
        int GenerateAnagrams (string word)
        {
            int numberOfAnagrams=1;
            int factorial = 1;
            int count = 0;
            int n = word.Length;

            for (int i=1; i<n; i++)
            {
                factorial += i * i;
               
            }
            for (int i = 0; i < n-1; i++)
            {
                if (word[i] == word[i + 1])
                    count++;
            }
            if (count == n)
                numberOfAnagrams = 1;
           else if (count == 0)
                numberOfAnagrams = factorial;

            return numberOfAnagrams;
        }
    }
}
