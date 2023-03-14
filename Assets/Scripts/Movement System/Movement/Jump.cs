using Dynamic.Movement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Dynamic.Movement
{
	public class Jump : MonoBehaviour, IGetGrounded, IGetInput, IGetComponent
	{
		[SerializeField]
		private float _jumpForce;

		private PhysicsMovement _physicsMovement;

		public event System.Action OnJump;

		public UnityEvent OnJumpEvent = new UnityEvent();

		public bool Grounded { get; set; }


		public void GetInput(InputAction.CallbackContext context)
		{
			if (Grounded)
			{
				_physicsMovement.AddForce(Vector3.up * Mathf.Sqrt(-2 * _jumpForce * _physicsMovement._gravity));
				OnJump?.Invoke();
				OnJumpEvent?.Invoke();
			}
		}

		public void GetComponentsFromSelf(MonoBehaviour monoBehaviour)
		{
			_physicsMovement = monoBehaviour.GetComponent<PhysicsMovement>();
		}
	}
}