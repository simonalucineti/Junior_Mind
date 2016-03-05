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

        [TestMethod]
        public void IsNotAPanagramLessWords()
        {
            string expected = "Is Not A Panagram";
            string actual = DetermineIfIsAPanagram("FOX jumps over the lazy dog");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotAPanagramNumber()
        {
            string expected = "Is Not A Panagram";
            string actual = DetermineIfIsAPanagram("The QUI12 brown FoX juMPs over the lAZy dog");

            Assert.AreEqual(expected, actual);
        }
        string DetermineIfIsAPanagram (string phrase)
        {
            string answer = "";
            int[] apparition = new int[26];
            CheckCharacters(phrase, apparition);
            answer = CheckApparition(answer, apparition);

            return answer;
        }

        private static void CheckCharacters(string phrase, int[] apparition)
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                if (char.IsNumber(phrase[i])) break;
                else
                {
                    if (phrase[i] >= 'a' && phrase[i] <= 'z')
                        apparition[phrase[i] - 'a']++;
                    else if (phrase[i] >= 'A' && phrase[i] <= 'Z')
                        apparition[phrase[i] - 'A']++;

                }

            }
        }

        private static string CheckApparition(string answer, int[] apparition)
        {
            bool findChar = true;
            int i = 0;
            while (i <=25)
            {
               findChar = false;
                if (apparition[i] != 0)
                    findChar = true;
                else break;
                i++;
            }
            if (findChar)
                answer += "Is A Panagram";
            else
                answer += "Is Not A Panagram";

            return answer;
        }
    }
}
