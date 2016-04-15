using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            int index = 0;
            Assert.AreEqual(3, Calculate("+ 15 -12", ref index));
        }

        [TestMethod]
        public void SubtractionTest()
        {
            int index = 0;
            Assert.AreEqual(14, Calculate("- 25 11", ref index));
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            int index = 0;
            Assert.AreEqual(-28, Calculate("* -7 4", ref index));
        }

        [TestMethod]
        public void DivisionTest()
        {
            int index = 0;
            Assert.AreEqual(11, Calculate("/ 55 5", ref index));
        }

        [TestMethod]
        public void CalculateTheExpressionTest()
        {
            int index = 0;
            Assert.AreEqual(18.75, Calculate("+ / * + 5 4 6 3 - 1 0.25", ref index));
        }

        double Calculate(string input, ref int index)
        {
            string[] elements = input.Split(' ');
            string currentElement = elements[index++];
            double number;
            if (Double.TryParse(currentElement, out number))
            {
                return number;
            }

            switch (currentElement)
            {
                case "+": return Calculate(input, ref index) + Calculate(input, ref index);
                case "-": return Calculate(input, ref index) - Calculate(input, ref index);
                case "*": return Calculate(input, ref index) * Calculate(input, ref index);
                default: return Calculate(input, ref index) / Calculate(input, ref index);
            }
        }

    }
}
