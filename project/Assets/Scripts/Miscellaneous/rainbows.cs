using UnityEngine;
using System.Collections;

public class rainbows : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Color randCol = new Color(Random.Range (0.1f,1), Random.Range (0.1f,1), Random.Range (0.1f,1), 1);
		GetComponent<MeshRenderer>().material.color=randCol;
		GetComponent<TrailRenderer>().material.color=randCol;
	}
}
