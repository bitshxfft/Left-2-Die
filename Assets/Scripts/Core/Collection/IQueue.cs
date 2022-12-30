namespace Bitwise.Core.Collections
{
	public interface IQueue<T> : IContainer<T>
	{
		void Enqueue(T value);
		T Peek();
		T Dequeue();
	}
}