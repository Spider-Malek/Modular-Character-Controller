using UnityEngine;
using UnityEngine.InputSystem;

namespace Dynamic.Movement
{
	public class SprintSpeed : MonoBehaviour, IGetInput
	{
		[SerializeField]
		private Speed _speed;
		private float _walkSpeed;
		[SerializeField, Min(2)]
		private float _runSpeed;

		private void Awake() => _walkSpeed = _speed.baseValue;

		public void GetInput(InputAction.CallbackContext context) => _speed.baseValue = context.action.IsPressed() ? _runSpeed : _walkSpeed;
	}
}