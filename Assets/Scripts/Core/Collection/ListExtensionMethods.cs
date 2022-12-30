using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Bitwise.Core.Collections
{
	public static class ListExtensionMethods
	{
		public static void AddUnique<T>(this IList<T> list, T value)
		{
			if (list.Contains(value))
			{
				return;
			}

			list.Add(value);
		}

		public static int CountOf<T>(this IList<T> list, T value) where T : IEquatable<T>
		{
			int countOf = 0;
			for (int i = 0, count = list.Count; i < count; ++i)
			{
				if (list[i].Equals(value))
				{
					++countOf;
				}
			}

			return countOf;
		}

		public static void Shuffle<T>(this IList<T> list)
		{
			for (int i = list.Count - 1; i > 0; --i)
			{
				int j = Random.Range(0, i + 1);
				T temp = list[i];
				list[i] = list[j];
				list[j] = temp;
			}
		}

		public static IVector<T> ToVector<T>(this IList<T> list)
		{
			IVector<T> vector = new Vector<T>(list.Count);
			for (int i = 0, count = list.Count; i < count; ++i)
			{
				vector.Add(list[i]);
			}

			return vector;
		}

		public static void AddRange<T>(this IList<T> list, IIterable<T> iterable)
		{
			for (Iterator i = iterable.First(); i <= iterable.Last(); ++i)
			{
				list.Add(iterable[i]);
			}
		}

		public static bool ContainsAll<T>(this IList<T> list, IReadOnlyList<T> contains)
		{
			for (int i = 0, count = contains.Count; i < count; ++i)
			{
				if (false == list.Contains(contains[i]))
				{
					return false;
				}
			}

			return true;
		}
	}
}