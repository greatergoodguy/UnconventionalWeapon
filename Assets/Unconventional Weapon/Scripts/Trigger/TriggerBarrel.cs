using UnityEngine;
using System.Collections;

public class TriggerBarrel : MonoBehaviour {

	public readonly string TAG = "TriggerBarrel";

	public string message = "";

	void OnTriggerEnter(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerEnter()");
		God.MissionUI.Text = message;
		God.MissionUI.Show();
	}
	
	void OnTriggerExit(Collider other) {
		UtilLogger.Log(TAG, "OnTriggerExit()");
		God.MissionUI.Hide();
		God.GuidanceUI.Text = "";
	}
}
