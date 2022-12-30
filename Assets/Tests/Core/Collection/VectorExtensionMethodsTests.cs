using System.Collections.Generic;
using Bitwise.Core.Collections;
using NUnit.Framework;

namespace Bitwise.Tests.Core.Collections
{
	public class VectorExtensionMethodTests
	{
		[Test]
		public void IVectorExtensionAddUniqueTest()
		{
			IVector<int> vector = new Vector<int>(10);
			for (int i = 1; i <= 6; ++i)
			{
				vector.Add(i);
			}

			for (int i = 1; i <= 10; ++i)
			{
				vector.AddUnique(i);
			}

			Assert.AreEqual(10, vector.Count);
			Assert.AreEqual(0, vector.CountOf(-1));
			Assert.AreEqual(0, vector.CountOf(0));
			Assert.AreEqual(1, vector.CountOf(1));
			Assert.AreEqual(1, vector.CountOf(2));
			Assert.AreEqual(1, vector.CountOf(3));
			Assert.AreEqual(1, vector.CountOf(4));
			Assert.AreEqual(1, vector.CountOf(5));
			Assert.AreEqual(1, vector.CountOf(6));
			Assert.AreEqual(1, vector.CountOf(7));
			Assert.AreEqual(1, vector.CountOf(8));
			Assert.AreEqual(1, vector.CountOf(9));
			Assert.AreEqual(1, vector.CountOf(10));
			Assert.AreEqual(0, vector.CountOf(11));
		}

		[Test]
		public void IVectorExtensionCountOfTest()
		{
			IVector<int> vector = new Vector<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				vector.Add(i);
			}

			Assert.AreEqual(10, vector.Count);
			Assert.AreEqual(0, vector.CountOf(-1));
			Assert.AreEqual(0, vector.CountOf(0));
			Assert.AreEqual(1, vector.CountOf(1));
			Assert.AreEqual(1, vector.CountOf(2));
			Assert.AreEqual(1, vector.CountOf(3));
			Assert.AreEqual(1, vector.CountOf(4));
			Assert.AreEqual(1, vector.CountOf(5));
			Assert.AreEqual(1, vector.CountOf(6));
			Assert.AreEqual(1, vector.CountOf(7));
			Assert.AreEqual(1, vector.CountOf(8));
			Assert.AreEqual(1, vector.CountOf(9));
			Assert.AreEqual(1, vector.CountOf(10));
			Assert.AreEqual(0, vector.CountOf(11));
		}

		[Test]
		public void IVectorExtensionShuffleTest()
		{
			IVector<int> vector = new Vector<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				vector.Add(i);
			}

			vector.Shuffle();

			Assert.AreEqual(10, vector.Count);
			Assert.AreEqual(0, vector.CountOf(-1));
			Assert.AreEqual(0, vector.CountOf(0));
			Assert.AreEqual(1, vector.CountOf(1));
			Assert.AreEqual(1, vector.CountOf(2));
			Assert.AreEqual(1, vector.CountOf(3));
			Assert.AreEqual(1, vector.CountOf(4));
			Assert.AreEqual(1, vector.CountOf(5));
			Assert.AreEqual(1, vector.CountOf(6));
			Assert.AreEqual(1, vector.CountOf(7));
			Assert.AreEqual(1, vector.CountOf(8));
			Assert.AreEqual(1, vector.CountOf(9));
			Assert.AreEqual(1, vector.CountOf(10));
			Assert.AreEqual(0, vector.CountOf(11));
		}

		[Test]
		public void IVectorExtensionToListTest()
		{
			IVector<int> vector = new Vector<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				vector.Add(i);
			}

			IList<int> list = vector.ToList();

			Assert.AreEqual(10, list.Count);
			Assert.False(list.Contains(-1));
			Assert.False(list.Contains(0));
			Assert.AreEqual(list[0], 1);
			Assert.AreEqual(list[1], 2);
			Assert.AreEqual(list[2], 3);
			Assert.AreEqual(list[3], 4);
			Assert.AreEqual(list[4], 5);
			Assert.AreEqual(list[5], 6);
			Assert.AreEqual(list[6], 7);
			Assert.AreEqual(list[7], 8);
			Assert.AreEqual(list[8], 9);
			Assert.AreEqual(list[9], 10);
			Assert.False(list.Contains(11));
		}

		[Test]
		public void IVectorExtensionAddRangeIIterableTest()
		{
			IVector<int> vector = new Vector<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				vector.Add(i);
			}

			IList<int> list = new List<int>(vector.Count);
			list.AddRange(vector);

			Assert.AreEqual(10, list.Count);
			Assert.False(list.Contains(-1));
			Assert.False(list.Contains(0));
			Assert.AreEqual(list[0], 1);
			Assert.AreEqual(list[1], 2);
			Assert.AreEqual(list[2], 3);
			Assert.AreEqual(list[3], 4);
			Assert.AreEqual(list[4], 5);
			Assert.AreEqual(list[5], 6);
			Assert.AreEqual(list[6], 7);
			Assert.AreEqual(list[7], 8);
			Assert.AreEqual(list[8], 9);
			Assert.AreEqual(list[9], 10);
			Assert.False(list.Contains(11));
		}
	}
}