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
        String FindCommonPrefix(string firstWord, string secondWord)
        {
            string commonPrefix = "";
            int i=0, j=0;
            while ((i < firstWord.Length) && (j < secondWord.Length))
            {
                if (firstWord[i] == secondWord[j])
                    commonPrefix += firstWord[i];
                i++;
                j++;
            }     
            return commonPrefix;
        }
    }
}
