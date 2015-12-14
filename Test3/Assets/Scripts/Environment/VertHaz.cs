using UnityEngine;
using System.Collections;

public class VertHaz : MonoBehaviour {
	
	float Speed = 10f;
	float HazardLifeTime = 10f;
	private float startTime;
	AudioSource strongAttack;
	public string traveldirection;
	public GameObject explosion;
	
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
		Instantiate(explosion, collision.transform.position, transform.rotation);
		Destroy(this.gameObject);
		
	}
}
