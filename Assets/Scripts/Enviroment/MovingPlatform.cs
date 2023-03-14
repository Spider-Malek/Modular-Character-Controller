using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dynamic.Movement 
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]
        private Vector3[] _movePositions;
        [SerializeField, Min(1)]
        private float _speed = 50;
        private Rigidbody _rigidBody;
        private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            StartCoroutine(MovePlatform(_movePositions));
        }


        private IEnumerator MovePlatform(Vector3[] movePositions)
        {
            for (int i = 0; i < movePositions.Length; i++)
            {
                while (Vector3.Distance(transform.position, movePositions[i]) > 0.5f)
                {
                    _rigidBody.velocity = (movePositions[i] - _rigidBody.position).normalized * Time.fixedDeltaTime * _speed;
                    yield return _waitForFixedUpdate;
                }
            }
            var movePoses = movePositions.Reverse().ToArray();
            StartCoroutine(MovePlatform(movePoses));
        }
    }
}