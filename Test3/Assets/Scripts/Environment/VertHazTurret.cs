using UnityEngine;
using System.Collections;

public class VertHazTurret : MonoBehaviour {
	
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
				Instantiate(levelHazard, collision.transform.position + HZoffset, transform.rotation);
				Instantiate(hzalert, collision.transform.position - alertoffset, collision.transform.rotation);
				Destroy(this.gameObject);

		}
	}
}
