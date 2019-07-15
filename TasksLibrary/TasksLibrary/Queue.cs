using System;
using System.Collections;

namespace TasksLibrary
{
    public class MyQueue<T> : IteratorAggregate
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

            capacity = Math.Max(BaseCapacity,(int)Math.Pow(2, power));
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

        public T Peek()
        {
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return data[0];
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

        public override IEnumerator GetEnumerator()
        {
            return new QueueIterator<T>(this);
        }

        public T this[int index]
        {
            get
            {
                return data[index];
            }
        }
    }
}
