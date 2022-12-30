namespace Bitwise.Core.Collections
{
	public interface IVector<T> : IIterable<T>
	{
		public new int Capacity { get; set; }
		public T this[int index] { get; set; }
		public void Add(T value);
		public void AddRange(IIterable<T> values);
		public void Insert(T value, int index);
		public bool Remove(T value);
		public int RemoveAll(T value);
		public T RemoveAt(int index);
		public bool Contains(T value);
	}
}