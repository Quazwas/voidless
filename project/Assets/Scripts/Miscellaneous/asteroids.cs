using UnityEngine;
using System.Collections;

public class asteroids : MonoBehaviour {
	[SerializeField]
	GameObject asteroid;
	[SerializeField]
	float radius;
	[SerializeField]
	float density;
	[SerializeField]
	float lowerSizeLimit;
	[SerializeField]
	float upperSizeLimit;
	void OnServerInitialized() {
		for(int i = 0; i<(int)radius*density;i++) {
			GameObject asteroidClone;
			asteroidClone = Network.Instantiate(asteroid, new Vector3(Random.Range (-radius, radius), Random.Range (-radius, radius), Random.Range (-radius, radius)), new Quaternion(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)), 0) as GameObject;
			asteroidClone.transform.localScale = new Vector3(Random.Range(lowerSizeLimit,upperSizeLimit),Random.Range(lowerSizeLimit,upperSizeLimit),Random.Range(lowerSizeLimit,upperSizeLimit));
		}
	}
}
