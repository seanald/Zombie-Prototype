using UnityEngine;
using System.Collections;

public class VertHaz : MonoBehaviour {
	
	float Speed = 10f;
	float HazardLifeTime = 10f;
	private float startTime;
	AudioSource strongAttack;
	public string traveldirection;
	
	void Awake()
	{
		strongAttack = GetComponent<AudioSource>();
	}
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

			this.gameObject.transform.position += Speed * this.gameObject.transform.up * -1;
		

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
