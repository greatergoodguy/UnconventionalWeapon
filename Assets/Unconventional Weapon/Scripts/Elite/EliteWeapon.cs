using UnityEngine;
using System.Collections;

public class EliteWeapon : MonoBehaviour {
	
	public void Activate() {
		ArcReactorDemoGunController component = transform.FindChild("Gun").GetComponent<ArcReactorDemoGunController>();
		component.enabled = true;
	}
}
