using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteGuidanceUI : MonoBehaviour {

	Text textMessage;

	public string Text
	{
		get { return textMessage.text; }
		set { textMessage.text = value; }
	}

	void Awake() {
		textMessage = transform.FindChild("Panel/Message").GetComponent<Text>();
	}
}
