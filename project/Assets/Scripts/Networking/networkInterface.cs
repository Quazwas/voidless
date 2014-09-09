using UnityEngine;
using System.Collections;

public class networkInterface : MonoBehaviour {
	string ip="";
	int port = 25000;
	void OnGUI() {
		if(!Network.isClient && !Network.isServer) {
			if(GUI.Button(new Rect(15,15,300,30), "Start Server")) {
				gameObject.GetComponent<networkManager>().startServer(4, port, false);
			}
			if(GUI.Button(new Rect(15,45,300,30), "Join Server")) {
				gameObject.GetComponent<networkManager>().joinServer(ip, port, "");
			}
			GUI.Label(new Rect(325,50,30,30), "IP: ");
			ip = GUI.TextField(new Rect(355,50,100,20), ip,100);
		}
	}
}