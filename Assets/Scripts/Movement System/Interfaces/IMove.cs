using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public interface IMove
{
	public event System.Action<Vector3> OnMove;
	public UnityEvent<Vector3> OnMoveEvent { get; }
	public Vector3 moveValue { get; }
}
