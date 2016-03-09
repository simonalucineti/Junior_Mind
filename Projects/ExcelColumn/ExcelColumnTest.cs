using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumn
{
    [TestClass]
    public class ExcelColumnTest
    {
        [TestMethod]
        public void FindFirstColumn()
        {
            Assert.AreEqual("A", DetermineExcelColumn(1));
        }
        [TestMethod]
        public void Find29thColumn()
        {
            Assert.AreEqual("AC", DetermineExcelColumn(29));
        }
        [TestMethod]
        public void Find53thColumn()
        {
            Assert.AreEqual("BA", DetermineExcelColumn(53));
        }
        string DetermineExcelColumn(int columnNumber)
        {
            string columnName = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                columnName = GetCharacter(columnNumber) + columnName;
                columnNumber /= 26;
            }

            return columnName; 
        }

        private static char GetCharacter(int number)
        {
            return (char)('A' + columnNumber % 26);
        }
    }
}
