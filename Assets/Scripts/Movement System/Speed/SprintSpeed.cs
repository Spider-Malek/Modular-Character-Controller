using UnityEngine;
using UnityEngine.InputSystem;

public class SprintSpeed : MonoBehaviour, IGetInput
{
	[SerializeField]
	private Speed _speed;
	[SerializeField,Min(1)]
	private float _walkSpeed;
	[SerializeField,Min(2)]
	private float _runSpeed;

	private void Awake() => _speed.baseValue = _walkSpeed;

	public void GetInput(InputAction.CallbackContext context) => _speed.baseValue = context.action.IsPressed() ? _runSpeed : _walkSpeed;
}
