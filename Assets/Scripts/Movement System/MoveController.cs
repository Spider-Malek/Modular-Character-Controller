using Dynamic.Movement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dynamic.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class MoveController : MonoBehaviour
    {
        private CharacterController _characterController;

        private List<IMove> _moveBases = new List<IMove>();
        private List<IProccess> _proccess = new List<IProccess>();
        private List<IGetGrounded> _grounded = new List<IGetGrounded>();

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _moveBases = GetComponents<IMove>().ToList();
            _proccess = GetComponents<IProccess>().ToList();
            _grounded = GetComponents<IGetGrounded>().ToList();
            GetComponents<IGetComponent>().ToList().ForEach(ic => ic.GetComponentsFromSelf(this));
            //PlayerUtils.DeactivateCursor();
        }

        private void Update()
        {
            Vector3 moveValue = Vector3.zero;

            _grounded.ForEach(g => g.Grounded = _characterController.isGrounded);
            _proccess.ForEach(p => p.Process());
            _moveBases.ForEach(m => moveValue += m.moveValue);

            _characterController.Move(moveValue * Time.deltaTime);
        }
    }
}