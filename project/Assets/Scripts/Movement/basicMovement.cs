using UnityEngine;
using System.Collections;

public class basicMovement : MonoBehaviour {
	[SerializeField]
	float thrustSpeed;
	[SerializeField]
	float yawSpeed;
	[SerializeField]
	float rollSpeed;
	[SerializeField]
	float pitchSpeed;
	[SerializeField]
	float strafeSpeed;
	[SerializeField]
	float posDamp;
	[SerializeField]
	float rotDamp;
	// Update is called once per frame
	void Update () {
		if(networkView.isMine){
			rigidbody.AddTorque(transform.forward*rollSpeed*Input.GetAxis("Roll"));
			rigidbody.AddTorque(transform.up*yawSpeed*Input.GetAxis("Yaw"));
			rigidbody.AddTorque(transform.right*pitchSpeed*Input.GetAxis("Pitch"));
			rigidbody.AddForce(transform.forward*thrustSpeed*Input.GetAxis("Thrust"));
			Vector3 posV;
			posV=rigidbody.velocity;
			posV.x*=posDamp;
			posV.y*=posDamp;
			posV.z*=posDamp;
			rigidbody.velocity=posV;
			Vector3 rotV;
			rotV=rigidbody.angularVelocity;
			rotV.x*=rotDamp;
			rotV.y*=rotDamp;
			rotV.z*=rotDamp;
			rigidbody.angularVelocity=rotV;
		}
	}
}
