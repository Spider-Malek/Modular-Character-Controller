using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dynamic.Movement
{
	public static class PlayerUtils
	{
		public static void ActivateCursor()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public static void DeactivateCursor()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}