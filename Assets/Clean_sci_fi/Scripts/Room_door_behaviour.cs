using UnityEngine;
using System.Collections;

public class Room_door_behaviour : MonoBehaviour {

	public bool isLocked = false;
	public Object targetDoor;
	public ParticleSystem targetParticles;
	public AudioClip doorOpenClip;
	public AudioClip doorCloseClip;
	
	void DoDoorTrigger (bool openOrClose)
	{
		if(isLocked) {
			return;}

		Object currentTarget = targetDoor != null ? targetDoor : gameObject;
		Behaviour targetBehaviour = currentTarget as Behaviour;
		GameObject targetGameObject = currentTarget as GameObject;

		
		if (targetBehaviour != null)
		
			targetGameObject = targetBehaviour.gameObject;
			
		
		//door opening = true, closing = false
		if (openOrClose == true)
			{
				Debug.Log ("Door opening!");
				//targetGameObject.animation.Play ("Room_door_open");
				targetGameObject.animation.CrossFade ("Room_door_open");
				audio.clip = doorOpenClip;
				audio.Play ();
				if (targetParticles != null) targetParticles.Play();
			}
		else
			{
				//targetGameObject.animation.Play ("Room_door_close");
				targetGameObject.animation.CrossFade ("Room_door_close");
				audio.clip = doorCloseClip;
				audio.Play ();
				if (targetParticles != null) targetParticles.Play();
			}
		
	}

	void OnTriggerEnter (Collider other) {
		DoDoorTrigger (true);
	}
	
	void OnTriggerExit (Collider other) {
		DoDoorTrigger (false);
	}
}
