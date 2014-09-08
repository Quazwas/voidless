using UnityEngine;
using System.Collections;

public class makeClientOnly : MonoBehaviour {
	[SerializeField]
	GameObject networkedObject;
	void Start () {
		if(!networkedObject.networkView.isMine) {
			this.enabled=false;
			camera.enabled=false;
		}
	}
}
