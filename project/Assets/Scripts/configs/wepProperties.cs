using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class wepProperties : MonoBehaviour {

	public GameObject[] prefabs;

	public List<weapon> weaponList =  new List<weapon>();
	public weapon[] weapons;
	weapon wep;
	void Awake() {
		wep = new weapon();
		wep.objPrefab = prefabs[0];
		wep.name = "Dual Rocket";
		wep.damage = 9001;
		wep.type="rocket";
		wep.velocity=5;
		wep.accuracy=100;
		wep.nodeType=1;
		wep.id=0;
		weaponList.Add(wep);

		wep = new weapon();
		wep.objPrefab = prefabs[1];
		wep.name = "SwagCannon";
		wep.damage = 9001;
		wep.type="rocket";
		wep.velocity=5;
		wep.accuracy=100;
		wep.nodeType=1;
		wep.id=1;
		weaponList.Add(wep);

		wep = new weapon();
		wep.objPrefab = prefabs[2];
		wep.name = "yoloCannon";
		wep.damage = 9001;
		wep.type="rocket";
		wep.velocity=5;
		wep.accuracy=100;
		wep.nodeType=1;
		wep.id=2;
		weaponList.Add(wep);

		weapons = weaponList.ToArray();
	}

}
 public class weapon{
 	public GameObject objPrefab;
 	public float damage;
 	public string type;
 	public float velocity;
 	public float accuracy;
 	public float nodeType;
 	public string name;
 	public int id;
 }