using UnityEngine;

namespace Bitwise.Core.Component
{
	public class CachedTransformComponent : MonoBehaviour
	{
		private Transform _transform;

		// ----------------------------------------------------------------------------

		public Transform Transform
		{
			get
			{
				if (null == _transform)
				{
					_transform = transform;
				}

				return _transform;
			}
		}
	}
}