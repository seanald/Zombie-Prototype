using UnityEngine;
using System.Collections;

public class GhostPossess : MonoBehaviour {

	public GameObject mytarget;
	bool isPossessed;
	float targetLifeTime = 20f;
	private float startTime = 20000;
	// Use this for initialization
	void Start () {
		isPossessed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T) && isPossessed)
		{
			
			mytarget.GetComponent<BaseballWolfMovement>().movespeed = -100;
			mytarget.GetComponent<BaseballWolfMovement>().maxdistancescared = 2000;
			mytarget.GetComponent<BaseballWolfMovement>().mindistancescared = -1;
			isPossessed = false;
			startTime = Time.time;
			
		}
		if (Time.time - startTime >= targetLifeTime)
		{
			Destroy(mytarget);
		}

	}

	void OnTriggerEnter(Collider collision){
		print(collision.gameObject.tag);
		if(collision.gameObject.tag == "FearObject"){
			isPossessed=true;
		}
	}
	



}
