using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Bitwise.Core.Collections
{
	[Serializable]
	public class Vector<T> : IVector<T>
	{
		[SerializeField, ReadOnly] private List<T> _contents;
		[SerializeField, ReadOnly] private int _firstIndex;
		[SerializeField, ReadOnly] private VectorPreferences _preferences;

		// ----------------------------------------------------------------------------

		public Vector(int initialCapacity = 4, VectorPreferences preferences = VectorPreferences.None)
		{
			_contents = new List<T>(4);
			_preferences = preferences;

			Resize(initialCapacity);
		}

		// ----------------------------------------------------------------------------

		private int LastIndex =>
			Capacity > 0
				? (_firstIndex + (Count - 1)) % Capacity
				: 0;

		private void IncrementFirstIndex()
		{
			_firstIndex = (_firstIndex + 1) % Capacity;
		}

		private void DecrementFirstIndex()
		{
			if (--_firstIndex < 0)
			{
				_firstIndex += Capacity;
			}
		}

		private int ConvertIndex(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException($"[Vector::ConvertIndex] invalid index: {index}. Count: {Count}, Capacity: {Capacity}");
			}

			return (_firstIndex + index) % Capacity;
		}

		private void Resize(int newCapacity)
		{
			if (newCapacity == Capacity)
			{
				return;
			}

			if (newCapacity < Count)
			{
				throw new ArgumentOutOfRangeException($"[Vector::Resize] new capacity {newCapacity} is less than Count: {Count}");
			}

			int previousCapacity = Capacity;
			int previousLastIndex = LastIndex;

			if (newCapacity < previousCapacity)
			{
				for (int i = newCapacity; i < Count; ++i)
				{
					_contents[i % newCapacity] = _contents[i];
				}

				_firstIndex %= newCapacity;

				_contents.RemoveRange(newCapacity, previousCapacity - newCapacity);
				_contents.Capacity = newCapacity;
			}
			else
			{
				_contents.Capacity = newCapacity;
				for (int i = previousCapacity; i < newCapacity; ++i)
				{
					_contents.Add(default);
				}

				// shift wrapped elements into new space
				if (Count > 0 && _firstIndex > previousLastIndex)
				{
					for (int i = 0; i <= previousLastIndex; ++i)
					{
						_contents[previousCapacity + i] = _contents[i];
						_contents[i] = default;
					}
				}
			}
		}

		// ----------------------------------------------------------------------------
		// IContainer

		public int Count { get; private set; }

		public int Capacity
		{
			get => _contents.Count;
			set => Resize(value);
		}

		public void Clear()
		{
			_firstIndex = 0;
			Count = 0;
		}

		// ----------------------------------------------------------------------------
		// IIterable

		public T this[Iterator iterator]
		{
			get => this[iterator.Index];
			set => this[iterator.Index] = value;
		}

		public Iterator First()
		{
			return new Iterator(0);
		}

		public Iterator Previous(Iterator iterator)
		{
			return --iterator;
		}

		public Iterator Next(Iterator iterator)
		{
			return ++iterator;
		}

		public Iterator Last()
		{
			return new Iterator(Count - 1);
		}

		// ----------------------------------------------------------------------------
		// IVector

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					throw new IndexOutOfRangeException($"[Vector::[]::get] invalid index: {index}. Count: {Count}, Capacity: {Capacity}");
				}

				return _contents[ConvertIndex(index)];
			}
			set
			{
				if (index < 0 || index >= Count)
				{
					throw new IndexOutOfRangeException($"[Vector::[]::set] invalid index: {index}. Count: {Count}, Capacity: {Capacity}");
				}

				_contents[ConvertIndex(index)] = value;
			}
		}

		public void Add(T value)
		{
			if (Count == Capacity)
			{
				Resize(Count + 4);
			}

			++Count;
			_contents[LastIndex] = value;
		}

		public void AddRange(IIterable<T> values)
		{
			int addCount = values.Count;
			if (Capacity < Count + addCount)
			{
				Capacity = Count + addCount;
			}

			for (Iterator i = values.First(); i <= values.Last(); ++i)
			{
				Add(values[i]);
			}
		}

		public void Insert(T value, int index)
		{
			if (Count == Capacity)
			{
				Resize(Count + 4);
			}

			if (index > Count)
			{
				throw new IndexOutOfRangeException($"[Vector::Insert] invalid index: {index}. Count: {Count}, Capacity: {Capacity}");
			}
			else if (index == Count)
			{
				Add(value);
			}
			else if ((_preferences & VectorPreferences.PreserveOrder) == VectorPreferences.PreserveOrder)
			{
				if (index == First().Index)
				{
					DecrementFirstIndex();
					_contents[_firstIndex] = value;
				}
				else
				{
					for (int i = Count; i > index; --i)
					{
						_contents[ConvertIndex(i)] = _contents[ConvertIndex(i - 1)];
					}

					_contents[ConvertIndex(index)] = value;
				}

				++Count;
			}
			else
			{
				int convertedIndex = ConvertIndex(index);
				++Count;
				_contents[LastIndex] = _contents[convertedIndex];
				_contents[convertedIndex] = value;
			}
		}

		public bool Remove(T value)
		{
			for (int i = 0, ic = Count; i < ic; ++i)
			{
				if (_contents[ConvertIndex(i)].Equals(value))
				{
					RemoveAt(i);
					return true;
				}
			}

			return false;
		}

		public int RemoveAll(T value)
		{
			int countRemoved = 0;
			for (Iterator i = Last(); i >= First(); --i)
			{
				if (_contents[ConvertIndex(i.Index)].Equals(value))
				{
					RemoveAt(i.Index);
					++countRemoved;
				}
			}

			return countRemoved;
		}

		public T RemoveAt(int index)
		{
			int convertedIndex = ConvertIndex(index);
			T removed = _contents[convertedIndex];

			if (Count <= index)
			{
				throw new IndexOutOfRangeException($"[Vector::RemoveAt] removing index {index} from a Vector with Count: {Count}");
			}
			else if ((_preferences & VectorPreferences.PreserveOrder) == VectorPreferences.PreserveOrder)
			{
				if (index == First().Index)
				{
					IncrementFirstIndex();
				}
				else if (index == Last().Index)
				{
					// nothing to do here
				}
				else
				{
					for (int i = convertedIndex; i != LastIndex; i = (i + 1) % Capacity)
					{
						_contents[i] = _contents[(i + 1) % Capacity];
					}
				}
			}
			else
			{
				// shift what was previously the last element in the vector to the index that's being removed
				_contents[convertedIndex] = _contents[LastIndex];
			}

			--Count;
			return removed;
		}

		public bool Contains(T value)
		{
			for (int i = 0, ic = Count; i < ic; ++i)
			{
				if (_contents[ConvertIndex(i)].Equals(value))
				{
					return true;
				}
			}

			return false;
		}
	}
}