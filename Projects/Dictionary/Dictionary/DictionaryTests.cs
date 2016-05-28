using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dictionary
{
   public  class DictionaryTests
    {
        [Fact]
        public void AddTest1()
        {
            Dictionary <int, string> input = new Dictionary <int, string>();
            input.Add(1, "aaa");
            input.Add(2, "aab");
            input.Add(3, "aba");
            input.Add(4, "abb");
            input.Add(5, "bba");
            Assert.True(input.ContainsKey(1));
        }
        [Fact]
        public void AddTest2()
        {
            Dictionary<int, string> input = new Dictionary<int, string>();
            input.Add(1, "aaa");
            input.Add(2, "aab");
            input.Add(3, "aba");
            input.Add(4, "abb");
            input.Add(5, "bba");
            input.Add(6, "bbb");
            Assert.True(input.ContainsKey(6));
        }
        [Fact]
        public void ClearTest()
        {
            Dictionary<int, string> input = new Dictionary<int, string>();
            input.Add(1, "aaa");
            input.Add(2, "aab");
            input.Add(3, "aba");
            input.Add(4, "abb");
            input.Add(5, "bba");
            input.Add(6, "bbb");
            input.Clear();
            Assert.Equal(0,input.Count());
        }
        [Fact]
        public void TryGetValueTest()
        {
            Dictionary<int, string> input = new Dictionary<int, string>();
            input.Add(1, "aaa");
            input.Add(2, "aab");
            input.Add(3, "aba");
            input.Add(4, "abb");
            input.Add(5, "bba");
            input.Add(6, "bbb");
            Assert.Equal("abb", input[4]);
        }
        [Fact]
        public void RemoveTest()
        {
            Dictionary<int, string> input = new Dictionary<int, string>();
            input.Add(1, "aaa");
            input.Add(2, "aab");
            input.Add(3, "aba");
            input.Add(4, "abb");
            input.Add(5, "bba");
            input.Add(6, "bbb");
            input.Remove(3);
            Assert.False(input.ContainsKey(3));
        }


    }
}
