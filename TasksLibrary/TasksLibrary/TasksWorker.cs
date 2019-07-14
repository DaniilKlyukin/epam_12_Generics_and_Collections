using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLibrary
{
    public class TasksWorker
    {
        public IEnumerable<int> GetFibonacciNumber()
        {
            yield return 0;
            yield return 1;

            var prev = 0;
            var current = 1;


            while (true)
            {
                var newNumber = prev + current;
                yield return newNumber;

                prev = current;
                current = newNumber;
            }
        }

        public int BinarySearch<T>(T[] array, T valueToFind) where T : IComparable
        {
            var leftIndex = 0;
            var rightIndex = array.Length - 1;

            do
            {
                var centerIndex = (leftIndex + rightIndex) / 2;
                var condition = array[centerIndex].CompareTo(valueToFind);

                if (condition > 0)
                    rightIndex = centerIndex-1;
                else if (condition < 0)
                    leftIndex = centerIndex+1;
                else
                    return centerIndex;
            } while (leftIndex <= rightIndex);

            return -1;
        }
    }
}
