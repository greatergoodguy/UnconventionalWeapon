using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActorHPChunk : MonoBehaviour {

	private readonly string TAG = "ActorHPChunk";

	Transform tAge;
	Transform tCapacity;
	Transform tLost;

	void Awake() {

		UtilLogger.Log(TAG, "Awake()");
		RectTransform rt = GetComponent<RectTransform>();

		tAge = transform.FindChild("Age");
		tCapacity = transform.FindChild("Capacity");
		tLost = transform.FindChild("Lost");

		EnableCapacity();
	}

	public void EnableAge() {
		tAge.gameObject.SetActive(true);
		tCapacity.gameObject.SetActive(false);
		tLost.gameObject.SetActive(false);
	}

	public void EnableCapacity() {
		tAge.gameObject.SetActive(false);
		tCapacity.gameObject.SetActive(true);
		tLost.gameObject.SetActive(false);
	}

	public void EnableLost() {
		tAge.gameObject.SetActive(false);
		tCapacity.gameObject.SetActive(false);
		tLost.gameObject.SetActive(true);
	}

	public void Disable() {
		tAge.gameObject.SetActive(false);
		tCapacity.gameObject.SetActive(false);
		tLost.gameObject.SetActive(false);
	}
}
