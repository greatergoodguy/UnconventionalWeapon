﻿using UnityEngine;
using System.Collections;

public class _MasterScript : MonoBehaviour {

	bool isPaused = false;

	Transform tPauseUI;

	void Awake() {
		tPauseUI = transform.FindChild("Pause UI");
	}

	void Start() {
		God.Hero.EquipWeapon(God.Weapon);
		God.Weapon.Activate();
		God.WeaponUI.Activate();
	}

	void Update () {
		if((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !isPaused) {
			Pause();
		}
		else if((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && isPaused) {
			UnPause();
		}
	}

	void Pause() {
		isPaused = true;
		tPauseUI.gameObject.SetActive(true);
		God.Hero.Freeze();
		Time.timeScale = 0;
	}

	void UnPause() {
		Time.timeScale = 1;
		God.Hero.UnFreeze();
		tPauseUI.gameObject.SetActive(false);
		isPaused = false;
	}
}
