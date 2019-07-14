using NUnit.Framework;
using System;
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
    }
}
