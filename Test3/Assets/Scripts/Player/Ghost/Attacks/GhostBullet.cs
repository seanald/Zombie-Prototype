using UnityEngine;
using System.Collections;

public class GhostBullet : MonoBehaviour {

	float Speed = 25f;
	float BulletLifeTime = 1f;
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
