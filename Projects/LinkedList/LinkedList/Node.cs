using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        private object data;
        private Node next;
        private Node previous;
    
    public Node (object data)
        {
            this.data = data;
        }

     public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
        public Node Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

    }
}
