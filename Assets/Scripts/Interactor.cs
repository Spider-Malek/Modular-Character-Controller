using UnityEngine;
using UnityEngine.InputSystem;

namespace Dynamic.Movement
{
    public class Interactor : MonoBehaviour, IGetInput
    {
        [SerializeField]
        private Transform _cameraTransform;
        [SerializeField]
        private float _maxInteractionDistance;
        [SerializeField]
        private LayerMask _interactableLayer;

        public void GetInput(InputAction.CallbackContext context)
        {
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit raycastHit, _maxInteractionDistance, _interactableLayer))
            {
                Debug.Log(raycastHit.collider.gameObject);
                if (raycastHit.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}