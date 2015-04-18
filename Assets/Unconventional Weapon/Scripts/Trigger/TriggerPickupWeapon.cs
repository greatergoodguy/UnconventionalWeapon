using UnityEngine;
using System.Collections;

public class TriggerPickupWeapon : MonoBehaviour {

	public readonly string TAG = "TriggerPickupWeapon";

	void Update() {
		if(Input.GetKeyDown(KeyCode.Z)) {
			UtilLogger.Log(TAG, "Pick Up Weapon");
			God.GuidanceUI.SetText("");
			God.Hero.EquipWeapon(God.Weapon);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.GuidanceUI.SetText("Press 'Z' to pick up Age Sucker");
	}

	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.GuidanceUI.SetText("");
	}

}
