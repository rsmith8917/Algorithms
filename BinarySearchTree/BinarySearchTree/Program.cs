using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTNode<int> bst = null;

            Random rnd = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int num = rnd.Next(0, 10000);
                if (bst != null)
                {
                    bst.Insert(num);
                }
                else
                {
                    bst = new BSTNode<int>(num);
                }
            }

            Console.WriteLine(bst);
            Console.WriteLine("Diameter: {0}", BSTUtils<int>.Diameter(bst));
            Console.ReadLine();
        }
    }



    public static class BSTUtils<T> where T : IComparable
    {
        public static int Diameter(BSTNode<T> root)
        {
            int diameter = 0;

            if (root == null)
            {
                diameter = 0;
            }
            else if (root.rChild == null && root.lChild == null)
            {
                diameter = 1;
            }
            else
            {
                int lHeight = 0;
                int rHeight = 0;
                try
                {
                    lHeight = root.lChild.Height();
                }
                catch (Exception)
                {
                }

                try
                {
                    rHeight = root.rChild.Height();
                }
                catch (Exception)
                {
                }

                diameter = Math.Max(lHeight + 1 + rHeight, Math.Max(Diameter(root.lChild), Diameter(root.rChild)));
            }

            return diameter;
        } 
    }

    public class BSTNode<T> where T : IComparable
    {
        private BSTNode<T> _parent;
        public BSTNode<T> parent
        {
            get { return _parent; }
        }
        private BSTNode<T> _lChild;
        public BSTNode<T> lChild
        {
            get { return _lChild; }
        }
        private BSTNode<T> _rChild;
        public BSTNode<T> rChild
        {
            get { return _rChild; }
        }
        private T _data;
        public T data
        {
            get { return _data; }
        }
        private Random rnd;

        public BSTNode(T data = default(T))
        {
            this._data = data;
            this.rnd = new Random();
        }

        public bool Insert(T data)
        {
            if (Find(data) == null)
            {
                if (this.data.CompareTo(data) > 0)
                {
                    if (this.lChild == null)
                    {
                        this._lChild = new BSTNode<T>(data);
                        this._lChild._parent = this;
                    }
                    else
                    {
                        return lChild.Insert(data);
                    }
                }
                else
                {
                    if (this.rChild == null)
                    {
                        this._rChild = new BSTNode<T>(data);
                        this._rChild._parent = this;
                    }
                    else
                    {
                        return rChild.Insert(data);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(T data)
        {
            BSTNode<T> node = Find(data);

            if (node != null)
            {
                if (node.lChild == null && node.rChild == null)
                {
                    LeafDelete(node);
                }
                else if (node.lChild == null || node.rChild == null)
                {
                    SingleChildDelete(node);
                }
                else
                {
                    TwoChildDelete(node);

                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public BSTNode<T> Find(T data)
        {
            if (this.data.Equals(data))
            {
                return this;
            }
            else if (this.data.CompareTo(data) > 0)
            {
                if (lChild != null)
                {
                    return lChild.Find(data);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                if (rChild != null)
                {
                    return rChild.Find(data);
                }
                else
                {
                    return null;
                }
            }
        }

        public int Height()
        {
            int currentLevel = 0;

            if (this.lChild == null && this.rChild == null)
            {
                currentLevel = 1;
            }
            else
            {
                Queue<NodeAndLevel> queue = new Queue<NodeAndLevel>();
                queue.Enqueue(new NodeAndLevel() { node = this, level = 0 });
                BSTNode<T> currentNode;
                int lastLevel = 0;
                NodeAndLevel currNodeAndLevel;

                while (queue.Count > 0)
                {
                    currNodeAndLevel = queue.Dequeue();
                    currentNode = currNodeAndLevel.node;
                    currentLevel = currNodeAndLevel.level;
                    if (currentLevel > lastLevel)
                    {
                        lastLevel = currentLevel;
                    }

                    if (currentNode != null)
                    {
                        queue.Enqueue(new NodeAndLevel() { node = currentNode.lChild, level = currentLevel + 1 });
                        queue.Enqueue(new NodeAndLevel() { node = currentNode.rChild, level = currentLevel + 1 });
                    }

                }
            }

            return currentLevel;
        }

        public override string ToString()
        {
            Queue<NodeAndLevel> queue = new Queue<NodeAndLevel>();

            queue.Enqueue(new NodeAndLevel() { node = this, level = 0 });

            BSTNode<T> currentNode;
            int currentLevel = 0;
            int lastLevel = 0;

            StringBuilder output = new StringBuilder();

            NodeAndLevel currNodeAndLevel;


            while (queue.Count > 0)
            {
                currNodeAndLevel = queue.Dequeue();
                currentNode = currNodeAndLevel.node;
                currentLevel = currNodeAndLevel.level;
                if (currentLevel > lastLevel)
                {
                    output.Append("\n");
                    lastLevel = currentLevel;
                }
                output.Append((currentNode != null) ? currentNode.data.ToString() : "x");

                output.Append(" ");

                if (currentNode != null)
                {
                    queue.Enqueue(new NodeAndLevel() { node = currentNode.lChild, level = currentLevel + 1 });
                    queue.Enqueue(new NodeAndLevel() { node = currentNode.rChild, level = currentLevel + 1 });
                }

            }

            return output.ToString();

        }

        private void SingleChildDelete(BSTNode<T> node)
        {
            BSTNode<T> child;

            if (node.lChild == null)
            {
                child = node.rChild;
            }
            else
            {
                child = node.lChild;
            }


            if (node.parent.data.CompareTo(node.data) > 0)
            {
                node.parent._lChild = child;
                child._parent = node.parent;
            }
            else
            {
                node.parent._rChild = child;
                child._parent = node.parent;
            }

            node._rChild = null;
            node._lChild = null;
            node._parent = null;
        }

        private void LeafDelete(BSTNode<T> node)
        {
            if (node.parent.data.CompareTo(node.data) > 0)
                node.parent._lChild = null;
            else
                node.parent._rChild = null;

            node._parent = null;
        }

        private void TwoChildDelete(BSTNode<T> node)
        {
            if (rnd.Next(0, 1000) < 500)
            {
                node._data = node.lChild.rChild.data;
                node.lChild.rChild.Delete(node.data);
            }
            else
            {
                node._data = node.rChild.lChild.data;
                node.rChild.lChild.Delete(node.data);
            }
        }

        public struct NodeAndLevel
        {
            public BSTNode<T> node;
            public int level;
        }
    }
}
