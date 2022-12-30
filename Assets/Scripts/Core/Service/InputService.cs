using UnityEngine;
using UnityEngine.InputSystem;

namespace Bitwise.Core.Service
{
	public class InputService : MonoBehaviour, IService
	{
		public PlayerInput PlayerInput { get; private set; }

		// ----------------------------------------------------------------------------

		private void Awake()
		{
			PlayerInput = GetComponent<PlayerInput>();
		}

		// ----------------------------------------------------------------------------

		public void OnDeviceLost()
		{
			Debug.Log("[InputListenerSystem::OnDeviceLost]");
		}

		public void OnDeviceRegained()
		{
			Debug.Log("[InputListenerSystem::OnDeviceRegained]");
		}

		public void OnControlsChanged()
		{
			Debug.Log("[InputListenerSystem::OnControlsChanged]");
		}
	}
}