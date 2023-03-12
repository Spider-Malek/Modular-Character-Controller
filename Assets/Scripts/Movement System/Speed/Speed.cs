using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speed",menuName = "Player Movement/Speed")]
public class Speed : ScriptableObject
{
	[field:SerializeField]
	public float baseValue { get; set; }

}
