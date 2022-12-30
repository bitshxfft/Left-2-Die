namespace Bitwise.Core.Collections
{
	public interface IStack<T> : IContainer<T>
	{
		void Push(T value);
		T Peek();
		T Pop();
	}
}