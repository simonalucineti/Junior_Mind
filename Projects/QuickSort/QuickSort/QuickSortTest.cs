using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace QuickSort
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void QuickSortTest1()
        {
            int[] actual = new int[] { 5, 12, 3, 7, 1, 8 };
            int[] expected = new int[] { 1, 3, 5, 7, 8, 12 };
            MyQuickSort(ref actual, 0, 5);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QuickSortTest2()
        {
            double[] actual = new double[] { 5, 12.84, 3.31, -5.11,8 };
            double[] expected = new double[] {-5.11, 3.31, 5, 8, 12.84};
            MyQuickSort(ref actual, 0, 4);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QuickSortTest3()
        {
            string [] actual = new string [] { "abaa","aabcdef","acba","aaa","aa"};
            string [] expected = new string[] { "aa","aaa","aabcdef", "abaa","acba"};
            MyQuickSort(ref actual, 0, 4);
            CollectionAssert.AreEqual(expected, actual);
        }
        void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        int Partition<T> (ref T[] input, int lower, int upper)
        {
            int i = lower-1;
            int pivot = upper;
            for (int j = lower; j < upper; j++)
            {
               if (Comparer<T>.Default.Compare(input[j], input[pivot]) < 0)
                {
                    Swap(ref input[j], ref input[++i]);
                }
            }
            Swap(ref input[i+1], ref input[upper]);
            return i+=1;
        }
           
        void MyQuickSort<T>(ref T[] input, int lower, int upper)
        {
            if (lower < upper)
            {
                int q = Partition(ref input, lower, upper);
                MyQuickSort(ref input, lower, q - 1);
                MyQuickSort(ref input, q + 1, upper);
            }
        }

    }
}
