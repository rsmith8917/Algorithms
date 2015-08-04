using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListMthToLastElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 7;

            LinkedList<int> node8 = new LinkedList<int>(8);
            LinkedList<int> node7 = new LinkedList<int>(7);
            LinkedList<int> node6 = new LinkedList<int>(6);
            LinkedList<int> node5 = new LinkedList<int>(5);
            LinkedList<int> node4 = new LinkedList<int>(4);
            LinkedList<int> node3 = new LinkedList<int>(3);
            LinkedList<int> node2 = new LinkedList<int>(2);
            LinkedList<int> node1 = new LinkedList<int>(1);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;

            Console.WriteLine(node1);

            Console.WriteLine("The mth to last element is: {0}", FindMthToLast(node1, m));

            Console.ReadLine();

        }

        static T FindMthToLast<T>(LinkedList<T> linkedList, int m)
        {
            if (m < 0)
            {
                return default(T);
            }
            else
            {
                LinkedList<T> mNode = linkedList;
                LinkedList<T> leadingNode = linkedList;

                int i = 1;

                while (leadingNode.next != null)
                {
                    leadingNode = leadingNode.next;

                    if (i > m)
                    {
                        if (mNode != null)
                        {
                            mNode = mNode.next;
                        }
                        else
                        {
                            return default(T);
                        }
                    }

                    i += 1;
                }

                return mNode.data;
            }

        }
    }

    public class LinkedList<T>
    {
        public T data { get; set; }
        public LinkedList<T> next { get; set; }

        public LinkedList()
        {
            this.data = default(T);
            this.next = null;
        }


        public LinkedList(T data)
        {
            this.data = data;
            this.next = null;
        }

        public override string ToString()
        {
            LinkedList<T> currentList = this;

            string listStr = "";

            while (currentList.next != null)
            {
                listStr += String.Format("{0}->", currentList.data);
                currentList = currentList.next;
            }

            listStr += currentList.data;

            return listStr;
        }

    }
}
