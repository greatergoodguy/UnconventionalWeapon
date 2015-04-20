using UnityEngine;
using System.Collections;

public class ActorStartMenu : MonoBehaviour {

	Transform tPanel;

	void Awake() {
		tPanel = transform.FindChild("Panel");
	}

	void Start () {
		God.Hero.Freeze();
	}

	public void OnButtonStart() {
		God.Hero.UnFreeze();
		tPanel.gameObject.SetActive(false);
	}
}
