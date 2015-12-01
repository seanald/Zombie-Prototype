using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

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
		if(traveldirection == "left"){
			this.gameObject.transform.position += Speed * this.gameObject.transform.right;
		}
		if(traveldirection == "right"){
			this.gameObject.transform.position += Speed * this.gameObject.transform.right * -1;
		}
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
