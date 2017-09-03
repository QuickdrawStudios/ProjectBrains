using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponStats {
	public int range;
	public int dice;
	public int hitChance;
	public int damage;

	public bool attackSilent;
	public bool openDoorSilent;
}
