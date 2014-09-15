using UnityEngine;
using System.Collections;

public class weaponPhasers : MonoBehaviour {
	[SerializeField]
	GameObject muzzle;
	[SerializeField]
	GameObject phaseNull;
	[SerializeField]
	public GameObject ship;
	bool nextFrameShift=false;
	//Ray prevRay;
	GameObject prevClone;
	//RaycastHit prevHit;
	void Start() {
		ship=transform.parent.transform.parent.gameObject;
	}
	void Update () {
		if(nextFrameShift) {
			RaycastHit hit;
			Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
			if(collider.Raycast(ray, out hit, 100.0F)) {
				prevClone.transform.position = hit.transform.position;
			} else {
				prevClone.transform.position+=muzzle.transform.forward*100;
			}
			nextFrameShift=false;
		}
		if(Network.isClient || Network.isServer) {
			if(ship.networkView.isMine) {
				if(Input.GetButtonDown("primary")) {
					//Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
					//RaycastHit hit;
					GameObject clone;
					clone = Network.Instantiate(phaseNull, muzzle.transform.position, muzzle.transform.rotation, 0) as GameObject;
					nextFrameShift=true;
					prevClone=clone;
					//prevRay=ray;
					//prevHit=hit;
				}
			}
		}
	}
}
