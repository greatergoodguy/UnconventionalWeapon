using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteGuidanceUI : MonoBehaviour {

	Text textMessage;

	void Awake() {
		textMessage = transform.FindChild("Panel/Message").GetComponent<Text>();
	}

	public void SetText(string text) {
		textMessage.text = text;
	}
}
