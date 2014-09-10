using UnityEngine;
using System.Collections;

public class makeShip : MonoBehaviour {
	public GameObject worldNull;
	[RPC]
	void colourShip(NetworkView netView ) {

	}
	string[] weaponConfig;
	void Start() {
		weaponConfig=GetComponent<weaponSelection>().weps;

	}

	void OnConnectedToServer() {
		call();
	}
	void OnServerInitialized() {
		call();
	}
	private void call() {
		networkView.RPC("colourShip", RPCMode.AllBuffered, networkView.viewID, worldNull.GetComponent<shipSelect>().mat);
		foreach(string wep in weaponConfig) {
			Debug.Log(wep);
		}
	}
}
