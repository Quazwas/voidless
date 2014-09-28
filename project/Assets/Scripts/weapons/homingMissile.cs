using UnityEngine;
using System.Collections;

public class homingMissile : MonoBehaviour {
	GameObject[] ships;
	void Start() {
		ships = GameObject.FindGameObjectsWithTag("Player");
	}
	void Update () {
		float cDist=0;
		GameObject cShip=this.gameObject;
		foreach(GameObject ship in ships) {
			if(!networkView.isMine)	{
				if(Vector3.Distance(ship.transform.position,this.transform.position)<cDist) {
					cDist=Vector3.Distance(ship.transform.position,this.transform.position);
					cShip=ship;
				}
			}
		}
		Vector3 direction = cShip.transform.position-this.transform.position;
		Debug.Log(direction.x);
		direction = direction.normalized;
		rigidbody.AddForce(direction*5000);
	}
}
