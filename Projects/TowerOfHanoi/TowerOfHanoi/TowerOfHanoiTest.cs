using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowerOfHanoi
{
    [TestClass]
    public class TowerOfHanoiTest
    {
        [TestMethod]
        public void TestFor1Disk()
        {
            int[] source = new int[] {7};
            int[] destination = new int[source.Length];
            int[] temp = new int[source.Length];

            CollectionAssert.AreEqual(new int[] {7}, GetTower(1, source, destination, temp));
        }

        [TestMethod]
        public void TestFor3Disk()
        {
            int[] source = new int[] { 8,5,1 };
            int[] destination = new int[source.Length];
            int[] temp = new int[source.Length];

            CollectionAssert.AreEqual(new int[] { 8,5,1 }, GetTower(3, source, destination, temp));
        }

        [TestMethod]
        public void TestFor5Disk()
        {
            int[] source = new int[] {5,4,3,2,1};
            int[] destination = new int[source.Length];
            int[] temp = new int[source.Length];

            CollectionAssert.AreEqual(new int[] { 5,4,3,2,1}, GetTower(5, source, destination, temp));
        }

        int[] GetTower (int disk, int[] source, int[] destination, int[] temp)
        {
            if (disk == 1)
            {
                destination[0] = source[0];
                Array.Resize(ref source, source.Length - 1);
                return destination;
            }
            else
            {
                GetTower(disk - 1, source, temp, destination);
                destination[disk - 1] = source[disk - 1];
                Array.Resize(ref source, source.Length - 1);
                GetTower(disk - 1, temp, destination, source);
                return destination;
            }
        }
    }
}
