using UnityEngine;
using System.Collections;

public class shipSelect : MonoBehaviour {
	[SerializeField]
	GameObject starfirePrefab;
	[SerializeField]
	GameObject spawnPoint;
	string currentShipName="Please Select a ship";
	public GameObject currentShip;
	public GameObject confShip;
	public Material mat;
	public weaponSelection wepComp;
	void Start() {
		confShip = Instantiate(currentShip, new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;
		wepComp=GetComponent<weaponSelection>();
		wepComp.ship=confShip;
		wepComp.init();
		confShip.GetComponent<clientView>().init();
		mat=GameObject.Find("starFireMk1_v001/Cube").GetComponent<MeshRenderer>().material;
	}

	void updateShip() {
		//Destroy(confShip);
		confShip = Instantiate(currentShip, new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;
		wepComp.ship=confShip;
		mat=GameObject.Find("starFireMk1_v001/Cube").GetComponent<MeshRenderer>().material;
	}

	void changeColour(Color color) {
		mat.color=color;
	}

	int menuLocation;

	void OnGUI() {
		if(!Network.isClient && !Network.isServer) {
			GUI.Label(new Rect(15,85,300,30), "Ship: "+currentShipName);
			if(GUI.Button(new Rect(15,110,300,30), "Starfire Mk I")) {
				currentShipName = "Starfire Mk I";
				currentShip = starfirePrefab;
				updateShip();
			}

			if(GUI.Button(new Rect(320,110,300,30), "Change Colour")) {
				if(menuLocation==2){
					menuLocation=0;
				}else{
					menuLocation=2;
				}
			}
			if(menuLocation==2) {
				if(GUI.Button(new Rect(320,145,300,30), "Set Red")) {
					Color col = Color.red;
					changeColour(col);
				}
				if(GUI.Button(new Rect(320,180,300,30), "Set Blue")) {
					Color col = Color.blue;
					changeColour(col);
				}
				if(GUI.Button(new Rect(320,215,300,30), "Set Green")) {
					Color col = Color.green;
					changeColour(col);
				}
				if(GUI.Button(new Rect(320,250,300,30), "Set White")) {
					Color col = Color.white;
					changeColour(col);
				}
				if(GUI.Button(new Rect(320,285,300,30), "Set Imposter Purple")) {
					Color col = Color.magenta;
					changeColour(col);
				}
			}

		}
	}

	void OnServerInitialized() {
		Destroy(confShip);
		GetComponent<networkManager>().spawnPlayer(currentShip, spawnPoint.transform);
	}
	void OnConnectedToServer() {
		Destroy(confShip);
		GetComponent<networkManager>().spawnPlayer(currentShip, spawnPoint.transform);
	}
}