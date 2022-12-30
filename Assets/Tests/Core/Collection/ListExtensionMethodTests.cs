using System.Collections.Generic;
using Bitwise.Core.Collections;
using NUnit.Framework;

namespace Bitwise.Tests.Core.Collections
{
	public class ListExtensionMethodTests
	{
		[Test]
		public void IListExtensionAddUniqueTest()
		{
			IList<int> list = new List<int>(10);
			for (int i = 1; i <= 6; ++i)
			{
				list.Add(i);
			}

			for (int i = 1; i <= 10; ++i)
			{
				list.AddUnique(i);
			}

			Assert.AreEqual(10, list.Count);
			Assert.AreEqual(0, list.CountOf(-1));
			Assert.AreEqual(0, list.CountOf(0));
			Assert.AreEqual(1, list.CountOf(1));
			Assert.AreEqual(1, list.CountOf(2));
			Assert.AreEqual(1, list.CountOf(3));
			Assert.AreEqual(1, list.CountOf(4));
			Assert.AreEqual(1, list.CountOf(5));
			Assert.AreEqual(1, list.CountOf(6));
			Assert.AreEqual(1, list.CountOf(7));
			Assert.AreEqual(1, list.CountOf(8));
			Assert.AreEqual(1, list.CountOf(9));
			Assert.AreEqual(1, list.CountOf(10));
			Assert.AreEqual(0, list.CountOf(11));
		}

		[Test]
		public void IListExtensionCountOfTest()
		{
			IList<int> list = new List<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				list.Add(i);
			}

			Assert.AreEqual(10, list.Count);
			Assert.AreEqual(0, list.CountOf(-1));
			Assert.AreEqual(0, list.CountOf(0));
			Assert.AreEqual(1, list.CountOf(1));
			Assert.AreEqual(1, list.CountOf(2));
			Assert.AreEqual(1, list.CountOf(3));
			Assert.AreEqual(1, list.CountOf(4));
			Assert.AreEqual(1, list.CountOf(5));
			Assert.AreEqual(1, list.CountOf(6));
			Assert.AreEqual(1, list.CountOf(7));
			Assert.AreEqual(1, list.CountOf(8));
			Assert.AreEqual(1, list.CountOf(9));
			Assert.AreEqual(1, list.CountOf(10));
			Assert.AreEqual(0, list.CountOf(11));
		}

		[Test]
		public void IListExtensionShuffleTest()
		{
			IList<int> list = new List<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				list.Add(i);
			}

			list.Shuffle();

			Assert.AreEqual(10, list.Count);
			Assert.AreEqual(0, list.CountOf(-1));
			Assert.AreEqual(0, list.CountOf(0));
			Assert.AreEqual(1, list.CountOf(1));
			Assert.AreEqual(1, list.CountOf(2));
			Assert.AreEqual(1, list.CountOf(3));
			Assert.AreEqual(1, list.CountOf(4));
			Assert.AreEqual(1, list.CountOf(5));
			Assert.AreEqual(1, list.CountOf(6));
			Assert.AreEqual(1, list.CountOf(7));
			Assert.AreEqual(1, list.CountOf(8));
			Assert.AreEqual(1, list.CountOf(9));
			Assert.AreEqual(1, list.CountOf(10));
			Assert.AreEqual(0, list.CountOf(11));
		}

		[Test]
		public void IListExtensionToVectorTest()
		{
			IList<int> list = new List<int>(10);
			for (int i = 1; i <= 10; ++i)
			{
				list.Add(i);
			}

			IVector<int> vector = list.ToVector();

			Assert.AreEqual(10, vector.Count);
			Assert.False(vector.Contains(-1));
			Assert.False(vector.Contains(0));
			Assert.AreEqual(vector[0], 1);
			Assert.AreEqual(vector[1], 2);
			Assert.AreEqual(vector[2], 3);
			Assert.AreEqual(vector[3], 4);
			Assert.AreEqual(vector[4], 5);
			Assert.AreEqual(vector[5], 6);
			Assert.AreEqual(vector[6], 7);
			Assert.AreEqual(vector[7], 8);
			Assert.AreEqual(vector[8], 9);
			Assert.AreEqual(vector[9], 10);
			Assert.False(vector.Contains(11));
		}

		[Test]
		public void IListExtensionAddRangeIIterableTest()
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