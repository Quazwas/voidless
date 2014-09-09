using UnityEngine;
using System.Collections;

public class clientView : MonoBehaviour {
	[SerializeField]
	private GameObject serverModel;
	[SerializeField]
	private GameObject clientModel;
	void action() {
		if(Network.isClient){
			serverModel.GetComponent<MeshRenderer>().enabled=false;
			clientModel.GetComponent<MeshRenderer>().enabled=true;
		} else {
			clientModel.GetComponent<MeshRenderer>().enabled=false;
			serverModel.GetComponent<MeshRenderer>().enabled=true;
		}
	}

	void OnConnectedToServer() {
		action();
	}
	void OnServerInitialized() {
		action();
	}

}
