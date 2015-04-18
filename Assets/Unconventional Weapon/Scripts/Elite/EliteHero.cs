using UnityEngine;
using System.Collections;

public class EliteHero : MonoBehaviour {

	void Awake() {
	}

	public void EquipWeapon(EliteWeapon weapon) {
		Transform tWeaponContainer = transform.FindChild("Main Camera/Weapon Container");
		weapon.transform.parent = tWeaponContainer;
		weapon.transform.localPosition = Vector3.zero;
		weapon.transform.localRotation = Quaternion.identity;
	}
}
