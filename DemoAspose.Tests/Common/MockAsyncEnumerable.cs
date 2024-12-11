//namespace DemoAspose.Tests.Common
//{
//    public class MockAsyncEnumerable<T> : IAsyncEnumerable<T>
//    {
//        private readonly T[] _items;

//        public MockAsyncEnumerable(T[] items)
//        {
//            _items = items;
//        }

//        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
//        {
//            return new MockAsyncEnumerator<T>(_items);
//        }
//    }

//    public class MockAsyncEnumerator<T> : IAsyncEnumerator<T>
//    {
//        private readonly T[] _items;
//        private int _index = -1;

//        public MockAsyncEnumerator(T[] items)
//        {
//            _items = items;
//        }

//        public ValueTask<bool> MoveNextAsync()
//        {
//            _index++;
//            return new ValueTask<bool>(_index < _items.Length);
//        }

//        public T Current => _items[_index];

//        public ValueTask DisposeAsync()
//        {
//            return new ValueTask();
//        }
//    }
//}
