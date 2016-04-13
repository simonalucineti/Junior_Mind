using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inversion
{
    [TestClass]
    public class ReverseTest
    {
        [TestMethod]
        public void ReverseStringTest1()
        {
            Assert.AreEqual("a", ReverseString("a"));
        }

        [TestMethod]
        public void ReverseStringTest2()
        {
            Assert.AreEqual("aeerdna", ReverseString("andreea"));
        }

        string ReverseString (string input)
        {
            var l = input[input.Length - 1];
            return (input.Length == 1) ? input : l + ReverseString(input.Substring(0, input.Length - 1));
        }
    }
}
