using UnityEngine;
using System.Collections;

public class EliteHero : MonoBehaviour {

	MouseLook mouseLookHero;
	MouseLook mouseLookCamera;

	void Awake() {
		mouseLookHero = GetComponent<MouseLook>();
		mouseLookCamera = transform.FindChild("Main Camera").GetComponent<MouseLook>();
	}

	void Update() {

	}

	public void EquipWeapon(EliteWeapon weapon) {
		Transform tWeaponContainer = transform.FindChild("Main Camera/Weapon Container");
		weapon.transform.parent = tWeaponContainer;
		weapon.transform.localPosition = Vector3.zero;
		weapon.transform.localRotation = Quaternion.identity;
	}

	public void Freeze() {
		mouseLookHero.enabled = false;
		mouseLookCamera.enabled = false;
	}

	public void UnFreeze() {
		mouseLookHero.enabled = true;
		mouseLookCamera.enabled = true;
	}
}
