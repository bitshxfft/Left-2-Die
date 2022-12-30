using System;

namespace Bitwise.Core.Collections
{
	public class FastStack<T> : IStack<T>
	{
		private readonly Vector<T> _contents;

		// ----------------------------------------------------------------------------

		public FastStack(int capacity)
		{
			_contents = new Vector<T>(capacity, VectorPreferences.PreserveOrder);
		}

		// ----------------------------------------------------------------------------
		// IContainer

		public int Count => _contents.Count;

		public int Capacity => _contents.Capacity;

		public void Clear() => _contents.Clear();

		// ----------------------------------------------------------------------------
		// IStack

		public void Push(T value) => _contents.Add(value);

		public T Peek()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("[FastStack::Peek] FastStack is empty, nothing to Peek");
			}

			return _contents[_contents.Last()];
		}

		public T Pop()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("[FastStack::Pop] FastStack is empty, nothing to Pop");
			}

			return _contents.RemoveAt(_contents.Last().Index);
		}
	}
}