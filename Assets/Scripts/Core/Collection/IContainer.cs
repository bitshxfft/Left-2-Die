namespace Bitwise.Core.Collections
{
	public interface IContainer<T>
	{
		public int Count { get; }
		public int Capacity { get; }
		public void Clear();
	}
}