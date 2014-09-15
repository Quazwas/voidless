
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class weaponSelection : MonoBehaviour {
	[SerializeField]
	public GameObject ship;
	[SerializeField]
	public GameObject weaponObject;
	int length;
	int[] nodeTypes;
	GameObject[] nodes;
	public int[] wepLocs = new int[4];
	int wepAmnt;
	[SerializeField]
	GameObject highlightObject;
	GameObject highlight;
	GameObject[] tempWeps;
	public void init() {
		wepLocs = new int[ship.GetComponent<shipProperties>().nodes.Length];
		tempWeps = new GameObject[ship.GetComponent<shipProperties>().nodes.Length];
		//Debug.Log(ship.GetComponent<shipProperties>().nodes.Length);
		nodes = ship.GetComponent<shipProperties>().nodes;
		nodeTypes = ship.GetComponent<shipProperties>().nodeTypes;
		length=nodes.Length;
		wepAmnt =  GetComponent<wepProperties>().weapons.Length;
	}
	bool bNodeSelected;
	int selNode;
	int selNodeType;
	void OnGUI() {
		if(!Network.isClient && !Network.isServer) {
			if(!bNodeSelected) {
				for(int i=0; i<length; i++) {
					if(GUI.Button(new Rect(10, 300+i*30, 200, 30), "Node: "+i.ToString()+"  Type: "+nodeTypes[i].ToString())) {
						selNode=i;
						selNodeType=nodeTypes[i];
						bNodeSelected=true;
						
						highlight = Instantiate(highlightObject, nodes[i].transform.position, nodes[i].transform.rotation) as GameObject;
					}
				}
			} else {
				for(int i=0; i<wepAmnt; i++) {
					if(weaponObject.GetComponent<wepProperties>().weapons[i].nodeType == selNodeType) {
						if(GUI.Button(new Rect(10, 300+i*30, 200, 30),  GetComponent<wepProperties>().weapons[i].name)){
							wepLocs[selNode]=i;
							updateNodes(selNode, i);
							bNodeSelected=false;
							Destroy(highlight);
						}
					}
				}
			}
			/*for(int i =0; i<wepLocs.Length; i++) {
				GUI.Label(new Rect(15, 500+i*30,300,30), wepLocs[i].ToString());
			}*/
		}
	}

	void updateNodes(int node, int wepID) {
		weapon wepCom = GetComponent<wepProperties>().weapons[wepID];
		//for(int wi=0; wi<wepCom.Length; wi++) {
			//print(wepCom[wi].id);
			//if(wepCom[wi].id==wepID) {
				for(int i =0; i<nodes.Length; i++) {
					if(i==node) {
						Destroy(tempWeps[i]);
						tempWeps[i] = Instantiate(wepCom.objPrefab, nodes[i].transform.position, nodes[i].transform.rotation) as GameObject;
						tempWeps[i].transform.parent=nodes[i].transform;
					}
				}
			//}
		//}
	}

	void OnConnectedToServer() {
		action();
	}
	void OnServerInitialized() {
		action();
	}
	void action() {
/*		for(int i =0; i<nodes.Length; i++) {
			if(i==node) {
				Instantiate(wepCom.objPrefab, nodes[i].transform.position, nodes[i].transform.rotation);
			}
		}*/
	}

}
