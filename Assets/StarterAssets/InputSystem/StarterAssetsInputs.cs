using UnityEngine;
using System.Collections;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool bag;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Sub Behaviours")]
		public PlayerVisualsBehaviour playerVisualsBehaviour;

		//Action Maps
		private string actionMapPlayerControls = "Player";
		private string actionMapMenuControls = "UI";

		//Current Control Scheme
		private string currentControlScheme;

		[Header("Input Settings")]
		public PlayerInput playerInput;


#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnInteract(InputValue value)
        {
			InteractInput(value.isPressed);
        }
		public void OnBag(InputValue value)
        {
			BagInput(value.isPressed);
        }


		//INPUT SYSTEM AUTOMATIC CALLBACKS --------------

		//This is automatically called from PlayerInput, when the input device has changed
		//(IE: Keyboard -> Xbox Controller)
		public void OnControlsChanged()
		{

			if (playerInput.currentControlScheme != currentControlScheme)
			{
				currentControlScheme = playerInput.currentControlScheme;

				playerVisualsBehaviour.UpdatePlayerVisuals();
				RemoveAllBindingOverrides();
			}
		}

		//This is automatically called from PlayerInput, when the input device has been disconnected and can not be identified
		//IE: Device unplugged or has run out of batteries



		public void OnDeviceLost()
		{
			playerVisualsBehaviour.SetDisconnectedDeviceVisuals();
		}


		public void OnDeviceRegained()
		{
			StartCoroutine(WaitForDeviceToBeRegained());
		}

		IEnumerator WaitForDeviceToBeRegained()
		{
			yield return new WaitForSeconds(0.1f);
			playerVisualsBehaviour.UpdatePlayerVisuals();
		}
		void RemoveAllBindingOverrides()
		{
			InputActionRebindingExtensions.RemoveAllBindingOverrides(playerInput.currentActionMap);
		}
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

	
		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}
		public void InteractInput(bool newInteractState)
		{
			interact = newInteractState;
		}
		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		public void BagInput(bool newBagState)
		{
			bag = newBagState;
		}

#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}