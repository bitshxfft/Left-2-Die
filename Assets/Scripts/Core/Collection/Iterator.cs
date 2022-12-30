using System;

namespace Bitwise.Core.Collections
{
	public readonly struct Iterator : IEquatable<Iterator>
	{
		public int Index { get; }

		// ----------------------------------------------------------------------------

		public Iterator(int index) => Index = index;

		// ----------------------------------------------------------------------------

		public static Iterator operator++(Iterator original) => new Iterator(original.Index + 1);

		public static Iterator operator--(Iterator original) => new Iterator(original.Index - 1);

		public static bool operator==(Iterator original, Iterator other) => original.Index == other.Index;

		public static bool operator!=(Iterator original, Iterator other) => original.Index != other.Index;

		public static bool operator<(Iterator original, Iterator other) => original.Index < other.Index;

		public static bool operator<=(Iterator original, Iterator other) => original.Index <= other.Index;

		public static bool operator>(Iterator original, Iterator other) => original.Index > other.Index;

		public static bool operator>=(Iterator original, Iterator other) => original.Index >= other.Index;

		// ----------------------------------------------------------------------------

		public bool Equals(Iterator other) => Index == other.Index;

		public override bool Equals(object obj) => obj is Iterator other && Equals(other);

		public override int GetHashCode() => Index;
	}
}