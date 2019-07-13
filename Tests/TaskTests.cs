using NUnit.Framework;
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
        [TestCase(10, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8,13,21, 34 })]
        public int[] FibonacciTest(int count)
        {
            var actual = tw.GetFibonacciNumber().Take(count);

            return actual.ToArray();
        }
    }
}
