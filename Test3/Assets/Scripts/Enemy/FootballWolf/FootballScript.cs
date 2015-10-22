using UnityEngine;
using System.Collections;

public class FootballScript : MonoBehaviour
{

	float Speed = 15f;
	float BulletLifeTime = 1f;
	private float startTime;
	
	
	// Use this for initialization
	void Start()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update()
	{
		this.gameObject.transform.position += Speed * this.gameObject.transform.right;
		
		if (Time.time - startTime >= BulletLifeTime)
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "ActivePlayer")
		{

			collision.gameObject.GetComponent<Health>().CurHealth = collision.gameObject.GetComponent<Health>().CurHealth - 50;
			Destroy(this.gameObject);
		}

	}
}
