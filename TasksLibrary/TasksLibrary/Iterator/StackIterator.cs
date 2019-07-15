namespace TasksLibrary
{
    public class StackIterator<T> : Iterator<T>
    {
        private MyStack<T> _collection;

        // Хранит текущее положение обхода. У итератора может быть множество
        // других полей для хранения состояния итерации, особенно когда он
        // должен работать с определённым типом коллекции.
        private int _position = -1;

        public StackIterator(MyStack<T> collection)
        {
            this._collection = collection;
            _position = collection.Count;
        }

        public override T Current()
        {
            return this._collection[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position - 1;

            if (updatedPosition >= 0 && updatedPosition < this._collection.Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = _collection.Count - 1;
        }
    }
}
