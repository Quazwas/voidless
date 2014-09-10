using UnityEngine;
using System.Collections;

public class networkManager : MonoBehaviour {
	//Starts Server
	public void startServer(int maxConnect, int port, bool bLAN) {
		Network.InitializeServer(maxConnect, port, bLAN);
	}
	//Joins Server
	public void joinServer(string ip, int port, string pass) {
		Network.Connect(ip, port, pass);
	}
	public GameObject playerClone;
	public void spawnPlayer(GameObject player, Transform spawnPoint) {	
		playerClone = Network.Instantiate(player, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
	}
	void OnServerInitialized(){
		Debug.Log("Server Initialized.");
	}
	void OnConnectedToServer(){
		Debug.Log("Connected to Server");
	}
	void OnPlayerDisconnected(NetworkPlayer player) {
			if(Network.isServer){
				Network.RemoveRPCs(player);
				Network.DestroyPlayerObjects(player);
		}
	}
}
