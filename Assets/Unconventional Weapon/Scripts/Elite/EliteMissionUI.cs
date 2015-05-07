using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EliteMissionUI : MonoBehaviour {

	Text textMessage;

	Transform tPanel;

	public string Text
	{
		get { return textMessage.text; }
		set { textMessage.text = value; }
	}

	void Awake() {
		textMessage = transform.FindChild("Panel/Message").GetComponent<Text>();
		tPanel = transform.FindChild("Panel");
	}

	void Start() {
		Hide ();
	}

	public void Show() {
		tPanel.gameObject.SetActive(true);
	}

	public void Hide() {
		tPanel.gameObject.SetActive(false);
	}
}
