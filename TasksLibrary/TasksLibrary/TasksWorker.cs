using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                    rightIndex = centerIndex - 1;
                else if (condition < 0)
                    leftIndex = centerIndex + 1;
                else
                    return centerIndex;
            } while (leftIndex <= rightIndex);

            return -1;
        }

        public Dictionary<string, int> GetWordsFrequencyInFile(string path)
        {
            var text = "";

            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, Encoding.GetEncoding(1251)))
                {
                    text = sr.ReadToEnd();
                }
            }

            var clearText = Regex.Replace(text, "[^A-Za-zА-Яа-я _]", "");
            var words = clearText.Split(' ', '\t', '\n');

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 1);
                }
                else
                {
                    dict[word]++;
                }
            }

            return dict;
        }
    }
}
