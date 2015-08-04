using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LLNode node5 = new LLNode(6, null);
            LLNode node4 = new LLNode(5, node5);
            LLNode node3 = new LLNode(3, node4);
            LLNode node2 = new LLNode(2, node3);
            LLNode node1 = new LLNode(1, node2);

            node1.Insert(4, 0);
            node1.Delete(2);

            Console.WriteLine("LL: {0}", node1);

            LLNode revNode = Reverse(node1);

            Console.WriteLine("Reversed LL: {0}", revNode);

            Console.ReadLine();

        }

        public static LLNode Reverse(LLNode node)
        {
            LLNode previous = null;
            LLNode next = node;

            while (next != null)
            {
                next = node.next;
                node.next = previous;

                previous = node;
                node = next;
                
            }

            return previous;
        }


    }

    public class LLNode
    {
        public LLNode next { get; set; }
        public int data { get; }
        public LLNode first { get; }

        public LLNode(int data, LLNode next)
        {
            this.data = data;
            this.next = next;
        }

        public override string ToString()
        {
            return this.AppendString("", this).Substring(3);
        }

        public void Delete(int index)
        {
            LLNode before = this;

            for (int i = 0; i < index - 1; i++)
            {
                try
                {
                    before = before.next;
                }
                catch (Exception)
                {
                }

            }

            if (before != null)
            {
                if (before.next != null)
                {
                    before.next = before.next.next;
                }
            }
        }

        public void Insert(int value, int index)
        {
            LLNode before = this;

            for (int i = 0; i < index-1; i++)
            {
                try
                {
                    before = before.next;
                }
                catch (Exception)
                {
                }
                
            }

            try
            {
                LLNode after = before.next;
                before.next = new LLNode(value, after);
            }
            catch (Exception)
            {
            }

        }

        #region Private Methods
        private string AppendString(string str, LLNode node)
        {
            if (node.next == null)
            {
                return str + String.Format("-> {0}", node.data.ToString());
            }
            else
            {
                str += String.Format("-> {0}", node.data.ToString());
                return AppendString(str, node.next);
            }
        }
        #endregion

    }
}
