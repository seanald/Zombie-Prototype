using UnityEngine;
using System.Collections;

public class HazardTurret : MonoBehaviour {

	public GameObject levelHazard;
	public Vector3 HZoffset;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider collision){

		if (collision.gameObject.tag == "Player")
		{
			Instantiate(levelHazard, collision.transform.position - HZoffset, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
