using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Collider))]
public class GeneInfo : MonoBehaviour {
		
	private readonly string TAG = "ActorApple";

	public int initialCurrentAge = 3;
	public int initialMaxAge = 10;

	ActorInfo info;

	void Awake() {
		Transform tInfo = transform.FindChild("Info");
		if(tInfo == null || tInfo.GetComponent<ActorInfo>() == null) {
			Object oClonerInfo = Resources.Load("Info", typeof(GameObject));
			
			GameObject goInfo = GameObject.Instantiate(oClonerInfo) as GameObject;
			goInfo.transform.parent = transform;
			goInfo.transform.localPosition = new Vector3(0, 3.04f, 0);
			info = goInfo.GetComponent<ActorInfo>();
		}
		else {
			info = tInfo.GetComponent<ActorInfo>();
		}
	}

	void ArcReactorHit() {
		info.ArcReactorHit();
	}
}
