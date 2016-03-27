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
            CollectionAssert.AreEqual(ToBinary(9 & 12), And(ToBinary(9), ToBinary(12)));
        }

        [TestMethod]
        public void OrOperationTest()
        {
            CollectionAssert.AreEqual(ToBinary(1 | 11), Or(ToBinary(1), ToBinary(11)));
        }

        [TestMethod]
        public void XorOperationTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 1 }, Xor(ToBinary(5), ToBinary(6)));
        }
        [TestMethod]
        public void LeftShiftOperationTest1()
        {
            CollectionAssert.AreEqual(ToBinary(15<<4), UseShiftOperation(ToBinary(15), "LEFT", 4));
        }
        [TestMethod]
        public void RightShiftOperationTest2()
        {
            CollectionAssert.AreEqual(ToBinary(10>>3), UseShiftOperation(ToBinary(10), "RIGHT", 3));
        }
        [TestMethod]
        public void RightShiftOperationTest3()
        {
            CollectionAssert.AreEqual(ToBinary(4 >> 2), UseShiftOperation(ToBinary(4), "RIGHT", 2));
        }

        [TestMethod]
        public void LessThanOperationTest1()
        {
            Assert.AreEqual(true, LessThanOperation(ToBinary(1), ToBinary(2)));
        }
        [TestMethod]
        public void LessThanOperationTest2()
        {
            Assert.AreEqual(false, LessThanOperation(ToBinary(5), ToBinary(4)));
        }

        [TestMethod]
        public void EqualToOperationTest1()
        {
            Assert.AreEqual(true, EqualToOperation(ToBinary(10), ToBinary(10)));
        }
        [TestMethod]
        public void EqualToOperationTest2()
        {
            Assert.AreEqual(false, EqualToOperation(ToBinary(11), ToBinary(7)));
        }

        [TestMethod]
        public void GreaterThanOperationTest1()
        {
            Assert.AreEqual(false, GreaterThanOperation(ToBinary(9), ToBinary(9)));
        }
        [TestMethod]
        public void GreaterThanOperationTest2()
        {
            Assert.AreEqual(true, GreaterThanOperation(ToBinary(7), ToBinary(6)));
        }

        [TestMethod]
        public void NotEqualOperationTest1()
        {
            Assert.AreEqual(false, NotEqualOperation(ToBinary(12), ToBinary(12)));
        }
        [TestMethod]
        public void NotEqualOperationTest2()
        {
            Assert.AreEqual(true, NotEqualOperation(ToBinary(13), ToBinary(21)));
        }

        [TestMethod]
        public void AddOperationTest1()
        {
            CollectionAssert.AreEqual(ToBinary(121+19), Add(ToBinary(121), ToBinary(19), 2));
        }

        [TestMethod]
        public void SubstractionTest1()
        {
            CollectionAssert.AreEqual(ToBinary(14-8), Substraction(ToBinary(14), ToBinary(8), 2));
        }

        [TestMethod]
        public void SubstractionTest2()
        {
            CollectionAssert.AreEqual(ToBinary(171 - 128), Substraction(ToBinary(128), ToBinary(171), 2));
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

        byte[] ToBinary(int number)
        {
            return ConvertFromBaseTenInAnother(number, 2);
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
            if (decision == "OR") return x == (byte)1 || y == (byte)1 ? (byte)1 : (byte)0;
            if (decision == "XOR") return x == y ? (byte)0 : (byte)1;
            return 0;
        }

        byte[] ExecuteSelectDecision(byte[] first, byte[] second, string decision)
        {
            byte[] result = new byte[Math.Max(first.Length, second.Length)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = SelectLogicalOperation(AddZeroForTheShorter(first, i), AddZeroForTheShorter(second, i), decision);
            }
            return Reverse(result);
        }

        byte[] And(byte[] firstArray, byte[] secondArray)
        {
            return ExecuteSelectDecision(firstArray, secondArray, "AND");
        }
        byte[] Or(byte[] firstArray, byte[] secondArray)
        {
            return ExecuteSelectDecision(firstArray, secondArray, "OR");
        }
        byte[] Xor(byte[] firstArray, byte[] secondArray)
        {
            return ExecuteSelectDecision(firstArray, secondArray, "XOR");
        }
        
        byte[] UseShiftOperation(byte[] array, string shift, int steps)
        {
            if (shift == "LEFT")
            {
                Array.Resize(ref array, array.Length + steps);
                return array;
            }

            else if (shift == "RIGHT")
            {

                Array.Resize(ref array, array.Length - steps);
                return array;
            }
            return new byte[] { 0 };
        }

        public bool LessThanOperation(byte[] first, byte[] second)
        {
            first = EliminateZeroFromBeginning(first);
            second = EliminateZeroFromBeginning(second);
            if (first.Length < second.Length) return true;
            if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                    if (first[i] < second[i]) return true;
            }
            return false;
        }

        public bool EqualToOperation(byte[] first, byte[] second)
        {
            if (!(LessThanOperation(first, second)) &&
               !(LessThanOperation(second, first))) return true;
            return false;
        }

        public bool GreaterThanOperation(byte[] first, byte[] second)
        {
            return LessThanOperation(second, first);
        }

        public bool NotEqualOperation(byte[] first, byte[] second)
        {
            return !(EqualToOperation(first, second));
        }

        byte[] Add(byte[] first, byte[] second, int radix)
        {
            byte[] result = new byte[Math.Max(first.Length, second.Length) + 1];
            int carry = 0;
            int sum = 0;
            for (int i = result.Length - 1; i >= 0; i--)
            {
                sum = AddZeroForTheShorter(first, result.Length - i - 1) +
                      AddZeroForTheShorter(second, result.Length - i - 1) + carry;
                carry = sum / radix;
                result[i] = (byte)(sum % radix);
            }
            return EliminateZeroFromBeginning(result);
        }

        public byte[] Substraction(byte[] first, byte[] second, int radix)
        {
            int sub = 0;
            int carry = 0;

            if (EqualToOperation(first, second)) return new byte[] {0};
            byte[] subtrahend = new byte[] { };
            byte[] low = new byte[] { };
            subtrahend = GreaterThanOperation(first, second) ? first : second;
            low = LessThanOperation(first, second) ? first : second;
            low = UseShiftOperation(low, "RIGHT", subtrahend.Length - low.Length);
            byte[] result = new byte[subtrahend.Length];
           

            for (int i = subtrahend.Length - 1; i >= 0; i--)
            {
                sub  = subtrahend [i] - low [i] - carry;
                carry = 0;
                if (sub < 0)
                {
                    carry++;
                    sub = radix - (low[i] - subtrahend[i]);
                    result[i] = (byte)sub;
                }
                else result[i] = (byte)sub;
            }
            return EliminateZeroFromBeginning(result); 
        }
    }
 }
    

