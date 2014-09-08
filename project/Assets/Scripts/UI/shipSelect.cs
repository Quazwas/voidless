using UnityEngine;
using System.Collections;

public class shipSelect : MonoBehaviour {
	[SerializeField]
	GameObject starfirePrefab;
	[SerializeField]
	GameObject spawnPoint;
	string currentShipName="Please Select a ship";
	public GameObject currentShip;
	void OnGUI() {
		if(!Network.isClient && !Network.isServer) {
			GUI.Label(new Rect(15,85,300,30), "Ship: "+currentShipName);
			if(GUI.Button(new Rect(15,110,300,30), "Starfire Mk I")) {
				currentShipName="Starfire Mk I";
				currentShip = starfirePrefab;
			}
		}
	}

	void OnServerInitialized() {
		GetComponent<networkManager>().spawnPlayer(currentShip, spawnPoint.transform);
	}
	void OnConnectedToServer() {
		GetComponent<networkManager>().spawnPlayer(currentShip, spawnPoint.transform);
	}
}
