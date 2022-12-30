using System;
using Bitwise.Core.Collections;
using NUnit.Framework;
using Random = System.Random;

namespace Bitwise.Tests.Core.Collections
{
	public class VectorTests
	{
		[Test]
		public void VectorCountTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			Assert.AreEqual(0, vector.Count);

			vector.Add(1);
			Assert.AreEqual(1, vector.Count);

			vector.Add(2);
			Assert.AreEqual(2, vector.Count);

			vector.Add(3);
			Assert.AreEqual(3, vector.Count);

			vector.Add(4);
			Assert.AreEqual(4, vector.Count);

			vector.Add(5);
			Assert.AreEqual(5, vector.Count);

			vector.Add(6);
			Assert.AreEqual(6, vector.Count);
		}

		[Test]
		public void VectorCapacityTest()
		{
			int initialCapacity = 4;
			int growCapacity = 6;
			int shrinkCapacity = 2;

			var vector = new Vector<int>(initialCapacity);
			Assert.AreEqual(initialCapacity, vector.Capacity);

			vector.Capacity = growCapacity;
			Assert.AreEqual(growCapacity, vector.Capacity);

			vector.Capacity = shrinkCapacity;
			Assert.AreEqual(shrinkCapacity, vector.Capacity);
		}

		[Test]
		public void VectorSetCapacityTest()
		{
			int initialCapacity = 3;
			int growCapacity = 9;

			var vector = new Vector<int>(initialCapacity);
			Assert.AreEqual(initialCapacity, vector.Capacity);

			vector.Capacity = growCapacity;
			Assert.AreEqual(growCapacity, vector.Capacity);
		}

		[Test]
		public void VectorSetInvalidCapacityThrowsTest()
		{
			int initialCapacity = 4;
			int shrinkCapacity = 3;

			var vector = new Vector<int>(initialCapacity);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);

			Assert.Throws<ArgumentOutOfRangeException>(() => vector.Capacity = shrinkCapacity);
			Assert.AreEqual(initialCapacity, vector.Capacity);
		}

		[Test]
		public void VectorClearTest()
		{
			int initialCapacity = 4;

			var vector = new Vector<int>(initialCapacity);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Clear();

			Assert.AreEqual(initialCapacity + 4, vector.Capacity);
			Assert.AreEqual(0, vector.Count);
		}

		[Test]
		public void VectorIteratorTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);

			Iterator iterator = vector.First();
			Assert.AreEqual(0, iterator.Index);
			Assert.AreEqual(1, vector[iterator]);

			++iterator;
			Assert.AreEqual(1, iterator.Index);
			Assert.AreEqual(2, vector[iterator]);

			++iterator;
			Assert.AreEqual(2, iterator.Index);
			Assert.AreEqual(3, vector[iterator]);

			++iterator;
			Assert.AreEqual(3, iterator.Index);
			Assert.AreEqual(4, vector[iterator]);

			++iterator;
			Assert.AreEqual(4, iterator.Index);
			Assert.AreEqual(5, vector[iterator]);
			Assert.AreEqual(vector.Last(), iterator);
		}

		[Test]
		public void VectorIteratorThrowsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(0);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);

			Assert.Throws<IndexOutOfRangeException>(() => _ = vector[vector.Previous(vector.First())]);
			Assert.Throws<IndexOutOfRangeException>(() => _ = vector[vector.Next(vector.Last())]);
		}

		[Test]
		public void VectorFirstIteratorTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);

			Assert.AreEqual(0, vector.First().Index);
			Assert.AreEqual(1, vector[vector.First()]);
		}

		[Test]
		public void VectorPreviousIteratorTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);

			Iterator iterator = vector.Last();
			iterator = vector.Previous(iterator);
			Assert.AreEqual(3, iterator.Index);
			Assert.AreEqual(4, vector[iterator]);

			iterator = vector.Previous(iterator);
			Assert.AreEqual(2, iterator.Index);
			Assert.AreEqual(3, vector[iterator]);

			iterator = vector.Previous(iterator);
			Assert.AreEqual(1, iterator.Index);
			Assert.AreEqual(2, vector[iterator]);

			iterator = vector.Previous(iterator);
			Assert.AreEqual(0, iterator.Index);
			Assert.AreEqual(1, vector[iterator]);
			Assert.AreEqual(vector[vector.First()], vector[iterator]);
			Assert.AreEqual(vector.First().Index, iterator.Index);
		}

		[Test]
		public void VectorNextIteratorTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);

			Iterator iterator = vector.First();
			iterator = vector.Next(iterator);
			Assert.AreEqual(1, iterator.Index);
			Assert.AreEqual(2, vector[iterator]);

			iterator = vector.Next(iterator);
			Assert.AreEqual(2, iterator.Index);
			Assert.AreEqual(3, vector[iterator]);

			iterator = vector.Next(iterator);
			Assert.AreEqual(3, iterator.Index);
			Assert.AreEqual(4, vector[iterator]);

			iterator = vector.Next(iterator);
			Assert.AreEqual(4, iterator.Index);
			Assert.AreEqual(5, vector[iterator]);
			Assert.AreEqual(vector[vector.Last()], vector[iterator]);
			Assert.AreEqual(vector.Last().Index, iterator.Index);
		}

		[Test]
		public void VectorLastIteratorTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);

			Assert.AreEqual(2, vector.Last().Index);
			Assert.AreEqual(3, vector[vector.Last()]);
		}

		[Test]
		public void VectorGetAtIndexTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(2, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(4, vector[3]);
			Assert.AreEqual(5, vector[4]);
			Assert.AreEqual(6, vector[5]);
		}

		[Test]
		public void VectorGetAtIndexThrowsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			Assert.Throws<IndexOutOfRangeException>(() => _ = vector[-1]);
			Assert.DoesNotThrow(() => _ = vector[0]);
			Assert.DoesNotThrow(() => _ = vector[1]);
			Assert.DoesNotThrow(() => _ = vector[2]);
			Assert.DoesNotThrow(() => _ = vector[3]);
			Assert.DoesNotThrow(() => _ = vector[4]);
			Assert.DoesNotThrow(() => _ = vector[5]);
			Assert.Throws<IndexOutOfRangeException>(() => _ = vector[6]);
		}

		[Test]
		public void VectorSetAtIndexTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(0);
			vector.Add(0);
			vector.Add(0);
			vector.Add(0);
			vector.Add(0);
			vector.Add(0);

			vector[0] = 1;
			vector[1] = 2;
			vector[2] = 3;
			vector[3] = 4;
			vector[4] = 5;
			vector[5] = 6;

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(2, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(4, vector[3]);
			Assert.AreEqual(5, vector[4]);
			Assert.AreEqual(6, vector[5]);
		}

		[Test]
		public void VectorGetInvalidIndexThrowsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);

			Assert.Throws<IndexOutOfRangeException>(() => _ = vector[3]);
		}

		[Test]
		public void VectorSetInvalidIndexThrowsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);

			Assert.Throws<IndexOutOfRangeException>(() => vector[3] = 4);
		}

		[Test]
		public void VectorAddRemoveIndexPreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			vector.RemoveAt(0);
			vector.RemoveAt(0);
			vector.RemoveAt(0);

			// 1, 2, 3, 4, 5, 6
			// 2, 3, 4, 5, 6
			// 3, 4, 5, 6
			// 4, 5, 6

			vector.Add(7);
			vector.Add(8);
			vector.Add(9);

			// 4, 5, 6, 7, 8, 9

			Assert.AreEqual(4, vector[0]);
			Assert.AreEqual(5, vector[1]);
			Assert.AreEqual(6, vector[2]);
			Assert.AreEqual(7, vector[3]);
			Assert.AreEqual(8, vector[4]);
			Assert.AreEqual(9, vector[5]);

			vector.RemoveAt(3);
			vector.RemoveAt(2);
			vector.RemoveAt(1);

			// 4, 5, 6, 7, 8, 9
			// 4, 5, 6, 8, 9
			// 4, 5, 8, 9
			// 4, 8, 9

			Assert.AreEqual(4, vector[0]);
			Assert.AreEqual(8, vector[1]);
			Assert.AreEqual(9, vector[2]);
		}

		[Test]
		public void VectorAddRemoveIndexAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			// 1, 2, 3, 4, 5, 6
			// 6, 2, 3, 4, 5
			// 5, 2, 3, 4
			// 4, 2, 3

			vector.RemoveAt(0);
			vector.RemoveAt(0);
			vector.RemoveAt(0);

			vector.Add(7);
			vector.Add(8);
			vector.Add(9);

			// 4, 2, 3, 7, 8, 9

			Assert.AreEqual(4, vector[0]);
			Assert.AreEqual(2, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(7, vector[3]);
			Assert.AreEqual(8, vector[4]);
			Assert.AreEqual(9, vector[5]);

			vector.RemoveAt(3);
			vector.RemoveAt(2);
			vector.RemoveAt(1);

			// 4, 2, 3, 7, 8, 9
			// 4, 2, 3, 9, 8
			// 4, 2, 8, 9
			// 4, 9, 8

			Assert.AreEqual(4, vector[0]);
			Assert.AreEqual(9, vector[1]);
			Assert.AreEqual(8, vector[2]);
		}

		[Test]
		public void VectorAddTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			Assert.AreEqual(1, vector.Count);

			vector.Add(2);
			Assert.AreEqual(2, vector.Count);

			vector.Add(3);
			Assert.AreEqual(3, vector.Count);

			vector.Add(4);
			Assert.AreEqual(4, vector.Count);
		}

		[Test]
		public void VectorAddGrowCapacityTest()
		{
			int initialCapacity = 2;
			int growBy = 4;

			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			Assert.AreEqual(1, vector.Count);
			Assert.AreEqual(initialCapacity, vector.Capacity);

			vector.Add(2);
			Assert.AreEqual(2, vector.Count);
			Assert.AreEqual(initialCapacity, vector.Capacity);

			vector.Add(3);
			Assert.AreEqual(3, vector.Count);
			Assert.AreEqual(initialCapacity + growBy, vector.Capacity);

			vector.Add(4);
			Assert.AreEqual(4, vector.Count);
			Assert.AreEqual(initialCapacity + growBy, vector.Capacity);

			vector.Add(5);
			Assert.AreEqual(5, vector.Count);
			Assert.AreEqual(initialCapacity + growBy, vector.Capacity);

			vector.Add(6);
			Assert.AreEqual(6, vector.Count);
			Assert.AreEqual(initialCapacity + growBy, vector.Capacity);

			vector.Add(7);
			Assert.AreEqual(7, vector.Count);
			Assert.AreEqual(initialCapacity + (2 * growBy), vector.Capacity);

			vector.Add(8);
			Assert.AreEqual(8, vector.Count);
			Assert.AreEqual(initialCapacity + (2 * growBy), vector.Capacity);
		}

		[Test]
		public void VectorAddRangeTest()
		{
			int initialCapacity = 3;
			var originList = new Vector<int>(initialCapacity);
			originList.Add(1);
			originList.Add(2);
			originList.Add(3);

			var additionList = new Vector<int>(initialCapacity);
			additionList.Add(6);
			additionList.Add(5);
			additionList.Add(4);

			originList.AddRange(additionList);

			Assert.AreEqual(6, originList.Count);
			Assert.AreEqual(6, originList.Capacity);

			Assert.AreEqual(1, originList[0]);
			Assert.AreEqual(2, originList[1]);
			Assert.AreEqual(3, originList[2]);
			Assert.AreEqual(6, originList[3]);
			Assert.AreEqual(5, originList[4]);
			Assert.AreEqual(4, originList[5]);
		}

		[Test]
		public void VectorInsertPreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);
			vector.Add(2);
			vector.Add(4);
			vector.Add(6);

			// [2, 4, 6]

			vector.Insert(1, 0);

			// [1, 2, 4, 6]

			vector.Insert(3, 2);

			// [1, 2, 3, 4, 6]

			vector.Insert(5, 4);

			// [1, 2, 3, 4, 5, 6]

			vector.Insert(7, 6);

			// [1, 2, 3, 4, 5, 6, 7]

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(2, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(4, vector[3]);
			Assert.AreEqual(5, vector[4]);
			Assert.AreEqual(6, vector[5]);
			Assert.AreEqual(7, vector[6]);
		}

		[Test]
		public void VectorInsertBeginningPreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			// [4, 5, 6]

			vector.Insert(3, 0);

			// [3, 4, 5, 6]

			vector.Insert(2, 0);

			// [2, 3, 4, 5, 6]

			vector.Insert(1, 0);

			// [1, 2, 3, 4, 5, 6]

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(2, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(4, vector[3]);
			Assert.AreEqual(5, vector[4]);
			Assert.AreEqual(6, vector[5]);
		}

		[Test]
		public void VectorInsertBeginningAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			// [4, 5, 6]

			vector.Insert(3, 0);

			// [3, 5, 6, 4]

			vector.Insert(2, 0);

			// [2, 5, 6, 4, 3]

			vector.Insert(1, 0);

			// [1, 5, 6, 4, 3, 2]

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(5, vector[1]);
			Assert.AreEqual(6, vector[2]);
			Assert.AreEqual(4, vector[3]);
			Assert.AreEqual(3, vector[4]);
			Assert.AreEqual(2, vector[5]);
		}

		[Test]
		public void VectorInsertAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);
			vector.Add(2);
			vector.Add(4);
			vector.Add(6);

			// [2, 4, 6]

			vector.Insert(1, 0);
			vector.Insert(3, 2);
			vector.Insert(5, 4);

			// [1, 4, 6, 2]
			// [1, 4, 3, 2, 6]
			// [1, 4, 3, 2, 5, 6]

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(4, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(2, vector[3]);
			Assert.AreEqual(5, vector[4]);
			Assert.AreEqual(6, vector[5]);
		}

		[Test]
		public void VectorInsertInvalidIndexThrowsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			Assert.DoesNotThrow(() => vector.Insert(1, 0));

			vector.Add(2);
			vector.Add(3);

			// [1, 2, 3]

			Assert.DoesNotThrow(() => vector.Insert(1, 0));

			// [1, 1, 2, 3]

			Assert.DoesNotThrow(() => vector.Insert(4, 4));

			// [1, 1, 2, 3, 4]

			Assert.DoesNotThrow(() => vector.Insert(2, 2));

			// [1, 1, 2, 2, 3, 4]

			Assert.Throws<IndexOutOfRangeException>(() => vector.Insert(0, -1));
			Assert.Throws<IndexOutOfRangeException>(() => vector.Insert(11, 10));
			Assert.Throws<IndexOutOfRangeException>(() => vector.Insert(int.MaxValue, 911));
		}

		[Test]
		public void VectorRemovePreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Remove(3);

			Assert.AreEqual(4, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.True(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.False(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.True(vector.Contains(5));
			Assert.False(vector.Contains(6));
		}

		[Test]
		public void VectorRemoveAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);

			// [1, 2, 3, 4, 5]

			vector.Remove(3);

			// [1, 2, 5, 4]

			Assert.AreEqual(4, vector.Count);
			Assert.True(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.False(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.True(vector.Contains(5));

			vector.Remove(1);

			// [4, 2, 5]

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.False(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.True(vector.Contains(5));

			vector.Remove(6);

			// [4, 2, 5]

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.False(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.True(vector.Contains(5));
		}

		[Test]
		public void VectorAddRemovePreservedOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			Assert.False(vector.Remove(2));
			vector.Add(2);
			Assert.True(vector.Remove(2));
			vector.Add(3);
			Assert.False(vector.Remove(4));
			vector.Add(4);
			Assert.True(vector.Remove(4));
			vector.Add(5);
			Assert.False(vector.Remove(6));
			vector.Add(6);
			Assert.True(vector.Remove(6));
			Assert.False(vector.Remove(7));

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.True(vector.Contains(1));
			Assert.False(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.False(vector.Contains(4));
			Assert.True(vector.Contains(5));
			Assert.False(vector.Contains(6));
			Assert.False(vector.Contains(7));
			Assert.False(vector.Contains(8));
			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(3, vector[1]);
			Assert.AreEqual(5, vector[2]);
		}

		[Test]
		public void VectorAddRemoveAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);

			// [1] 

			Assert.False(vector.Remove(2));

			// [1]

			vector.Add(2);

			// [1, 2]

			Assert.True(vector.Remove(2));

			// [1]

			vector.Add(3);

			// [1, 3]

			Assert.False(vector.Remove(4));

			// [1, 3]

			vector.Add(4);

			// [1, 3, 4]

			Assert.True(vector.Remove(4));

			// [1, 3]

			vector.Add(5);

			// [1, 3, 5]

			Assert.False(vector.Remove(6));

			// [1, 3, 5]

			vector.Add(6);

			// [1, 3, 5, 6]

			Assert.True(vector.Remove(6));

			// [1, 3, 5]

			Assert.False(vector.Remove(7));

			// [1, 3, 5]

			Assert.True(vector.Remove(1));

			// [5, 3]

			Assert.False(vector.Remove(1));

			// [5, 3]

			Assert.AreEqual(2, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.False(vector.Contains(1));
			Assert.False(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.False(vector.Contains(4));
			Assert.True(vector.Contains(5));
			Assert.AreEqual(5, vector[0]);
			Assert.AreEqual(3, vector[1]);
		}

		[Test]
		public void VectorRemoveSinglePreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			Assert.True(vector.Remove(1));

			Assert.AreEqual(4, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.True(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.False(vector.Contains(5));
			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(2, vector[1]);
			Assert.AreEqual(3, vector[2]);
			Assert.AreEqual(4, vector[3]);
		}

		[Test]
		public void VectorRemoveSingleAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);

			// [1, 1, 2, 3, 4]

			Assert.True(vector.Remove(1));

			// [4, 1, 2, 3]

			Assert.AreEqual(4, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.True(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.False(vector.Contains(5));
			Assert.AreEqual(4, vector[0]);
			Assert.AreEqual(1, vector[1]);
			Assert.AreEqual(2, vector[2]);
			Assert.AreEqual(3, vector[3]);
		}

		[Test]
		public void VectorRemoveMultiplePreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			Assert.True(vector.Remove(1));
			Assert.True(vector.Remove(1));
			Assert.False(vector.Remove(1));

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.False(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.False(vector.Contains(5));
			Assert.AreEqual(2, vector[0]);
			Assert.AreEqual(3, vector[1]);
			Assert.AreEqual(4, vector[2]);
		}

		[Test]
		public void VectorRemoveMultipleAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);

			// [1, 1, 2, 3, 4]

			Assert.True(vector.Remove(1));

			// [4, 1, 2, 3]

			Assert.True(vector.Remove(1));

			// [4, 3, 2]

			Assert.False(vector.Remove(1));

			// [4, 3, 2]

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.False(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.False(vector.Contains(5));
			Assert.AreEqual(4, vector[0]);
			Assert.AreEqual(3, vector[1]);
			Assert.AreEqual(2, vector[2]);
		}

		[Test]
		public void VectorRemoveAllPreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.RemoveAll(1);

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.False(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.False(vector.Contains(5));
			Assert.AreEqual(2, vector[0]);
			Assert.AreEqual(3, vector[1]);
			Assert.AreEqual(4, vector[2]);
		}

		[Test]
		public void VectorRemoveAllAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);

			// [1, 1, 2, 3, 4]

			vector.RemoveAll(1);

			// [1, 4, 2, 3]
			// [3, 4, 2]

			Assert.AreEqual(3, vector.Count);
			Assert.False(vector.Contains(0));
			Assert.False(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.False(vector.Contains(5));
			Assert.AreEqual(3, vector[0]);
			Assert.AreEqual(4, vector[1]);
			Assert.AreEqual(2, vector[2]);
		}

		[Test]
		public void VectorRemoveAtPreserveOrderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			vector.RemoveAt(5);
			vector.RemoveAt(3);
			vector.RemoveAt(1);

			Assert.True(vector.Contains(1));
			Assert.False(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.False(vector.Contains(4));
			Assert.True(vector.Contains(5));
			Assert.False(vector.Contains(6));

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(3, vector[1]);
			Assert.AreEqual(5, vector[2]);
		}

		[Test]
		public void VectorRemoveAtAllowReorderTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);
			vector.Add(6);

			// [1, 2, 3, 4, 5, 6]

			vector.RemoveAt(5);

			// [1, 2, 3, 4, 5]

			vector.RemoveAt(3);

			// [1, 2, 3, 5]

			vector.RemoveAt(1);

			// [1, 5, 3]

			Assert.True(vector.Contains(1));
			Assert.False(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.False(vector.Contains(4));
			Assert.True(vector.Contains(5));
			Assert.False(vector.Contains(6));

			Assert.AreEqual(1, vector[0]);
			Assert.AreEqual(5, vector[1]);
			Assert.AreEqual(3, vector[2]);
		}

		[Test]
		public void VectorRemoveAtInvalidIndexThrowsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);

			Assert.Throws<IndexOutOfRangeException>(() => vector.RemoveAt(3));
		}

		[Test]
		public void VectorContainsTest()
		{
			int initialCapacity = 4;
			var vector = new Vector<int>(initialCapacity);

			vector.Add(1);
			vector.Add(2);
			vector.Add(3);
			vector.Add(4);
			vector.Add(5);

			Assert.False(vector.Contains(0));
			Assert.True(vector.Contains(1));
			Assert.True(vector.Contains(2));
			Assert.True(vector.Contains(3));
			Assert.True(vector.Contains(4));
			Assert.True(vector.Contains(5));
			Assert.False(vector.Contains(6));
		}

		[Test]
		public void VectorPreserveOrderStressTest()
		{
			int initialCapacity = 65_536;
			var vector = new Vector<int>(initialCapacity, VectorPreferences.PreserveOrder);
			var random = new Random(123456789);

			for (int i = 0; i < 1_000_000; ++i)
			{
				int previousCount = vector.Count;

				switch (random.Next(3))
				{
					case 0:
					{
						vector.Add(i);
						Assert.AreEqual(previousCount + 1, vector.Count);
						Assert.AreEqual(i, vector[previousCount]);
						Assert.AreEqual(i, vector[vector.Last()]);
						Assert.True(vector.Contains(i));
						break;
					}

					case 1:
					{
						if (vector.Count > 0)
						{
							int removeIndex = random.Next(vector.Count - 1);
							int removeValue = vector[removeIndex];

							vector.RemoveAt(removeIndex);
							Assert.AreEqual(previousCount - 1, vector.Count);
							Assert.False(vector.Contains(removeValue));
						}

						break;
					}

					case 2:
					{
						if (vector.Count > 0)
						{
							int removeValue = vector[random.Next(vector.Count - 1)];

							vector.Remove(removeValue);
							Assert.AreEqual(previousCount - 1, vector.Count);
							Assert.False(vector.Contains(removeValue));
						}

						break;
					}

					case 3:
					{
						if (vector.Count > 0)
						{
							int insertIndex = random.Next(vector.Count - 1);

							vector.Insert(i, insertIndex);
							Assert.AreEqual(previousCount + 1, vector.Count);
							Assert.AreEqual(i, vector[insertIndex]);
							Assert.True(vector.Contains(i));
						}

						break;
					}
				}
			}
		}

		[Test]
		public void VectorAllowReorderStressTest()
		{
			int initialCapacity = 65_536;
			var vector = new Vector<int>(initialCapacity);
			var random = new Random(123456789);

			for (int i = 0; i < 1_000_000; ++i)
			{
				int previousCount = vector.Count;

				switch (random.Next(3))
				{
					case 0:
					{
						vector.Add(i);
						Assert.AreEqual(previousCount + 1, vector.Count);
						Assert.AreEqual(i, vector[previousCount]);
						Assert.AreEqual(i, vector[vector.Last()]);
						Assert.True(vector.Contains(i));
						break;
					}

					case 1:
					{
						if (vector.Count > 0)
						{
							int removeIndex = random.Next(vector.Count - 1);
							int removeValue = vector[removeIndex];

							vector.RemoveAt(removeIndex);
							Assert.AreEqual(previousCount - 1, vector.Count);
							Assert.False(vector.Contains(removeValue));
						}

						break;
					}

					case 2:
					{
						if (vector.Count > 0)
						{
							int removeValue = vector[random.Next(vector.Count - 1)];

							vector.Remove(removeValue);
							Assert.AreEqual(previousCount - 1, vector.Count);
							Assert.False(vector.Contains(removeValue));
						}

						break;
					}

					case 3:
					{
						if (vector.Count > 0)
						{
							int insertIndex = random.Next(vector.Count - 1);

							vector.Insert(i, insertIndex);
							Assert.AreEqual(previousCount + 1, vector.Count);
							Assert.AreEqual(i, vector[insertIndex]);
							Assert.True(vector.Contains(i));
						}

						break;
					}
				}
			}
		}
	}
}