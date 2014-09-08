using UnityEngine;
using System.Collections;

public class networkInterface : MonoBehaviour {
	void OnGUI() {
		if(!Network.isClient && !Network.isServer) {
			if(GUI.Button(new Rect(15,15,300,30), "Start Server")) {
				gameObject.GetComponent<networkManager>().startServer(4, 25000, false);
			}
			if(GUI.Button(new Rect(15,45,300,30), "Join Server")) {
				gameObject.GetComponent<networkManager>().joinServer("localhost", 25000, "");
			}
		}
	}
}