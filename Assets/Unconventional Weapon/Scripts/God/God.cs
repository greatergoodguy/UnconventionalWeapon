using UnityEngine;
using System.Collections;

public static class God {

	private static EliteGuidanceUI guidanceUI;
	public static EliteGuidanceUI GuidanceUI {
		get {
			if(guidanceUI == null) {
				guidanceUI = GameObject.FindGameObjectWithTag("Guidance UI").GetComponent<EliteGuidanceUI>();
			}
			return guidanceUI;
		}
	}

	private static EliteWeapon weapon;
	public static EliteWeapon Weapon {
		get {
			if(weapon == null) {
				weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<EliteWeapon>();
			}
			return weapon;
		}
	}

	private static EliteWeaponUI weaponUI;
	public static EliteWeaponUI WeaponUI {
		get {
			if(weaponUI == null) {
				weaponUI = GameObject.FindGameObjectWithTag("Weapon UI").GetComponent<EliteWeaponUI>();
			}
			return weaponUI;
		}
	}

	private static EliteMissionUI missionUI;
	public static EliteMissionUI MissionUI {
		get {
			if(missionUI == null) {
				missionUI = GameObject.FindGameObjectWithTag("Mission UI").GetComponent<EliteMissionUI>();
			}
			return missionUI;
		}
	}

	private static EliteHero hero;
	public static EliteHero Hero {
		get {
			if(hero == null) {
				hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<EliteHero>();
			}
			return hero;
		}
	}
}
