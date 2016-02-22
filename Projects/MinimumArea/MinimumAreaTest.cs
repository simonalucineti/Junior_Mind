using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinimumArea
{
    [TestClass]
    public class MinimumAreaTest
    {
        [TestMethod]
        public void MinimumArea()
        {
            float minArea = CalculateMinimumArea(1, 3, 0, -2, 1, 4);
            Assert.AreEqual(0.5, minArea);
        }
        float CalculateMinimumArea(float firstLandmarkX, float firstLandmarkY, float secondLandmarkX, float secondLandmarkY, float thirdLandmarkX, float thirdLandmarkY)
        {
            return (Math.Abs((firstLandmarkX* secondLandmarkY)+(secondLandmarkX* thirdLandmarkY)+(thirdLandmarkX* firstLandmarkY)-(secondLandmarkY* thirdLandmarkX)- (thirdLandmarkY * firstLandmarkX)- (firstLandmarkY * secondLandmarkX)))/2;
        }
    }
}
