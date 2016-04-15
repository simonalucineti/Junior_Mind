using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalTriangle
{
    [TestClass]
    public class PascalTriangleTest
    {
        [TestMethod]
        public void GeneratePascalTriangleTest1()
        {
            CollectionAssert.AreEqual(new int[] {1}, GeneratePascalTriangle(0));

        }
        [TestMethod]
        public void GeneratePascalTriangleTest2()
        {
            CollectionAssert.AreEqual(new int[] {1,1}, GeneratePascalTriangle(1));

        }
        [TestMethod]
        public void GeneratePascalTriangleTest3()
        {
            CollectionAssert.AreEqual(new int[] {1,4,6,4,1}, GeneratePascalTriangle(4));
        }

        int[] GeneratePascalTriangle (int level)
        {
            int[] row = new int[level+1];
            if (level == 0)  return new int[] { 1 };
            row[0] = row[level] = 1;
            int[] previous = GeneratePascalTriangle(level - 1);
            for (int i=1; i<level; i++)
            {
                row[i] = previous[i - 1] + previous[i];
            }
            return row;
                   
        }
    }
}
