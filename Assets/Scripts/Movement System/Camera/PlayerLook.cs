using UnityEngine;
using UnityEngine.InputSystem;

namespace Dynamic.Movement
{
	public class PlayerLook : MonoBehaviour, IGetInput
	{
		[SerializeField]
		private Transform _head;
		private float xRotation;

		public void GetInput(InputAction.CallbackContext context)
		{
			Vector2 lookValue = context.ReadValue<Vector2>();

			float xLook = lookValue.x * Time.deltaTime;
			float yLook = lookValue.y * Time.deltaTime;

			xRotation -= yLook;
			xRotation = Mathf.Clamp(xRotation, -90, 90);

			transform.Rotate(Vector3.up * xLook);
			_head.localRotation = Quaternion.Euler(xRotation, 0, 0);
		}
	}
}