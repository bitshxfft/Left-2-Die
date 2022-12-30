namespace Bitwise.Core.Utility
{
	public readonly struct TimeData
	{
		public float DeltaTime { get; }
		public float Time { get; }
		public uint Frame { get; }

		// ----------------------------------------------------------------------------

		public TimeData(float deltaTime, float time, uint frame)
		{
			DeltaTime = deltaTime;
			Time = time;
			Frame = frame;
		}
	}
}