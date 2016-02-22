using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parquet
{
    [TestClass]
    public class ParquetTest
    {
        [TestMethod]
        public void ParquetFlooring()
        { 
            double necessaryQuantity = DetermineTheQuantityOfTheParquet(5,3,0.30,0.05,15);
            Assert.AreEqual(1150, necessaryQuantity);
        }
        double DetermineTheQuantityOfTheParquet(double roomLength, double roomWidth, double parquetLength, double parquetWidth, double loss)
        {
            double roomArea = roomLength * roomWidth;
            double parquetArea = parquetLength * parquetWidth;
            double installationloss = roomArea * loss / 100;
            return (roomArea + installationloss) / parquetArea;
        }
            }
}
