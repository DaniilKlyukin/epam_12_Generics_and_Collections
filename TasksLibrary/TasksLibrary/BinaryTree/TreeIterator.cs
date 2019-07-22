using System.Collections;

namespace TasksLibrary
{
    public abstract class TreeIterator<T> : IEnumerator
    {
        object IEnumerator.Current => Current();

        // Возвращает текущий элемент.
        public abstract Node<T> Current();

        // Переходит к следующему элементу.
        public abstract bool MoveNext();

        // Перематывает Итератор к первому элементу.
        public abstract void Reset();

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
