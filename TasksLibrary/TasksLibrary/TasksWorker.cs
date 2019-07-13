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
    }
}
