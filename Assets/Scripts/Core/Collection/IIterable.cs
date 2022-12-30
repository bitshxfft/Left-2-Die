namespace Bitwise.Core.Collections
{
	public interface IIterable<T> : IContainer<T>
	{
		public T this[Iterator iterator] { get; set; }
		Iterator First();
		Iterator Previous(Iterator iterator);
		Iterator Next(Iterator iterator);
		Iterator Last();
	}
}