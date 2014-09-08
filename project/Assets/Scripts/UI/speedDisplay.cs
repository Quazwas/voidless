using UnityEngine;
using System.Collections;

public class speedDisplay : MonoBehaviour {
	void OnGUI() {
		if(Network.isClient || Network.isServer) {
			GUI.Label(new Rect(15,15,300,30), rigidbody.velocity.magnitude.ToString());
		}
	}
}
