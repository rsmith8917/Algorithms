using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLStack
{
    class Program
    {
        static void Main(string[] args)
        {

            LLStack<int> stack = new LLStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            stack.Push(5);
            stack.Push(7);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.ReadLine();
        }
    }

    public class LLStack<T>
    {
        private LinkedList<T> linkedList;

        public void Push(T data)
        {
            LinkedList<T> newHead = new LinkedList<T>(data);
            newHead.next = linkedList;
            linkedList = newHead;
        }

        public T Pop()
        {
            try
            {
                T data = linkedList.data;
                linkedList = linkedList.next;
                return data;
            }
            catch (Exception)
            {
                return default(T);
            }

        }

        public override string ToString()
        {
            if (linkedList != null)
            {
                return linkedList.ToString();
            }
            else
            {
                return "empty stack";
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
