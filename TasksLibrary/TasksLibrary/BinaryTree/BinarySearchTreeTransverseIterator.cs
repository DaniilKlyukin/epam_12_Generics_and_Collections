using System;
using System.Collections.Generic;

namespace TasksLibrary
{
    public class BinarySearchTreeTransverseIterator<T> : TreeIterator<T> where T : IComparable
    {
        BinarySearchTree<T> _collection;

        // Хранит текущее положение обхода. У итератора может быть множество
        // других полей для хранения состояния итерации, особенно когда он
        // должен работать с определённым типом коллекции.
        private Node<T> current;
        private Stack<Node<T>> visited = new Stack<Node<T>>();

        public BinarySearchTreeTransverseIterator(BinarySearchTree<T> collection)
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

            if (Traverse())
            {
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
                    while(true)
                    {
                        current = current.Parent;
                        if (!visited.Contains(current))
                            break;
                        else if (Traverse())
                        {
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

        private bool Traverse()
        {
            var moved = false;
            while (true)
            {
                if (current.Left != null && !visited.Contains(current.Left))
                {
                    current = current.Left;
                    moved = true;
                }
                else if (current.Right != null && !visited.Contains(current.Right))
                {
                    current = current.Right;
                    moved = true;
                }
                else
                    return moved;
            }
        }

        public override void Reset()
        {
            visited = new Stack<Node<T>>();
            current = _collection.root;
            while (true)
            {
                if (current.Left != null)
                    current = current.Left;
                else
                    break;
            }
        }
    }
}