using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ActorInfo : MonoBehaviour {

	private readonly string TAG = "ActorInfo";

	private readonly float CYCLE_SPEED_IN_SEC = 2.0f;

	private int currentAge = 3;
	private int maxAge = 9;
	private bool isAlive = true;

	private Text textName;
	private Text textCurrentAge;
	private Text textMaxAge;
	private Transform tImageDeath;
	private Transform tCanvas;

	private List<ActorHPChunk> hpChunks = new List<ActorHPChunk>();

	void Awake() {
		textName = transform.Find("Canvas/Panel/Text Name").GetComponent<Text>();
		textCurrentAge = transform.Find("Canvas/Panel/Text Current Age").GetComponent<Text>();
		textMaxAge = transform.Find("Canvas/Panel/Text Max Age").GetComponent<Text>();
		tImageDeath = transform.Find("Canvas/Panel/Health Panel/Death");
		tCanvas = transform.Find("Canvas");

		textCurrentAge.text = "Current Age: " + currentAge.ToString();
		textMaxAge.text = "Max Age: " + maxAge.ToString();

		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 1").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 2").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 3").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 4").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 5").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 6").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 7").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 8").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 9").GetComponent<ActorHPChunk>());
		hpChunks.Add(transform.Find("Canvas/Panel/Health Panel/HP Chunk 10").GetComponent<ActorHPChunk>());
	}

	public void Initiate(string name, int initialCurrentAge, int initialMaxAge) {
		textName.text = name;
		currentAge = initialCurrentAge;
		maxAge = initialMaxAge;

		int i=1;
		foreach(ActorHPChunk hpChunk in hpChunks) {
			if(i <= currentAge) {
				hpChunk.EnableAge();
			}
			else if(i > currentAge && i <= maxAge) {
				hpChunk.EnableCapacity();
			}
			else {
				hpChunk.Disable();
			}
			i++;
		}

		textCurrentAge.text = "Current Age: " + currentAge.ToString();
		textMaxAge.text = "Max Age: " + maxAge.ToString();
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

		maxAge--;
		if(maxAge < currentAge) {
			tImageDeath.gameObject.SetActive(true);
			isAlive = false;}
		else {
			hpChunks[maxAge].EnableLost();
		}

		textCurrentAge.text = "Current Age: " + currentAge.ToString();
		textMaxAge.text = "Max Age: " + maxAge.ToString();
	}

	void IncrementCurrentAge() {
		if(!isAlive) {
			return;}
		
		currentAge++;
		if(maxAge < currentAge) {
			tImageDeath.gameObject.SetActive(true);
			isAlive = false;}
		else {
			hpChunks[currentAge - 1].EnableAge();
		}
		
		textCurrentAge.text = "Current Age: " + currentAge.ToString();
		textMaxAge.text = "Max Age: " + maxAge.ToString();
	}

	public void Show() {
		tCanvas.gameObject.SetActive(true);
	}

	public void Hide() {
		tCanvas.gameObject.SetActive(false);
	}
}
