using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{

		[Header("Mobile Inputs")]
		public Joystick variableJoystick;
		public GameObject shootButton;

		[Header("Mobile Look Joystick")]
		public Joystick lookJoystick;


		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool shoot;
		public bool zoom;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		void Start()
		{
			SetCursorState(true);
#if UNITY_ANDROID || UNITY_IOS
			cursorLocked = false;
#endif
			SetCursorState(cursorLocked);
		}

		void Update()
		{
#if UNITY_ANDROID || UNITY_IOS
			if (variableJoystick != null)
			{
				MoveInput(new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical));
			}

			if (lookJoystick != null)
			{
				LookInput(new Vector2(lookJoystick.Horizontal, -lookJoystick.Vertical) * 15f); // عدد 10 برای حساسیت
			}
#endif
		}


#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
#if UNITY_STANDALONE
    if (cursorInputForLook)
        LookInput(value.Get<Vector2>());
#endif
		}


		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}

		public void OnZoom(InputValue value)
		{
			ZoomInput(value.isPressed);
		}


		public void OnShootButtonDown()
		{
			ShootInput(true);
		}

		public void OnShootButtonUp()
		{
			ShootInput(false);
		}
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

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}

		public void ZoomInput(bool newZoomState)
		{
			zoom = newZoomState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		public void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}

}
