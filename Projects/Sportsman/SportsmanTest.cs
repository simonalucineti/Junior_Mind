using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sportsman
{
    [TestClass]
    public class SportsmanTest
    {
        [TestMethod]
        public void NumberOfReps()
        {
            int reps = CalculateNumberOfReps(16);
            Assert.AreEqual(256,reps);
        }
        int CalculateNumberOfReps(int round)
        {
        return round*round; 
        }
    }
}
