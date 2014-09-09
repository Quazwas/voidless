using UnityEngine;
using System.Collections;

public class initAndRPC : MonoBehaviour {
	public void init(GameObject clientWorldNull) {
		Color col = clientWorldNull.GetComponent<shipSelect>().mat.color;
		Vector4 colV4 = col;
		Vector3 colV = new Vector3(colV4.x,colV4.y,colV4.z);
		GetComponent<colourChange>().setColor(colV);
		networkView.RPC("setColor", RPCMode.OthersBuffered, colV);
	}
}
