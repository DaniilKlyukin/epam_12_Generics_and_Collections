using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TasksLibrary;
using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [MSTest.TestClass]
    [TestFixture]
    public class TaskTests
    {
        TasksWorker tw = new TasksWorker();

        [TestCase(6, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(1, ExpectedResult = new int[] { 0 })]
        [TestCase(0, ExpectedResult = new int[] { })]
        [TestCase(10, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        public int[] FibonacciTest(int count)
        {
            var actual = tw.GetFibonacciNumber().Take(count);

            return actual.ToArray();
        }

        public void GenericBinarySearchingTest<T>(T[] array, T valueToFind, int expected) where T : IComparable
        {
            Assert.AreEqual(expected, tw.BinarySearch(array, valueToFind));
        }

        [Test]
        public void BinarySearchingTest()
        {
            GenericBinarySearchingTest(new int[] { 0, 1, 1, 2, 3, 5 }, 2, 3);
            GenericBinarySearchingTest(new int[] { -9, 5, 4, 3, 2, 1 }, -9, 0);
            GenericBinarySearchingTest(new double[] { 1.95, 5.23, 4.53789 }, 5.23, 1);
            GenericBinarySearchingTest(new double[] { 0 }, 0, 0);
            GenericBinarySearchingTest(new char[] { 'a', 'b', 'c', 'd' }, 'd', 3);
            GenericBinarySearchingTest(new char[] { 'a', 'b', 'c', 'd' }, 'C', -1);
        }

        [MSTest.TestMethod]
        public void WordsFrequencyInFileTest()
        {
            var debugDir = Directory.GetCurrentDirectory();
            var folders = debugDir.Split('\\');
            var filesDir = string.Join("\\", folders.Take(folders.Length - 2));

            var actual = tw.GetWordsFrequencyInFile($"{filesDir}\\text1.txt");

            var expected = new Dictionary<string, int>()
            {
                {"Это",1},
                {"тестовый",1},
                {"файл",2},
                {"Далее",2},
                {"символы",1},
                {"больше",1},
                {"символов",1},
                {"нет",1},
                {"цифры",1},
                {"Один",1},
                {"два",1},
                {"Конец",1},
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void QueueTest()
        {
            var q = new MyQueue<int>(1, 3, 5);
            CollectionAssert.AreEqual(new int[] { 1, 3, 5 }, q);

            q.Enqueue(7);
            CollectionAssert.AreEqual(new int[] { 1, 3, 5, 7 }, q);

            q.Dequeue();
            CollectionAssert.AreEqual(new int[] { 3, 5, 7 }, q);

            Assert.AreEqual(3, q.Count);

            q.Clear();
            Assert.AreEqual(0, q.Count);
            CollectionAssert.AreEqual(new int[] { }, q);

            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(1);
            }

            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, q);
        }

        [Test]
        public void StackTest()
        {
            var stack = new MyStack<int>(1, 3, 5);
            CollectionAssert.AreEqual(new int[] { 5, 3, 1 }, stack);

            stack.Push(7);
            CollectionAssert.AreEqual(new int[] { 7, 5, 3, 1 }, stack);

            stack.Pop();
            CollectionAssert.AreEqual(new int[] { 5, 3, 1 }, stack);

            Assert.AreEqual(3, stack.Count);

            stack.Clear();
            Assert.AreEqual(0, stack.Count);
            CollectionAssert.AreEqual(new int[] { }, stack);

            for (int i = 0; i < 10; i++)
            {
                stack.Push(1);
            }

            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, stack);
        }

        [Test]
        public void BinaryTreeIntTest()
        {
            var t = new BinarySearchTree<int>(25);

            t.Add(50);
            t.Add(70);
            t.Add(90);
            t.Add(66);
            t.Add(35);
            t.Add(44);
            t.Add(31);
            t.Add(15);
            t.Add(10);
            t.Add(4);
            t.Add(12);
            t.Add(22);
            t.Add(18);
            t.Add(24);

            var reverseTree = new int[] { 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25 };
            CollectionAssert.AreEqual(reverseTree, t.Traverse(TraverseType.Reverse).Select(x => x.Value));

            var directTree = new int[] { 25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90 };
            CollectionAssert.AreEqual(directTree, t.Traverse(TraverseType.Direct).Select(x => x.Value));

            var transverseTree = new int[] { 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90 };
            CollectionAssert.AreEqual(transverseTree, t.Traverse(TraverseType.Transverse).Select(x => x.Value));
        }

        [Test]
        public void BinaryTreeStringTest()
        {
            var t = new BinarySearchTree<string>("G");

            t.Add("D");
            t.Add("A");
            t.Add("E");
            t.Add("K");
            t.Add("J");
            t.Add("M");

            var reverseTree = new string[] { "A", "E", "D", "J", "M", "K", "G" };
            CollectionAssert.AreEqual(reverseTree, t.Traverse(TraverseType.Reverse).Select(x => x.Value));

            var directTree = new string[] { "G", "D", "A", "E", "K", "J", "M" };
            CollectionAssert.AreEqual(directTree, t.Traverse(TraverseType.Direct).Select(x => x.Value));

            var transverseTree = new string[] { "A", "D", "E", "G", "J", "K", "M" };
            CollectionAssert.AreEqual(transverseTree, t.Traverse(TraverseType.Transverse).Select(x => x.Value));
        }

        [Test]
        public void BinaryTreeBookTest()
        {
            var t = new BinarySearchTree<Book>(new Book(2, 25, 3000));//0

            t.Add(new Book(2, 26, 3000));//1
            t.Add(new Book(2, 26, 3150));//2
            t.Add(new Book(2, 25, 3050));//3
            t.Add(new Book(1, 15, 2100));//4
            t.Add(new Book(1, 14, 1900));//5
            t.Add(new Book(1, 16, 2300));//6

            var reverseTree = new Book[]
            {
                new Book(1, 14, 1900),
                new Book(1, 16, 2300),
                new Book(1, 15, 2100),
                new Book(2, 25, 3050),
                new Book(2, 26, 3150),
                new Book(2, 26, 3000),
                new Book(2, 25, 3000)
            };
            CollectionAssert.AreEqual(reverseTree, t.Traverse(TraverseType.Reverse).Select(x => x.Value));

            var directTree = new Book[]
            {
                new Book(2, 25, 3000),
                new Book(1, 15, 2100),
                new Book(1, 14, 1900),
                new Book(1, 16, 2300),
                new Book(2, 26, 3000),
                new Book(2, 25, 3050),
                new Book(2, 26, 3150)
            };
            CollectionAssert.AreEqual(directTree, t.Traverse(TraverseType.Direct).Select(x => x.Value));

            var transverseTree = new Book[]
            {
                new Book(1, 14, 1900),
                new Book(1, 15, 2100),
                new Book(1, 16, 2300),
                new Book(2, 25, 3000),
                new Book(2, 25, 3050),
                new Book(2, 26, 3000),
                new Book(2, 26, 3150)
            };
            CollectionAssert.AreEqual(transverseTree, t.Traverse(TraverseType.Transverse).Select(x => x.Value));
        }

        [Test]
        public void BinaryTreePointTest()
        {
            var t = new BinarySearchTree<Point>(new Point(4, 4));//0

            t.Add(new Point(4, 8));//1
            t.Add(new Point(8, 7));//2
            t.Add(new Point(5, 4));//3
            t.Add(new Point(3, 3));//4
            t.Add(new Point(1, 2));//5
            t.Add(new Point(3, 4));//6

            var reverseTree = new Point[]
            {
                new Point(1, 2),
                new Point(3, 4),
                new Point(3, 3),
                new Point(5, 4),
                new Point(8, 7),
                new Point(4, 8),
                new Point(4, 4)
            };
            CollectionAssert.AreEqual(reverseTree, t.Traverse(TraverseType.Reverse).Select(x => x.Value));

            var directTree = new Point[]
            {
                new Point(4, 4),
                new Point(3, 3),
                new Point(1, 2),
                new Point(3, 4),
                new Point(4, 8),
                new Point(5, 4),
                new Point(8, 7)
            };
            CollectionAssert.AreEqual(directTree, t.Traverse(TraverseType.Direct).Select(x => x.Value));

            var transverseTree = new Point[]
            {
                new Point(1, 2),
                new Point(3, 3),
                new Point(3, 4),
                new Point(4, 4),
                new Point(5, 4),
                new Point(4, 8),
                new Point(8, 7)
            };
            CollectionAssert.AreEqual(transverseTree, t.Traverse(TraverseType.Transverse).Select(x => x.Value));
        }

        Calculator calc = new Calculator();

        [TestCase("7 2 3 * -", ExpectedResult = 1)]
        [TestCase("5 1 2 + 4 * + 3 -", ExpectedResult = 14)]
        [TestCase("1 2 + 4 * 3 +", ExpectedResult = 15)]
        [TestCase("0 10 - 4 / 1 +", ExpectedResult = -1.5)]
        [TestCase("0 10 * 0 +", ExpectedResult = 0)]
        public double CalculatorTest(string input)
        {
            return calc.Calculate(input);
        }
    }

    class Book : IComparable
    {
        public int Titles { get; set; }
        public int Pages { get; set; }
        public int Words { get; set; }

        public Book(int titles, int pages, int words)
        {
            Titles = titles;
            Pages = pages;
            Words = words;
        }

        public int CompareTo(object obj)
        {
            var b = (Book)obj;
            var conditionTitle = Titles.CompareTo(b.Titles);
            if (conditionTitle != 0)
                return conditionTitle;

            var conditionPages = Pages.CompareTo(b.Pages);
            if (conditionPages != 0)
                return conditionPages;

            var conditionWords = Words.CompareTo(b.Words);
            return conditionWords;
        }

        public override bool Equals(object obj)
        {
            var b = (Book)obj;
            return (b.Titles == Titles && b.Pages == Pages && b.Words == Words);
        }
    }

    struct Point : IComparable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Distance()
        {
            return Math.Abs(X * X + Y * Y);
        }

        public int CompareTo(object obj)
        {
            var p = (Point)obj;
            return this.Distance().CompareTo(p.Distance());
        }

        public override bool Equals(object obj)
        {
            var p = (Point)obj;
            return (p.Distance() == this.Distance());
        }
    }
}
