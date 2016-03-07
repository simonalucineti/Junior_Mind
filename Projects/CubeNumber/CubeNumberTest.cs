using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubeNumber
{
    [TestClass]
    public class CubeNumberTest
    {
        [TestMethod]
        public void TheSecondNumber()
        {
            
            Assert.AreEqual (442, DetermineTheCubeOfKNumberThatEndingInASpecificFormat(2));
        }
        [TestMethod]
        public void TheFourthNumber()
        {
            Assert.AreEqual (942, DetermineTheCubeOfKNumberThatEndingInASpecificFormat(4));
        }
        double DetermineTheCubeOfKNumberThatEndingInASpecificFormat (int k)
        {
            int number = 192;
            int check = 1;
            double cube=0;
           
            while (check < k)
            {
                number++;
                cube = Math.Pow(number,3);
                if (cube % 1000 == 888)
                    check++;
            }
            return number;
        }
    }
}
