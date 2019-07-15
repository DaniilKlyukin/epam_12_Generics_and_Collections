using System;
using System.Collections;
using System.Collections.Generic;

namespace TasksLibrary
{
    public class MyQueue<T> : IEnumerable<T>
    {
        const int BaseCapacity = 8;

        T[] data = new T[BaseCapacity];

        int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        int capacity = BaseCapacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public MyQueue(params T[] values)
        {
            var power = (int)Math.Log(values.Length, 2) + 1;

            capacity = (int)Math.Pow(2, power);
            count = values.Length;
            data = new T[capacity];

            for (int i = 0; i < count; i++)
            {
                data[i] = values[i];
            }
        }

        public void Enqueue(T item)
        {
            count++;

            if (count > capacity)
            {
                capacity *= 2;
                var temp = new T[capacity];

                for (int i = 0; i < count - 1; i++)
                {
                    temp[i] = data[i];
                }

                data = temp;
            }

            data[count - 1] = item;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            count--;
            var result = data[0];

            for (int i = 0; i < count; i++)
            {
                data[i] = data[i + 1];
            }

            return result;
        }

        public void Clear()
        {
            count = 0;
            capacity = BaseCapacity;

            data = new T[BaseCapacity];
        }

        public bool Contains(T item)
        {
            foreach (var value in data)
            {
                if (value.Equals(item))
                    return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = data.GetEnumerator();

            var index = 0;
            while (enumerator.MoveNext() && index < count)
            {
                yield return (T)enumerator.Current;
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
