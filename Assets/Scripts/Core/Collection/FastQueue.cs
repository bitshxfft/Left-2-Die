using System;

namespace Bitwise.Core.Collections
{
	public class FastQueue<T> : IQueue<T>
	{
		private readonly Vector<T> _contents;

		// ----------------------------------------------------------------------------

		public FastQueue(int capacity)
		{
			_contents = new Vector<T>(capacity, VectorPreferences.PreserveOrder);
		}

		// ----------------------------------------------------------------------------
		// IContainer

		public int Count => _contents.Count;

		public int Capacity => _contents.Capacity;

		public void Clear() => _contents.Clear();

		// ----------------------------------------------------------------------------
		// IQueue

		public void Enqueue(T value) => _contents.Add(value);

		public T Peek()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("[FastQueue::Peek] FastQueue is empty, nothing to Peek");
			}
			
			return _contents[_contents.First()];
		}

		public T Dequeue()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("[FastQueue::Dequeue] FastQueue is empty, nothing to Dequeue");
			}
			
			return _contents.RemoveAt(_contents.First().Index);
		}
	}
}