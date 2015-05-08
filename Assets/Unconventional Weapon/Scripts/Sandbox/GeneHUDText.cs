using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneHUDText : MonoBehaviour {

	List<string> texts = new List<string>();

	HUDText hudText;

	void Awake() {
		texts.Add("Hello World");
		texts.Add("How are you?");
		texts.Add("I'm fine. Thank you.");
		texts.Add("Yo What's up Dawg.");

		hudText = GetComponent<HUDText>();
	}

	void Start() {
		StartCoroutine(StartSpeech());
	}

	void Update() {
//		HUDText hudText = GetComponent<HUDText>();
//		hudText.Add(Time.deltaTime * 10f, Color.black, 0f);
	}

	IEnumerator StartSpeech() {
		foreach(string text in texts) {
			hudText.Add(text, Color.black, 3f);
			yield return new WaitForSeconds(3f);
		}

		if(texts.Count != 0) {
			StartCoroutine(StartSpeech());
		}
	}
}
