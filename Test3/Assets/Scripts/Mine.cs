using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision){
		if(collision.gameObject==GameObject.Find("ZombieController"))
		{
			Instantiate(explosion, this.transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
		
	}
}
