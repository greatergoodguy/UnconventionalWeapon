using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ActorInfo : MonoBehaviour {

	private readonly string TAG = "ActorInfo";

	private readonly float CYCLE_SPEED_IN_SEC = 2.0f;

	private int currentHP = 3;
	private int maxHP = 9;
	private bool isAlive = true;

	private Text textCurrentAge;
	private Text textMaxAge;
	private Transform tImageDeath;

	private List<ActorHPChunk> hpChunks = new List<ActorHPChunk>();

	void Awake() {
		textCurrentAge = transform.Find("Canvas/Panel/Text Current Age").GetComponent<Text>();
		textMaxAge = transform.Find("Canvas/Panel/Text Max Age").GetComponent<Text>();
		tImageDeath = transform.Find("Canvas/Panel/Health Panel/Death");

		textCurrentAge.text = "Current Age: " + currentHP.ToString();
		textMaxAge.text = "Max Age: " + maxHP.ToString();

		{
		}
	}
	
	void Update () {
		Vector3 heroPos = God.Hero.transform.position;
		transform.LookAt(new Vector3(heroPos.x, transform.position.y, heroPos.z));
	}
	
	private float elapsedTimeAbsorbLife = 0;
	private float elapsedTimeAgeAccelerate = 0;
	public void ArcReactorHit() {
		if(!isAlive) {
			return;}

		if(God.WeaponUI.IsModeAbsorbLife) {
			elapsedTimeAbsorbLife += Time.deltaTime;

			if(elapsedTimeAbsorbLife >= CYCLE_SPEED_IN_SEC) {
				elapsedTimeAbsorbLife = 0;
				DecrementMaxAge();
			}
		}
		else {
			elapsedTimeAgeAccelerate += Time.deltaTime;
			
			if(elapsedTimeAgeAccelerate >= CYCLE_SPEED_IN_SEC) {
				elapsedTimeAgeAccelerate = 0;
				IncrementCurrentAge();
			}
		}
	}

	void DecrementMaxAge() {
		if(!isAlive) {
			return;}

		maxHP--;
		if(maxHP < currentHP) {
			tImageDeath.gameObject.SetActive(true);
			isAlive = false;}

		textCurrentAge.text = "Current Age: " + currentHP.ToString();
		textMaxAge.text = "Max Age: " + maxHP.ToString();
	}

	void IncrementCurrentAge() {
		if(!isAlive) {
			return;}
		
		currentHP++;
		if(maxHP < currentHP) {
			tImageDeath.gameObject.SetActive(true);
			isAlive = false;}
		
		textCurrentAge.text = "Current Age: " + currentHP.ToString();
		textMaxAge.text = "Max Age: " + maxHP.ToString();
	}
}
