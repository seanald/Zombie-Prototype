using UnityEngine;
using System.Collections;

public class FearObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 400f);
		int i = 0;
		while (i<hitColliders.Length){
			if(hitColliders[i].tag == "Enemy"){
				hitColliders[i].SendMessage("IsFeared");
			}
			i++;
		}
	}
}
