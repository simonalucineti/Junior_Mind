using System;
using Xunit;

namespace List
{
   public class ListTest
    {
    [Fact]
    public void TestCount()
    {
      List obj = new List ();
      obj.Add(31);
      obj.Add(55);
      obj.Add(97);
      Assert.Equal(3, obj.Count);
    }
        [Fact]
        public void TestAdd()
        {
            List obj = new List();
            obj.Add(31);
            obj.Add(17);
            obj.Add(27);
            Assert.Equal(true, obj.Contains(17));
            Assert.False(obj.Contains(71));
        }
        [Fact]
        public void TestClear()
        {
            List obj = new List();
            obj.Add(31);
            obj.Add(55);
            obj.Clear();
            Assert.Equal(-1, obj.Count);
        }
        [Fact]
        public void TestCopyTo()
        {
            int[] test = new int[] { 4, 11, 23, 1, 41 };
            List obj = new List { 6, 8 };
            obj.CopyTo(test, 2);
            Assert.Equal(new int[] { 4, 11, 6, 8, 41 }, test);

        }
        [Fact]
        public void TestIndexOF()
        {
            List obj = new List {6,8,1,0,5,2};
            Assert.Equal(4, obj.IndexOf(5));
        }
        [Fact]
        public void TestInsert()
        {
            List obj = new List {6,8,5};
            obj.Insert(2, 21);
            Assert.True(obj.Contains(21));
        }
        [Fact]
        public void TestRemove()
        {
            List obj = new List { 6, 8, 1, 0, 5, 2, 4, 11, 23};
            obj.Remove(1);
            Assert.Equal(false, obj.Contains(1));
        }
        [Fact]
        public void TestRemoveAt()
        {
            List obj = new List { 6, 8, 1, 41, 5, 2, 4, 11, 23 };
            obj.RemoveAt(3);
            Assert.Equal(false, obj.Contains(41));
            obj.RemoveAt(7);
            Assert.False(obj.Contains(23));
       }
          }
}
