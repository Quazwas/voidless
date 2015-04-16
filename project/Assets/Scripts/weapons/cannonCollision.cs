using UnityEngine;
using System.Collections;

public class cannonCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag=="Player") {
			Debug.Log("Hit Player");
			//networkView.RPC("damage", RPCMode.Server, gameObject.GetComponent<projProperties>().damage);
			collision.gameObject.GetComponent<variableProperties>().damage(gameObject.GetComponent<projProperties>().damage);
		}
	}
}
