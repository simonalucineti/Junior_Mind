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

            public Cyclist(string name, int[] rotationsPerSecond, int wheelDiameter)
            {
                this.name = name;
                this.rotationsPerSecond = rotationsPerSecond;
                this.wheelDiameter = wheelDiameter;
            }
        }

        struct Result
        {
            public string name;
            public int maxSecond;
           // public int position;
        public Result (string name, int maxSecond)
            {
                this.name = name;
                this.maxSecond = maxSecond;
               // this.position = position;
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
            var distance = new Cyclist("Andreea", new int[] { 2, 2 }, 50);
            Assert.AreEqual(628, DetermineTotalDistanceForACyclist(distance));
        }

        [TestMethod]
        public void DetermineTotalDistanceForAllTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Andreea", new int[] { 2, 2}, 50),
                                           new Cyclist("Ciprian", new int[] { 1, 1, 2}, 50),
                                           new Cyclist("Maria", new int[] { 1, 2}, 50)};
            Assert.AreEqual(1727, DetermineTotalDistanceForAll(cyclists));
        }

        [TestMethod]
        public void FindSecondOfMaxSpeedTest()
        {
            var cyclist = new Cyclist("Andreea", new int[] { 1, 2, 5, 1, 4, 2, 3 }, 50);
            Assert.AreEqual(2, FindSecondForMaxSpeed(cyclist));
        }

        [TestMethod]
        public void FindSecondAndNameForMaxSpeedTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Andreea", new int[] { 1,3,2,5,1}, 50),
                                           new Cyclist("Ciprian", new int[] { 1, 2, 5}, 60),
                                           new Cyclist("Maria", new int[] { 1,5,1,3,2}, 65)};
            
            var result = new Result ("Maria", 1);
          
           Assert.AreEqual(result, FindSecondAndNameForMaxSpeed (cyclists));
        }

        [TestMethod]
        public void FindBestAvgSpeedTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Andreea", new int[] { 1,1,2,1}, 50),
                                           new Cyclist("Ciprian", new int[] { 1, 2, 2}, 60),
                                           new Cyclist("Maria", new int[] { 1,1,1,2}, 55)};
           
            Assert.AreEqual("Ciprian", FindCyclistWithBestAvgSpeed(cyclists));
        }

        double CalculateDistancePerSecond(int rotationsPerSecond, int wheelDiameter)
        {
            return Math.Round(Math.PI * wheelDiameter * rotationsPerSecond);
        }
        double DetermineTotalDistanceForACyclist(Cyclist cyclist)
        {
            double totalDistance = 0;
            for (int i = 0; i < cyclist.rotationsPerSecond.Length; i++)
            {
                totalDistance += CalculateDistancePerSecond(cyclist.rotationsPerSecond[i], cyclist.wheelDiameter);
            }
            return totalDistance;
        }
        double DetermineTotalDistanceForAll(Cyclist[] cyclist)
        {
            double totalDistance = 0;
            for (int i = 0; i < cyclist.Length; i++)
            {
                totalDistance += DetermineTotalDistanceForACyclist(cyclist[i]);
            }
            return totalDistance;
        }

        int FindSecondForMaxSpeed(Cyclist cyclist)
        {
            int second = 0;
            for (int i = 1; i < cyclist.rotationsPerSecond.Length; i++)
            {
                if (cyclist.rotationsPerSecond[i] > cyclist.rotationsPerSecond[second]) 
                    // second = cyclist.rotationsPerSecond[i];
                    second = i;
            }
            return second;
        }
      Result FindSecondAndNameForMaxSpeed(Cyclist[] cyclist)
        {
            int maxSecond = 0;
            double maxSpeed = 0;
            string name = "";
           

            for (int i = 0; i < cyclist.Length; i++)
            {
                int second = FindSecondForMaxSpeed(cyclist[i]);
                double speed = CalculateDistancePerSecond(cyclist[i].rotationsPerSecond[second], cyclist[i].wheelDiameter);
                
                if (speed > maxSpeed)
                {
                    maxSpeed = speed;
                    maxSecond = second;
                    name = cyclist[i].name;
                }
            }
            return new Result (name, maxSecond);
        }
        string FindCyclistWithBestAvgSpeed(Cyclist[] cyclist)
        {
            double bestAvgDistance = 0;
            string bestCyclist = "";
            for (int i=0; i<cyclist.Length; i++)
            {
                int time = cyclist[i].rotationsPerSecond.Length;
                double actualAvgDistance = DetermineTotalDistanceForACyclist(cyclist[i]) / time;
                if (actualAvgDistance > bestAvgDistance)
                {
                    bestAvgDistance = actualAvgDistance;
                    bestCyclist = cyclist[i].name;
                }
            }
            return bestCyclist;
        }
     

    }
}
