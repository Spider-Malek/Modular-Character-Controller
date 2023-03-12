using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float _openAngle;
    [SerializeField]
    private float _closedAngle;
    [SerializeField]
    private float _openSpeed = 15;
    private bool _isClosed;
	private Coroutine _doorInteractCoroutine;

    public void Interact()
	{
		if (_doorInteractCoroutine != null)
		{
			StopCoroutine(_doorInteractCoroutine);
		}
		_doorInteractCoroutine = StartCoroutine(ActOnDoor());

    }

    private IEnumerator ActOnDoor()
	{
		if (_isClosed)
		{
			_isClosed = false;
			while (transform.eulerAngles.y != _openAngle)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(_openAngle, Vector3.up), _openSpeed * Time.deltaTime);
				yield return null;
			}
		}
		else
		{
			_isClosed = true;
			while (transform.eulerAngles.y != _closedAngle)
			{
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(_closedAngle, Vector3.up), _openSpeed * Time.deltaTime);
				yield return null;
			}
		}
    }
}
