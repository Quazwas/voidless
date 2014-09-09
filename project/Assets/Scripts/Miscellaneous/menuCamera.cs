using UnityEngine;
using System.Collections;

public class menuCamera : MonoBehaviour {
	void Update () {
		if(Network.isServer || Network.isClient) {
			camera.enabled=false;
		}
	}
}
