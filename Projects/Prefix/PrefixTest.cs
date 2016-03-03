using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prefix
{
    [TestClass]
    public class PrefixTest
    {
        [TestMethod]
        public void CommonPrefix()
        {
            string[]  expected = new[] {"aaa"};
            string[]  actual = new[] { FindCommonPrefix("aaab", "aaaabbaa") };

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NoCommonPrefixFound()
        {
            string[] expected = new[] { "" };
            string[] actual = new[] { FindCommonPrefix("aaba", "xyz") };

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CommonPrefixFoundSameLength()
        {
            string[] expected = new[] { "aa" };
            string[] actual = new[] { FindCommonPrefix("aaba", "aaab") };

            CollectionAssert.AreEqual(expected, actual);
        }
        String FindCommonPrefix(string firstWord, string secondWord)
        {
            string commonPrefix = "";
            int i = 0;
            while ((i < firstWord.Length) && (i<secondWord.Length))
            {
                if (firstWord[i] == secondWord[i])
                    commonPrefix += firstWord[i];
                i++;
               
                    }     
            return commonPrefix;
        }
    }
}
