using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base_Conversion
{
    [TestClass]
    public class ConversionTest
    {
        [TestMethod]
        public void ReverseTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0 }, Reverse(new byte[] { 0, 0, 1 }));
        }
        [TestMethod]
        public void ConvertingADecimalNumberInAnotherBaseTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0 }, ConvertFromBaseTenInAnother(4,2));
        }
        [TestMethod]
        public void OperationNotTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0 }, OperationNot(new byte[] { 1, 0, 1 }));
        }


        byte[] Reverse(byte[] array)
        {
            byte[] reverseArray = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
                reverseArray[i] = array[array.Length - i - 1];
            return reverseArray;
        }
        byte[] ConvertFromBaseTenInAnother(int number, int radix)
        {
            byte[] numberConverted = { };
            while (number != 0)
            {
                Array.Resize(ref numberConverted, numberConverted.Length + 1);
                numberConverted[numberConverted.Length - 1] = (byte)(number % radix);
                number /= radix;
            }
            return Reverse(numberConverted);

        }
        byte[] OperationNot(byte[] array)
        {
           
           for (int i = 0; i < array.Length; i++)
                array[i] = (array[i] == 0) ? (byte)1 : (byte)0;
            return array;
        }
    }
}
