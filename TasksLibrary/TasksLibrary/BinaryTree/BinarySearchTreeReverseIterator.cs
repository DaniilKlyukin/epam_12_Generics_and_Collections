using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksLibrary
{
    public class BinarySearchTreeReverseIterator<T> : TreeIterator<T> where T : IComparable
    {
        BinarySearchTree<T> _collection;

        // Хранит текущее положение обхода. У итератора может быть множество
        // других полей для хранения состояния итерации, особенно когда он
        // должен работать с определённым типом коллекции.
        private int currentIndex;
        private Stack<Node<T>> visited = new Stack<Node<T>>();
        List<Node<T>> data;

        public BinarySearchTreeReverseIterator(BinarySearchTree<T> collection)
        {
            this._collection = collection;

            currentIndex = -1;
            Reset();
        }

        public override Node<T> Current()
        {
            return data[currentIndex];
        }

        public override bool MoveNext()
        {
            if (currentIndex + 1 < data.Count)
            {
                currentIndex++;
                return true;
            }
            else
                return false;
        }

        public override void Reset()
        {
            data = new List<Node<T>>();
            Search(_collection.root);
        }

        private void Search(Node<T> node)
        {
            if (node == null)
                return;

            Search(node.Left);

            Search(node.Right);

            data.Add(node);
        }
    }
}