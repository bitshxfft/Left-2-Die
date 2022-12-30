using System;
using Bitwise.Core.Service;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
	public class PlayerController : MonoBehaviour
	{
		private void Start()
		{
			SetUpInputActions();
		}

		private void SetUpInputActions()
		{
			var inputService = ServiceLocator.Instance.Get<InputService>();
			PlayerInput playerInput = inputService.PlayerInput;

			SubscribeToAction("Move", Move);
			SubscribeToAction("Rotate", Rotate);
			SubscribeToAction("UseWeapon", UseWeapon);
			SubscribeToAction("ReloadWeapon", ReloadWeapon);
			SubscribeToAction("Interact", Interact);
			SubscribeToAction("Run", Run);

			void SubscribeToAction(string actionName, Action<InputAction.CallbackContext> action)
			{
				InputAction inputAction = playerInput.actions[actionName];
				if (null != inputAction)
				{
					inputAction.performed += action;
					inputAction.canceled += action;
				}
			}
		}

		// ----------------------------------------------------------------------------

		private void Move(InputAction.CallbackContext context)
		{
			var moveValue = context.ReadValue<Vector2>();
			Debug.Log($"[Player::Move] ({moveValue.x:0.00}, {moveValue.y:0.00})");
		}

		private void Rotate(InputAction.CallbackContext context)
		{
			var rotateValue = context.ReadValue<Vector2>();
			Debug.Log($"[Player::Rotate] ({rotateValue.x:0.00}, {rotateValue.y:0.00})");
		}

		private void UseWeapon(InputAction.CallbackContext context)
		{
			bool useWeaponStatus = context.ReadValueAsButton();
			Debug.Log($"[Player::UseWeapon] {useWeaponStatus}");
		}

		private void ReloadWeapon(InputAction.CallbackContext context)
		{
			bool reloadStatus = context.ReadValueAsButton();
			Debug.Log($"[Player::ReloadWeapon] {reloadStatus}");
		}

		private void Interact(InputAction.CallbackContext context)
		{
			bool interactStatus = context.ReadValueAsButton();
			Debug.Log($"[Player::Interact] {interactStatus}");
		}

		private void Run(InputAction.CallbackContext context)
		{
			bool runStatus = context.ReadValueAsButton();
			Debug.Log($"[Player::Run] {runStatus}");
		}
	}
}