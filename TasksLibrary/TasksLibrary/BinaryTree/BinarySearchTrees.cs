using System;
using System.Collections;

namespace TasksLibrary
{
    public class BinarySearchTransverseTree<T> : BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTransverseTree(T rootValue) : base(rootValue){}

        public override IEnumerator GetEnumerator()
        {
            return new BinarySearchTreeTransverseIterator<T>(this);
        }
    }

    public class BinarySearchDirectTree<T> : BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchDirectTree(T rootValue) : base(rootValue) { }

        public override IEnumerator GetEnumerator()
        {
            return new BinarySearchTreeDirectIterator<T>(this);
        }
    }

    public class BinarySearchReverseTree<T> : BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchReverseTree(T rootValue) : base(rootValue) { }

        public override IEnumerator GetEnumerator()
        {
            return new BinarySearchTreeReverseIterator<T>(this);
        }
    }
}
