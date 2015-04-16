using UnityEngine;
using System.Collections;

public class homingMissile : MonoBehaviour {
	/*GameObject[] ships;
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
		Vector3 direction = new Vector3(cShip.transform.position.x-this.transform.position.x,cShip.transform.position.y-this.transform.position.y,cShip.transform.position.z-this.transform.position.z);
		Debug.Log(direction.x);
		direction = direction.normalized;
		rigidbody.AddForce(direction*5000);
	}*/
}
