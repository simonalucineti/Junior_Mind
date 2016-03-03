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
        int GenerateAnagrams (string word)
        {
            int numberOfAnagrams;
            return numberOfAnagrams=1;
        }
    }
}
