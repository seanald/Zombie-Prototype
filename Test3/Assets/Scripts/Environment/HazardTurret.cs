using UnityEngine;
using System.Collections;

public class HazardTurret : MonoBehaviour {

	public GameObject levelHazard;
	public GameObject hzalert;
	public Vector3 HZoffset;
	public Vector3 alertoffset;
	public string direction;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider collision){

		if (collision.gameObject.tag == "Player")
		{
			if(direction == "right"){
				Instantiate(levelHazard, collision.transform.position - HZoffset, transform.rotation);
				levelHazard.GetComponent<Hazard>().traveldirection = "right";
				Instantiate(hzalert, collision.transform.position - alertoffset, collision.transform.rotation);
				Destroy(this.gameObject);
			}
			if(direction == "left"){
				Instantiate(levelHazard, collision.transform.position + HZoffset, transform.rotation);
				levelHazard.GetComponent<Hazard>().traveldirection = "left";
				Instantiate(hzalert, collision.transform.position - alertoffset, collision.transform.rotation);
				Destroy(this.gameObject);
			}
		}
	}
}
