using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyclometer
{
    [TestClass]
    public class CyclometerTest
    {
        struct Cyclist
        {
            public string name;
            public int[] rotationsPerSecond;
            public int wheelDiameter;

         public Cyclist (string name, int[] rotationsPerSecond, int wheelDiameter)
            {
                this.name = name;
                this.rotationsPerSecond = rotationsPerSecond;
                this.wheelDiameter = wheelDiameter;
            }
        }
        [TestMethod]
        public void CalculateDistancePerSecondTest()
        {
            Assert.AreEqual(314, CalculateDistancePerSecond(2, 50));
        }
        [TestMethod]
        public void DetermineTotalDistanceForACyclistTest()
        {
            var distance = new Cyclist("Andreea", new int[] {2, 2}, 50);
            Assert.AreEqual(628, DetermineTotalDistanceForACyclist(distance));
        }

        [TestMethod]
        public void DetermineTotalDistanceForAllTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Andreea", new int[] { 2, 2}, 50),
                                           new Cyclist("Ciprian", new int[] { 1, 1, 2}, 50),
                                           new Cyclist("Maria", new int[] { 1, 2}, 50)};
            Assert.AreEqual(1727, DetermineTotalDistanceForAll (cyclists));
        }

     double CalculateDistancePerSecond (int rotationsPerSecond, int wheelDiameter)
        {
            return Math.Round(Math.PI * wheelDiameter * rotationsPerSecond);
        }
     double DetermineTotalDistanceForACyclist(Cyclist cyclist)
        {
            double totalDistance = 0;
            for (int i=0; i< cyclist.rotationsPerSecond.Length; i++)
            {
            totalDistance += CalculateDistancePerSecond(cyclist.rotationsPerSecond[i], cyclist.wheelDiameter);
            }
            return totalDistance;
        } 
        double DetermineTotalDistanceForAll(Cyclist[] cyclist)
        {
            double totalDistance = 0;
            for (int i=0; i<cyclist.Length; i++)
            {
                totalDistance += DetermineTotalDistanceForACyclist(cyclist[i]);
            }
            return totalDistance;
        }
    }
}
