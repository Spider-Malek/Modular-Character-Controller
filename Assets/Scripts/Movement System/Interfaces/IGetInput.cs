using UnityEngine.InputSystem;

namespace Dynamic.Movement
{
	public interface IGetInput
	{
		public void GetInput(InputAction.CallbackContext context);
	}
}