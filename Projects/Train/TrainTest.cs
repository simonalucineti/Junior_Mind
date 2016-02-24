using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Train
{
    [TestClass]
    public class TrainTest
    {
        [TestMethod]
        public void FlightDistanceBetweenTwoTrains()
        {
            float flightDistance = CalculateFlightDistance(50);
                Assert.AreEqual(25, flightDistance);
        }
        float CalculateFlightDistance(float distance)
        {
            return distance / 2;
        }
    }
}
