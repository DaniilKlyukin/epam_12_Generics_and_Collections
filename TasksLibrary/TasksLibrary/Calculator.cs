using System;
using System.Collections.Generic;

namespace TasksLibrary
{
    public class Calculator
    {
        static Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>
        {
            { "+", (y, x) => x + y },
            { "-", (y, x) => x - y },
            { "*", (y, x) => x * y },
            { "/", (y, x) => x / y },
        };

        public double Calculate(string expression)
        {
            var dataArray = expression.Split(' ');

            var stack = new Stack<double>();
            foreach (var e in dataArray)
            {
                var num = 0;
                var isParsed = int.TryParse(e, out num);

                if (isParsed)
                    stack.Push(num);
                else if (operations.ContainsKey(e))
                    stack.Push(operations[e](stack.Pop(), stack.Pop()));
                else
                    throw new ArgumentException();
            }

            return stack.Pop();
        }
    }
}
