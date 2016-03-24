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
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0 }, ConvertFromBaseTenInAnother(4, 2));
        }
        [TestMethod]
        public void OperationNotTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0 }, OperationNot(new byte[] { 1, 0, 1 }));
        }
        [TestMethod]
        public void ReturnArrayWithZeroAtBeginningTest1()
        {
            Assert.AreEqual((byte)0, AddZeroForTheShorter(new byte[] { 1, 1 }, 5));
        }

        [TestMethod]
        public void ReturnArrayWithZeroAtBeginningTest2()
        {
            Assert.AreEqual((byte)1, AddZeroForTheShorter(new byte[] { 1, 1, 1, 0 }, 3));
        }

        [TestMethod]
        public void EliminateZeroFromBeginningTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1 }, EliminateZeroFromBeginning(new byte[] { 0, 0, 1, 0, 1 }));
        }

       [TestMethod]
        public void AndOperationTest()
        {
            CollectionAssert.AreEqual(new byte[] {0, 1, 0, 0 }, ExecuteSelectDecision(new byte[] { 1,0,1 }, new byte[] { 1,1,1,0}, "AND"));
        }

        [TestMethod]
        public void OrOperationTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 1,1 }, ExecuteSelectDecision(new byte[] { 1, 0, 1,1 }, new byte[] { 0,0,1}, "OR"));
        }

        [TestMethod]
        public void XorOperationTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 1 }, ExecuteSelectDecision(new byte[] { 1, 1, 0 }, new byte[] { 1, 0, 1 }, "XOR"));
        }
        [TestMethod]
        public void LeftShiftOperationTest1()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0 }, UseShiftOperation(new byte[] { 0, 1, 0, 1, 0, 1 },"LEFT", 4));
        }
        [TestMethod]
        public void RightShiftOperationTest2()
        {
            CollectionAssert.AreEqual(new byte[] {0, 0, 0, 1, 0, 1 }, UseShiftOperation(new byte[] { 1, 0, 1 }, "RIGHT", 3));
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

        byte AddZeroForTheShorter(byte[] array, int i)
        {
            if (i < array.Length)
                return array[array.Length - i - 1];
            return (byte)0;
        }

        byte[] EliminateZeroFromBeginning(byte[] array)
        {
            int i;

            for (i = 0; i < array.Length; i++)
            {
                if (array[i] != 0) break;
            }
            byte[] withoutZero = new byte[array.Length - i];
            for (int k = i; k < array.Length; k++)
            {
                withoutZero[k - i] = array[k];
            }
            return withoutZero;
        }

        byte SelectLogicalOperation(byte x, byte y, string decision)
        {
            if (decision == "AND") return x == (byte)1 && y == (byte)1 ? (byte)1 : (byte)0;
            if (decision == "OR")  return x == (byte)1 || y == (byte)1 ? (byte)1 : (byte)0;
            if (decision == "XOR") return x == y ? (byte)0 : (byte)1;
            return 0;
         }

         byte[] ExecuteSelectDecision (byte [] firstArray, byte[] secondArray, string decision)
        {
            byte[] result =new byte [Math.Max(firstArray.Length, secondArray.Length)];
            for (int i=0; i<result.Length; i++)
            {
                result[i] = SelectLogicalOperation(AddZeroForTheShorter(firstArray, i), AddZeroForTheShorter(secondArray, i), decision);
            }
            return Reverse(result);
        }

        byte[] UseShiftOperation(byte [] array, string shift, int steps)
        {
            if (shift == "LEFT")
            {
                Array.Resize(ref array, array.Length + steps);
                return array;
            }

            else if (shift == "RIGHT")
            {
                byte[] result = new byte[array.Length + steps];
                for (int i = 0; i < result.Length; i++)
                {
                    if (i < steps) result[i] = 0;
                    else result[i] = array[i - steps];
                }
                return result;
            }
            return new byte[] {0};
        }
    }
}
