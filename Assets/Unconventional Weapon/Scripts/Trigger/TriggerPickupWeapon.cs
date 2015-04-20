using UnityEngine;
using System.Collections;

public class TriggerPickupWeapon : MonoBehaviour {

	public readonly string TAG = "TriggerPickupWeapon";


	void Update() {
		if(Input.GetKeyDown(KeyCode.Z)) {
			UtilLogger.Log(TAG, "Pick Up Weapon");
			God.GuidanceUI.Text = "";
			God.Hero.EquipWeapon(God.Weapon);
			God.Weapon.Activate();
			God.WeaponUI.Activate();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.GuidanceUI.Text = "Press 'Z' to pick up Age-inator";
	}

	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.GuidanceUI.Text = "";
	}

}
