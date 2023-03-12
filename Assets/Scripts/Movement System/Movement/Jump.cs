using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour, IGetGrounded, IGetInput
{
    [SerializeField]
    private float _jumpForce;

    private PhysicsMovement _physicsMovement;

    public event System.Action OnJump;

    public UnityEvent OnJumpEvent = new UnityEvent();

    public bool Grounded { get; set; }

    private void Awake()  => _physicsMovement = GetComponent<PhysicsMovement>(); 

    public void GetInput(InputAction.CallbackContext context)
	{
        if (Grounded)
		{
			_physicsMovement.AddForce(Vector3.up * Mathf.Sqrt(-2 * _jumpForce * _physicsMovement._gravity));
            OnJump?.Invoke();
            OnJumpEvent.Invoke();
		}
	}
}
