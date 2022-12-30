using System;
using Bitwise.Core.Collections;
using NUnit.Framework;

namespace Bitwise.Tests.Core.Collections
{
	public class FastQueueTests
	{
		[Test]
		public void FastQueueCountTest()
		{
			int initialCapacity = 4;
			var fastQueue = new FastQueue<int>(initialCapacity);

			Assert.AreEqual(0, fastQueue.Count);
			fastQueue.Enqueue(1);
			Assert.AreEqual(1, fastQueue.Count);
			fastQueue.Enqueue(2);
			Assert.AreEqual(2, fastQueue.Count);
			fastQueue.Enqueue(3);
			Assert.AreEqual(3, fastQueue.Count);
			fastQueue.Enqueue(4);
			Assert.AreEqual(4, fastQueue.Count);
			fastQueue.Enqueue(5);
			Assert.AreEqual(5, fastQueue.Count);
			fastQueue.Enqueue(6);
			Assert.AreEqual(6, fastQueue.Count);
			fastQueue.Enqueue(7);
			Assert.AreEqual(7, fastQueue.Count);
			fastQueue.Enqueue(8);
			Assert.AreEqual(8, fastQueue.Count);
			fastQueue.Enqueue(9);
			Assert.AreEqual(9, fastQueue.Count);
			fastQueue.Enqueue(10);
			Assert.AreEqual(10, fastQueue.Count);
			fastQueue.Enqueue(11);
			Assert.AreEqual(11, fastQueue.Count);

			_ = fastQueue.Dequeue();
			Assert.AreEqual(10, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(9, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(8, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(7, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(6, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(5, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(4, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(3, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(2, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(1, fastQueue.Count);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(0, fastQueue.Count);
		}

		[Test]
		public void FastQueueCapacityTest()
		{
			int initialCapacity = 4;
			var fastQueue = new FastQueue<int>(initialCapacity);

			fastQueue.Enqueue(1);
			Assert.AreEqual(initialCapacity, fastQueue.Capacity);
			fastQueue.Enqueue(2);
			Assert.AreEqual(initialCapacity, fastQueue.Capacity);
			fastQueue.Enqueue(3);
			Assert.AreEqual(initialCapacity, fastQueue.Capacity);
			fastQueue.Enqueue(4);
			Assert.AreEqual(initialCapacity, fastQueue.Capacity);
			fastQueue.Enqueue(5);
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
			fastQueue.Enqueue(6);
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);

			_ = fastQueue.Dequeue();
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
			_ = fastQueue.Dequeue();
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
		}

		[Test]
		public void FastQueueClearTest()
		{
			int initialCapacity = 4;
			var fastQueue = new FastQueue<int>(initialCapacity);

			fastQueue.Enqueue(1);
			fastQueue.Enqueue(2);
			fastQueue.Enqueue(3);
			fastQueue.Enqueue(4);
			fastQueue.Enqueue(5);
			fastQueue.Enqueue(6);
			fastQueue.Clear();

			Assert.AreEqual(0, fastQueue.Count);
			Assert.AreEqual(initialCapacity + 4, fastQueue.Capacity);
		}

		[Test]
		public void FastQueueEnqueueTest()
		{
			int initialCapacity = 4;
			var fastQueue = new FastQueue<int>(initialCapacity);

			fastQueue.Enqueue(1);
			fastQueue.Enqueue(2);
			fastQueue.Enqueue(3);
			fastQueue.Enqueue(4);
			fastQueue.Enqueue(5);
			fastQueue.Enqueue(6);
			fastQueue.Enqueue(7);
			fastQueue.Enqueue(8);
			fastQueue.Enqueue(9);

			Assert.AreEqual(9, fastQueue.Count);
			Assert.AreEqual(initialCapacity + 8, fastQueue.Capacity);
		}

		[Test]
		public void FastQueuePeekTest()
		{
			int initialCapacity = 4;
			var fastQueue = new FastQueue<int>(initialCapacity);

			fastQueue.Enqueue(1);
			fastQueue.Enqueue(2);
			fastQueue.Enqueue(3);
			fastQueue.Enqueue(4);
			fastQueue.Enqueue(5);
			fastQueue.Enqueue(6);
			fastQueue.Enqueue(7);
			fastQueue.Enqueue(8);
			fastQueue.Enqueue(9);

			Assert.AreEqual(1, fastQueue.Peek());
			Assert.AreEqual(9, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(2, fastQueue.Peek());
			Assert.AreEqual(8, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(3, fastQueue.Peek());
			Assert.AreEqual(7, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(4, fastQueue.Peek());
			Assert.AreEqual(6, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(5, fastQueue.Peek());
			Assert.AreEqual(5, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(6, fastQueue.Peek());
			Assert.AreEqual(4, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(7, fastQueue.Peek());
			Assert.AreEqual(3, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(8, fastQueue.Peek());
			Assert.AreEqual(2, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.AreEqual(9, fastQueue.Peek());
			Assert.AreEqual(1, fastQueue.Count);
			fastQueue.Dequeue();

			Assert.Throws<InvalidOperationException>(() => _ = fastQueue.Peek());
		}

		[Test]
		public void FastQueueDequeueTest()
		{
			int initialCapacity = 4;
			var fastQueue = new FastQueue<int>(initialCapacity);

			fastQueue.Enqueue(1);
			fastQueue.Enqueue(2);
			fastQueue.Enqueue(3);
			fastQueue.Enqueue(4);
			fastQueue.Enqueue(5);
			fastQueue.Enqueue(6);
			fastQueue.Enqueue(7);
			fastQueue.Enqueue(8);
			fastQueue.Enqueue(9);

			Assert.AreEqual(1, fastQueue.Dequeue());
			Assert.AreEqual(8, fastQueue.Count);

			Assert.AreEqual(2, fastQueue.Dequeue());
			Assert.AreEqual(7, fastQueue.Count);

			Assert.AreEqual(3, fastQueue.Dequeue());
			Assert.AreEqual(6, fastQueue.Count);

			Assert.AreEqual(4, fastQueue.Dequeue());
			Assert.AreEqual(5, fastQueue.Count);

			Assert.AreEqual(5, fastQueue.Dequeue());
			Assert.AreEqual(4, fastQueue.Count);

			Assert.AreEqual(6, fastQueue.Dequeue());
			Assert.AreEqual(3, fastQueue.Count);

			Assert.AreEqual(7, fastQueue.Dequeue());
			Assert.AreEqual(2, fastQueue.Count);

			Assert.AreEqual(8, fastQueue.Dequeue());
			Assert.AreEqual(1, fastQueue.Count);

			Assert.AreEqual(9, fastQueue.Dequeue());
			Assert.AreEqual(0, fastQueue.Count);

			Assert.Throws<InvalidOperationException>(() => _ = fastQueue.Dequeue());
		}
	}
}