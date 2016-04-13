using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci
{
    [TestClass]
    public class FibonacciTest
    {
        [TestMethod]
        public void FindFibonacciTest1()
        {
            Assert.AreEqual(1, FindFibonacci(1));
        }

        [TestMethod]
        public void FindFibonacciTest2()
        {
            Assert.AreEqual(5, FindFibonacci(5));
        }

        int FindFibonacci(int n)
        {
            return ((n == 0) || (n == 1)) ? n : FindFibonacci(n - 1) + FindFibonacci(n - 2);
        }
    }
    
}
