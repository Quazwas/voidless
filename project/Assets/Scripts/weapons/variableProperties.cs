using UnityEngine;
using System.Collections;

public class variableProperties : MonoBehaviour {
	[SerializeField]
	float hull = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void damage(float dmg) {
		hull-=dmg;
		Debug.Log(hull);
	}
}
