using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReplaceChar
{
    [TestClass]
    public class ReplaceCharTest
    {
        [TestMethod]
        public void ReplaceCharTest1()
        {
            Assert.AreEqual("yyyapayyy", ReplaceChar("capac", 'c', "yyy"));
        }

        [TestMethod]
        public void ReplaceCharTest2()
        {
            Assert.AreEqual("cyyypyyyc", ReplaceChar("capac", 'a', "yyy"));
        }

        [TestMethod]
        public void ReplaceCharTest3()
        {
            Assert.AreEqual("cazzzzac", ReplaceChar("capac", 'p', "zzzz"));
        }

        [TestMethod]
        public void ReplaceCharTest4()
        {
            Assert.AreEqual("a", ReplaceChar("b", 'b', "a"));
        }

        string ReplaceChar (string input, char letter, string replace)
        {
            var l = input[input.Length - 1];
            if (input.Length <= 1)
            {
                return (input[0] == letter) ? replace : input;
            }
            if (input[input.Length - 1] == letter)
            {
                return ReplaceChar(input.Substring(0, input.Length - 1), letter, replace) + replace;
            }
            return ReplaceChar(input.Substring(0, input.Length - 1), letter, replace) + l;
        }
    }
}
