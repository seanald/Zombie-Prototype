using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	float Speed = 10f;
	float HazardLifeTime = 10f;
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
	void OnTriggerEnter(Collider collision){
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "ActivePlayer"){
			
			collision.gameObject.GetComponent<Health>().CurHealth = collision.gameObject.GetComponent<Health>().CurHealth - 100;

		}
		
	}
}
