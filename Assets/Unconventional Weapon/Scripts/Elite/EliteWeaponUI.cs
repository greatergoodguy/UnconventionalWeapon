﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteWeaponUI : MonoBehaviour {

	private Text textWeaponMode;

	bool isModeAbsorbLife = true;
	public bool IsModeAbsorbLife {
		get { return isModeAbsorbLife;}
	}

	void Awake() {
		textWeaponMode = transform.FindChild("Canvas/Panel/Text Weapon Mode").GetComponent<Text>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			isModeAbsorbLife = true;
			textWeaponMode.text = "Weapon Mode: Absorb Life";
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			isModeAbsorbLife = false;
			textWeaponMode.text = "Weapon Mode: Age Accelerate";
		}
	}

	public void Activate() {
		Transform tCanvas = transform.FindChild("Canvas");
		tCanvas.gameObject.SetActive(true);
	}
}
