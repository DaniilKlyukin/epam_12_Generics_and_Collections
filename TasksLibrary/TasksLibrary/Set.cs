using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace TasksLibrary
{
    public class Set<T> : IteratorAggregate
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

        public Set(params T[] values)
        {
            var uniqValues = new List<T>();

            foreach (var e in values)
            {
                if (!uniqValues.Contains(e))
                    uniqValues.Add(e);
            }

            var power = (int)Math.Log(uniqValues.Count, 2) + 1;

            capacity = Math.Max(BaseCapacity, (int)Math.Pow(2, power));
            count = uniqValues.Count;
            data = new T[capacity];

            for (int i = 0; i < count; i++)
            {
                data[i] = uniqValues[i];
            }
        }

        public void Add(T item)
        {
            if (data.Contains(item))
                return;

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

        public void Remove(int index)
        {
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            count--;

            var newData = new T[count];

            for (int i = 0, j = 0; i < count + 1; i++)
            {
                if (i != index)
                {
                    newData[j] = data[i];
                    j++;
                }
            }
            data = newData;
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
            return new SetIterator<T>(this);
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
