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
    }
}
