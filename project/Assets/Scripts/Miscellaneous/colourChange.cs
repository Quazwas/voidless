using UnityEngine;
using System.Collections;

public class colourChange : MonoBehaviour {

	[RPC]
	public void setColor(Vector3 colV) {
		Renderer[] rens=gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer ren in rens) {
			ren.material.color=new Vector4(colV.x, colV.y,colV.z,1);
		}
	}
}
