using System;
using Bitwise.Core.Collections;
using NUnit.Framework;

namespace Bitwise.Tests.Core.Collections
{
	public class PriorityQueueTests
	{
		private IQueue<int> CreateAndFillPriorityQueue()
		{
			int initialCapacity = 4;
			var priorityQueue = new PriorityQueue<int>(initialCapacity);

			// [1, 2, 3, 3, 4, 5, 6, 7, 8, 9, 9, 9, 10]

			priorityQueue.Enqueue(8);
			priorityQueue.Enqueue(3);
			priorityQueue.Enqueue(6);
			priorityQueue.Enqueue(5);
			priorityQueue.Enqueue(4);
			priorityQueue.Enqueue(3);
			priorityQueue.Enqueue(1);
			priorityQueue.Enqueue(9);
			priorityQueue.Enqueue(9);
			priorityQueue.Enqueue(10);
			priorityQueue.Enqueue(9);
			priorityQueue.Enqueue(2);
			priorityQueue.Enqueue(7);

			return priorityQueue;
		}

		[Test]
		public void PriorityQueueCountTest()
		{
			IQueue<int> queue = CreateAndFillPriorityQueue();

			Assert.AreEqual(13, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(12, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(11, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(10, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(9, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(8, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(7, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(6, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(5, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(4, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(3, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(2, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(1, queue.Count);
			_ = queue.Dequeue();
			Assert.AreEqual(0, queue.Count);
		}

		[Test]
		public void PriorityQueueCapacityTest()
		{
			Assert.AreEqual(16, CreateAndFillPriorityQueue().Capacity);
		}

		[Test]
		public void PriorityQueueClearTest()
		{
			IQueue<int> queue = CreateAndFillPriorityQueue();

			queue.Clear();
			Assert.AreEqual(16, queue.Capacity);
			Assert.AreEqual(0, queue.Count);
		}

		[Test]
		public void PriorityQueueEnqueueTest()
		{
			IQueue<int> queue = CreateAndFillPriorityQueue();

			Assert.AreEqual(13, queue.Count);
			Assert.AreEqual(16, queue.Capacity);
		}

		[Test]
		public void PriorityQueuePeekTest()
		{
			IQueue<int> queue = CreateAndFillPriorityQueue();

			Assert.AreEqual(1, queue.Peek());
			Assert.AreEqual(13, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(2, queue.Peek());
			Assert.AreEqual(12, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(3, queue.Peek());
			Assert.AreEqual(11, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(3, queue.Peek());
			Assert.AreEqual(10, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(4, queue.Peek());
			Assert.AreEqual(9, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(5, queue.Peek());
			Assert.AreEqual(8, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(6, queue.Peek());
			Assert.AreEqual(7, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(7, queue.Peek());
			Assert.AreEqual(6, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(8, queue.Peek());
			Assert.AreEqual(5, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(9, queue.Peek());
			Assert.AreEqual(4, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(9, queue.Peek());
			Assert.AreEqual(3, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(9, queue.Peek());
			Assert.AreEqual(2, queue.Count);
			queue.Dequeue();

			Assert.AreEqual(10, queue.Peek());
			Assert.AreEqual(1, queue.Count);
			queue.Dequeue();

			Assert.Throws<InvalidOperationException>(() => _ = queue.Peek());
		}

		[Test]
		public void PriorityQueueDequeueTest()
		{
			IQueue<int> queue = CreateAndFillPriorityQueue();

			Assert.AreEqual(1, queue.Dequeue());
			Assert.AreEqual(12, queue.Count);

			Assert.AreEqual(2, queue.Dequeue());
			Assert.AreEqual(11, queue.Count);

			Assert.AreEqual(3, queue.Dequeue());
			Assert.AreEqual(10, queue.Count);

			Assert.AreEqual(3, queue.Dequeue());
			Assert.AreEqual(9, queue.Count);

			Assert.AreEqual(4, queue.Dequeue());
			Assert.AreEqual(8, queue.Count);

			Assert.AreEqual(5, queue.Dequeue());
			Assert.AreEqual(7, queue.Count);

			Assert.AreEqual(6, queue.Dequeue());
			Assert.AreEqual(6, queue.Count);

			Assert.AreEqual(7, queue.Dequeue());
			Assert.AreEqual(5, queue.Count);

			Assert.AreEqual(8, queue.Dequeue());
			Assert.AreEqual(4, queue.Count);

			Assert.AreEqual(9, queue.Dequeue());
			Assert.AreEqual(3, queue.Count);

			Assert.AreEqual(9, queue.Dequeue());
			Assert.AreEqual(2, queue.Count);

			Assert.AreEqual(9, queue.Dequeue());
			Assert.AreEqual(1, queue.Count);

			Assert.AreEqual(10, queue.Dequeue());
			Assert.AreEqual(0, queue.Count);

			Assert.Throws<InvalidOperationException>(() => _ = queue.Dequeue());
		}
	}
}