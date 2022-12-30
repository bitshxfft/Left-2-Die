using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Bitwise.Core.Collections
{
	public static class VectorExtensionMethods
	{
		public static void AddUnique<T>(this IVector<T> vector, T value) where T : IEquatable<T>
		{
			for (Iterator i = vector.First(); i <= vector.Last(); ++i)
			{
				if (vector[i].Equals(value))
				{
					return;
				}
			}

			vector.Add(value);
		}

		public static int CountOf<T>(this IVector<T> vector, T value) where T : IEquatable<T>
		{
			int countOf = 0;
			for (Iterator i = vector.First(); i <= vector.Last(); ++i)
			{
				if (vector[i].Equals(value))
				{
					++countOf;
				}
			}

			return countOf;
		}

		public static void Shuffle<T>(this IVector<T> vector)
		{
			for (Iterator i = vector.First(); i <= vector.Last(); ++i)
			{
				int j = Random.Range(0, i.Index + 1);
				T temp = vector[i];
				vector[i] = vector[j];
				vector[j] = temp;
			}
		}

		public static IList<T> ToList<T>(this IVector<T> vector)
		{
			IList<T> list = new List<T>(vector.Count);
			for (Iterator i = vector.First(); i <= vector.Last(); ++i)
			{
				list.Add(vector[i]);
			}

			return list;
		}

		public static void AddRange<T>(this IVector<T> vector, List<T> list)
		{
			for (int i = 0, count = list.Count; i < count; ++i)
			{
				vector.Add(list[i]);
			}
		}
	}
}