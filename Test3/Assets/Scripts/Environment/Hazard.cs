using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	float Speed = 50f;
	float HazardLifeTime = 5f;
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position += Speed * this.gameObject.transform.right;
		
		if (Time.time - startTime >= HazardLifeTime)
		{
			Destroy(this.gameObject);
		}
	}


}
