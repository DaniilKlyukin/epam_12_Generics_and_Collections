using System;
using System.Collections;
using System.Collections.Generic;

namespace TasksLibrary
{
    public enum TraverseType
    {
        Direct,
        Transverse,
        Reverse
    }

    public class BinarySearchTree<T> where T : IComparable
    {
        public Node<T> root { get; private set; }

        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BinarySearchTree(T rootValue)
        {
            root = new Node<T>(rootValue);
        }

        public void Add(T value)
        {
            Node<T> child = new Node<T>(value);
            Node<T> current = root;
            while (true)
            {
                var condition = current.Value.CompareTo(value);

                if (condition > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = child;
                        child.Parent = current;
                        return;
                    }
                    else
                    {
                        current = current.Left;
                        continue;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = child;
                        child.Parent = current;
                        return;
                    }
                    else
                    {
                        current = current.Right;
                        continue;
                    }
                }
            }
        }

        private IEnumerator TraverseEnumerator(TraverseType type = TraverseType.Direct)
        {
            switch (type)
            {
                case TraverseType.Direct: return new BinarySearchTreeDirectIterator<T>(this);
                case TraverseType.Transverse: return new BinarySearchTreeTransverseIterator<T>(this);
                case TraverseType.Reverse: return new BinarySearchTreeReverseIterator<T>(this);
                default: return new BinarySearchTreeDirectIterator<T>(this);
            }
        }

        public IEnumerable<Node<T>> Traverse(TraverseType type = TraverseType.Direct)
        {
            var enumerator = TraverseEnumerator(type);

            while (enumerator.MoveNext())
            {
                yield return (Node<T>)enumerator.Current;
            }
        }
    }

    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
