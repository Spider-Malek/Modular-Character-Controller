using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FPSMovement : MonoBehaviour, IMove, IGetInput, IProccess
{
	[SerializeField]
	private Speed _speed;
	private Vector2 moveInput;

	public event System.Action<Vector3> OnMove;

	public Vector3 moveValue { get; private set; }

	[field:SerializeField]
	public UnityEvent<Vector3> OnMoveEvent { get; private set; } = new UnityEvent<Vector3>();

	public void GetInput(InputAction.CallbackContext context) => moveInput = context.ReadValue<Vector2>();

	public void Process() 
	{
		var moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
		moveValue = moveDirection.normalized * _speed.baseValue;

		OnMove?.Invoke(moveValue);
		OnMoveEvent?.Invoke(moveValue);
	}
}
