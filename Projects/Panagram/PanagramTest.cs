using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class PanagramTest
    {
        [TestMethod]
        public void IsAPanagram()
        {
            string expected = "Is A Panagram" ;
            string actual = DetermineIfIsAPanagram("the quick brown fox jumps over the lazy dog");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsAPanagramUpperCase()
        {
            string expected = "Is A Panagram";
            string actual = DetermineIfIsAPanagram("The QUICK brown FoX juMPs over the lAZy dog");

            Assert.AreEqual(expected, actual);
        }
        string DetermineIfIsAPanagram (string phrase)
        {
            string answer = "";
            int[] apparition = new int[26];
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] >= 'a' && phrase[i] <= 'z')
                    apparition[phrase[i] - 'a']++;
                else  if (phrase[i] >= 'A' && phrase[i] <= 'Z')
                    apparition[phrase[i] - 'A']++;
            }
            answer = CheckApparition(answer, apparition);

            return answer;
        }

        private static string CheckApparition(string answer, int[] apparition)
        {
            bool findChar = true;
            for (int i = 0; i <= 25; i++)
            {
                findChar = false;
                if (apparition[i] != 0)
                    findChar = true;
            }
            if (findChar)
                answer += "Is A Panagram";
            else
                answer += "Is Not A Panagram";
            return answer;
        }
    }
}
