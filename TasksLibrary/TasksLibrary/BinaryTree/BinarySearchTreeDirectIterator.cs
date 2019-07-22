using System;
using System.Collections.Generic;

namespace TasksLibrary
{
    public class BinarySearchTreeDirectIterator<T> : TreeIterator<T> where T : IComparable
    {
        BinarySearchTree<T> _collection;

        // Хранит текущее положение обхода. У итератора может быть множество
        // других полей для хранения состояния итерации, особенно когда он
        // должен работать с определённым типом коллекции.
        private Node<T> current;
        private Stack<Node<T>> visited = new Stack<Node<T>>();

        public BinarySearchTreeDirectIterator(BinarySearchTree<T> collection)
        {
            this._collection = collection;

            current = null;
        }

        public override Node<T> Current()
        {
            return current;
        }

        public override bool MoveNext()
        {

            if (current == null)
            {
                Reset();
                visited.Push(current);
                return true;
            }


            if (current.Left != null && !visited.Contains(current.Left))
            {
                current = current.Left;
                visited.Push(current);
                return true;
            }
            if (current.Right != null && !visited.Contains(current.Right))
            {
                current = current.Right;
                visited.Push(current);
                return true;
            }
            else if (current.Parent != null)
            {
                if (!visited.Contains(current.Parent))
                {
                    current = current.Parent;
                    visited.Push(current);
                    return true;
                }
                else
                {
                    while (true)
                    {
                        current = current.Parent;
                        if (!visited.Contains(current))
                            break;
                        if (!visited.Contains(current.Right))
                        {
                            current = current.Right;
                            break;
                        }
                    }
                    if (current == null)
                        return false;
                    else
                    {
                        visited.Push(current);
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            current = _collection.root;
        }
    }
}