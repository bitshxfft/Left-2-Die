using System;
using Bitwise.Core.Collections;
using NUnit.Framework;

namespace Bitwise.Tests.Core.Collections
{
	public class FastStackTests
	{
		[Test]
		public void FastStackCountTest()
		{
			int initialCapacity = 4;
			var fastStack = new FastStack<int>(initialCapacity);

			Assert.AreEqual(0, fastStack.Count);
			fastStack.Push(1);
			Assert.AreEqual(1, fastStack.Count);
			fastStack.Push(2);
			Assert.AreEqual(2, fastStack.Count);
			fastStack.Push(3);
			Assert.AreEqual(3, fastStack.Count);
			fastStack.Push(4);
			Assert.AreEqual(4, fastStack.Count);
			fastStack.Push(5);
			Assert.AreEqual(5, fastStack.Count);
			fastStack.Push(6);
			Assert.AreEqual(6, fastStack.Count);
			fastStack.Push(7);
			Assert.AreEqual(7, fastStack.Count);
			fastStack.Push(8);
			Assert.AreEqual(8, fastStack.Count);
			fastStack.Push(9);
			Assert.AreEqual(9, fastStack.Count);
			fastStack.Push(10);
			Assert.AreEqual(10, fastStack.Count);
			fastStack.Push(11);
			Assert.AreEqual(11, fastStack.Count);

			_ = fastStack.Pop();
			Assert.AreEqual(10, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(9, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(8, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(7, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(6, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(5, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(4, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(3, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(2, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(1, fastStack.Count);
			_ = fastStack.Pop();
			Assert.AreEqual(0, fastStack.Count);
		}

		[Test]
		public void FastStackCapacityTest()
		{
			int initialCapacity = 4;
			var fastStack = new FastStack<int>(initialCapacity);

			fastStack.Push(1);
			Assert.AreEqual(initialCapacity, fastStack.Capacity);
			fastStack.Push(2);
			Assert.AreEqual(initialCapacity, fastStack.Capacity);
			fastStack.Push(3);
			Assert.AreEqual(initialCapacity, fastStack.Capacity);
			fastStack.Push(4);
			Assert.AreEqual(initialCapacity, fastStack.Capacity);
			fastStack.Push(5);
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
			fastStack.Push(6);
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);

			_ = fastStack.Pop();
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
			_ = fastStack.Pop();
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
			_ = fastStack.Pop();
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
			_ = fastStack.Pop();
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
			_ = fastStack.Pop();
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
			_ = fastStack.Pop();
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
		}

		[Test]
		public void FastStackClearTest()
		{
			int initialCapacity = 4;
			var fastStack = new FastStack<int>(initialCapacity);

			fastStack.Push(1);
			fastStack.Push(2);
			fastStack.Push(3);
			fastStack.Push(4);
			fastStack.Push(5);
			fastStack.Push(6);
			fastStack.Clear();

			Assert.AreEqual(0, fastStack.Count);
			Assert.AreEqual(initialCapacity + 4, fastStack.Capacity);
		}

		[Test]
		public void FastStackPushTest()
		{
			int initialCapacity = 4;
			var fastStack = new FastStack<int>(initialCapacity);

			fastStack.Push(1);
			fastStack.Push(2);
			fastStack.Push(3);
			fastStack.Push(4);
			fastStack.Push(5);
			fastStack.Push(6);
			fastStack.Push(7);
			fastStack.Push(8);
			fastStack.Push(9);

			Assert.AreEqual(9, fastStack.Count);
			Assert.AreEqual(initialCapacity + 8, fastStack.Capacity);
		}

		[Test]
		public void FastStackPeekTest()
		{
			int initialCapacity = 4;
			var fastStack = new FastStack<int>(initialCapacity);

			fastStack.Push(1);
			fastStack.Push(2);
			fastStack.Push(3);
			fastStack.Push(4);
			fastStack.Push(5);
			fastStack.Push(6);
			fastStack.Push(7);
			fastStack.Push(8);
			fastStack.Push(9);

			Assert.AreEqual(9, fastStack.Peek());
			Assert.AreEqual(9, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(8, fastStack.Peek());
			Assert.AreEqual(8, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(7, fastStack.Peek());
			Assert.AreEqual(7, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(6, fastStack.Peek());
			Assert.AreEqual(6, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(5, fastStack.Peek());
			Assert.AreEqual(5, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(4, fastStack.Peek());
			Assert.AreEqual(4, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(3, fastStack.Peek());
			Assert.AreEqual(3, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(2, fastStack.Peek());
			Assert.AreEqual(2, fastStack.Count);
			fastStack.Pop();

			Assert.AreEqual(1, fastStack.Peek());
			Assert.AreEqual(1, fastStack.Count);
			fastStack.Pop();

			Assert.Throws<InvalidOperationException>(() => _ = fastStack.Peek());
		}

		[Test]
		public void FastStackPopTest()
		{
			int initialCapacity = 4;
			var fastStack = new FastStack<int>(initialCapacity);

			fastStack.Push(1);
			fastStack.Push(2);
			fastStack.Push(3);
			fastStack.Push(4);
			fastStack.Push(5);
			fastStack.Push(6);
			fastStack.Push(7);
			fastStack.Push(8);
			fastStack.Push(9);

			Assert.AreEqual(9, fastStack.Pop());
			Assert.AreEqual(8, fastStack.Count);

			Assert.AreEqual(8, fastStack.Pop());
			Assert.AreEqual(7, fastStack.Count);

			Assert.AreEqual(7, fastStack.Pop());
			Assert.AreEqual(6, fastStack.Count);

			Assert.AreEqual(6, fastStack.Pop());
			Assert.AreEqual(5, fastStack.Count);

			Assert.AreEqual(5, fastStack.Pop());
			Assert.AreEqual(4, fastStack.Count);

			Assert.AreEqual(4, fastStack.Pop());
			Assert.AreEqual(3, fastStack.Count);

			Assert.AreEqual(3, fastStack.Pop());
			Assert.AreEqual(2, fastStack.Count);

			Assert.AreEqual(2, fastStack.Pop());
			Assert.AreEqual(1, fastStack.Count);

			Assert.AreEqual(1, fastStack.Pop());
			Assert.AreEqual(0, fastStack.Count);

			Assert.Throws<InvalidOperationException>(() => _ = fastStack.Pop());
		}
	}
}