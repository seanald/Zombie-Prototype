using UnityEngine;
using System.Collections;

public class GhostBulletScript : MonoBehaviour {

	float Speed = .4f;
	float BulletLifeTime = 10f;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position += Speed * this.gameObject.transform.right;

		if (Time.time - startTime >= BulletLifeTime)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		Destroy(this.gameObject);
	}
}
