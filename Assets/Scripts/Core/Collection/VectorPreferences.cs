using System;

namespace Bitwise.Core.Collections
{
	[Flags]
	public enum VectorPreferences
	{
		None = 0,
		PreserveOrder = 1 << 0,
	}
}