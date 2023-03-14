using UnityEngine;

namespace Dynamic.Movement
{
	[CreateAssetMenu(fileName = "New Speed", menuName = "Player Movement/Speed")]
	public class Speed : ScriptableObject
	{
		[field: SerializeField]
		public float baseValue { get; set; }

	}
}