using UnityEngine;
using System.Collections;

public class weaponCannons : MonoBehaviour {
	[SerializeField]
	public GameObject ship;
	[SerializeField]
	GameObject projectile;
	public float velocity;
	[SerializeField]
	GameObject muzzle;
	// Update is called once per frame
	void Start() {
		ship=transform.parent.transform.parent.gameObject;
	}
	void Update () {
		if(Network.isClient || Network.isServer) {
			if(ship.networkView.isMine) {
				if(Input.GetButtonDown("secondary")) {
					Debug.Log("Secondary");
					GameObject clone;
					clone = Network.Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation, 0) as GameObject;
					clone.rigidbody.velocity=ship.rigidbody.velocity;
					clone.rigidbody.AddForce(muzzle.transform.forward*velocity);
				}
			}
		}
	}
}
