using UnityEngine;
using System.Collections;

public class clientView : MonoBehaviour {
	[SerializeField]
	private GameObject serverModel;
	[SerializeField]
	private GameObject clientModel;
	MeshRenderer serverRenderer;
	MeshRenderer clientRenderer;
	[RPC]
	void action() {
		//if(networkView.isMine){
			//serverRenderer.enabled=false;
			//clientRenderer.enabled=true;
			//Debug.Log("isMine!");
		//} else {
			//clientRenderer.enabled=false;
			//serverRenderer.enabled=true;
		//}
	}
	NetworkViewID viewID;
	public void init() {
		clientRenderer=clientModel.GetComponent<MeshRenderer>();
		serverRenderer=serverModel.GetComponent<MeshRenderer>();
		//clientRenderer.enabled=false;
		//serverRenderer.enabled=true;
	}
	void OnConnectedToServer() {
		action();
		/*networkView.RPC("action", RPCMode.OthersBuffered);*/
	}
	void OnServerInitialized() {
		action();
		/*networkView.RPC("action", RPCMode.OthersBuffered);*/
	}

}
