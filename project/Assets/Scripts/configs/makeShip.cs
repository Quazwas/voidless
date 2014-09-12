using UnityEngine;
using System.Collections;

public class makeShip : MonoBehaviour {
	public GameObject worldNull;
	int[] wepLocs;
	void Awake() {
		worldNull = GameObject.Find("worldNull");
	}
	[RPC]
	void addWeapon(int nodeID, int wepID) {
		//Debug.Log(wepID.ToString()+nodeID.ToString());
		GameObject clone;
		GameObject[] nodes = GetComponent<shipProperties>().nodes;
		Debug.Log(worldNull.GetComponent<wepProperties>().weapons.Length.ToString());
		clone = Instantiate(worldNull.GetComponent<wepProperties>().weapons[wepID].objPrefab, nodes[nodeID].transform.position, nodes[nodeID].transform.rotation) as GameObject;
		clone.transform.parent=nodes[nodeID].transform;
	}

	[RPC]
	void setColor(Vector3 colVector) {
		Color col = new Color(colVector.x,colVector.y,colVector.z);
		foreach(Transform child in this.transform) {
			child.renderer.material.color=col;
		}
	}

/*	public void addWepLoc(int wepLoc) {
		List<int> wepLocList = wepLocs.ToList();
		wepLocList.Add(wepLoc);
		wepLocs = wepLocList.ToArray();
	}*/
	//wepLoc
	public void call() {
		int[] wepLocs=worldNull.GetComponent<weaponSelection>().wepLocs;
		Debug.Log(wepLocs.Length);
		for(int i = 0; i<wepLocs.Length; i++) {
			networkView.RPC("addWeapon", RPCMode.AllBuffered, i, wepLocs[i]);
		}

		Color col = worldNull.GetComponent<shipSelect>().mat.color;
		Vector3 colV = new Vector3(col.r,col.g,col.b);
		networkView.RPC("setColor", RPCMode.AllBuffered, colV);
	}
}
