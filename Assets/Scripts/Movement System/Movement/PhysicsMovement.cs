using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PhysicsMovement : MonoBehaviour, IMove, IProccess, IGetGrounded
{
    [SerializeField,Min(0)]
    private float _mass;
    public float _gravity = -9.8f;

	[field:SerializeField]
	public UnityEvent<Vector3> OnMoveEvent { get; private set; } = new UnityEvent<Vector3>();

	public event Action<Vector3> OnMove;

	public Vector3 moveValue { get; private set; }

	public bool Grounded { get; set; }

	public void Process()
	{
		if (Grounded && moveValue.y < 0)
			moveValue = Vector3.down * 2;
		else
			moveValue += Vector3.up * _gravity * Time.deltaTime;
		OnMove?.Invoke(moveValue);
		OnMoveEvent?.Invoke(moveValue);
	}

	public void AddForce(Vector3 force) => moveValue += force / _mass;
}
