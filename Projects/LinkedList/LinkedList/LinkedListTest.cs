using System;
using Xunit;

namespace LinkedList
{
    public class LinkedListTest
    {
        [Fact]
        public void CountTest()
        {
            var list = new LinkedList<int>();
            Assert.Equal(0, list.Count);
        }
        [Fact]
        public void IsEmptyTest()
        {
            var list = new LinkedList<int>();
            Assert.Equal(true, list.IsEmpty);
        }
        [Fact]
        public void TestAdd()
        {
            var list = new LinkedList<int> { 1, 2, 3 };
            Assert.Equal(3, list.Count);
            list.Add(5);
            Assert.Equal(4, list.Count);
        }
        [Fact]
        public void ClearListTest()
        {
            var list = new LinkedList<int>();
            list.Add(7);
            Assert.Equal(1, list.Count);
            list.Clear();
            Assert.True(list.IsEmpty);

        }
        [Fact]
        public void AddFirstTest()
        {
            var list = new LinkedList<int>() {1,2,3};
            list.AddFirst(11);
            int[] result = new int[] {11,1,2,3};
            Assert.Equal(result, list);
        }
        [Fact]
        public void AddLastTest()
        {
            var list = new LinkedList<int>() { 1, 2, 3 };
            list.AddLast(11);
            int[] result = new int[] {1, 2, 3,11 };
            Assert.Equal(result, list);
        }

        [Fact]
        public void RemoveTest()
        {
            var list = new LinkedList<int>() { 11, 32, 17, 5 };
          /*  list.Remove(0);
            int[] result = new int[] { 32, 17, 5 }; */

           list.Remove(3);
           int[] result = new int[] {11, 32, 17};

            Assert.Equal(result, list);
            Assert.Equal(3, list.Count);
        }


    }
}
