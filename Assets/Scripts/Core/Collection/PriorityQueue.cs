using System;

namespace Bitwise.Core.Collections
{
	public class PriorityQueue<T> : IQueue<T> where T : IComparable<T>
	{
		private Vector<T> _contents;

		// ----------------------------------------------------------------------------

		public PriorityQueue(int capacity)
		{
			_contents = new Vector<T>(capacity, VectorPreferences.PreserveOrder);
		}

		// ----------------------------------------------------------------------------
		// IContainer

		public int Count => _contents.Count;

		public int Capacity => _contents.Capacity;

		public void Clear()
		{
			_contents.Clear();
		}

		// ----------------------------------------------------------------------------
		// IQueue

		public void Enqueue(T value)
		{
			for (int i = 0; i < _contents.Count; ++i)
			{
				if (value.CompareTo(_contents[i]) <= 0)
				{
					_contents.Insert(value, i);
					return;
				}
			}

			_contents.Add(value);
		}

		public T Peek()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("[PriorityQueue::Peek] PriorityQueue is empty, nothing to Peek");
			}

			return _contents[_contents.First()];
		}

		public T Dequeue()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("[PriorityQueue::Dequeue] PriorityQueue is empty, nothing to Dequeue");
			}

			return _contents.RemoveAt(_contents.First().Index);
		}
	}
}