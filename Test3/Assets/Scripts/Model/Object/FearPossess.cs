using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FearPossess : MonoBehaviour
{
	
	Possessable possessable;
	private bool isActive;
	private bool alreadyActivated;
	private GameObject ghost;
	public GameObject alert;
	//private Possessable possessable;
	private bool playerInBounds;
	private List<GameObject> enemyList;
	
	
	void Start()
	{
		//this.possessable = this.GetComponent<Possessable>();
		ghost = GameObject.Find("GhostController");
		this.enemyList = new List<GameObject>();
	}
	
	void Update()
	{
		//if (possessable.Possessed)
		//{
		//recieve button input from player to cause possess effect
		if(!alreadyActivated){
			if(isActive)
			{
				//+Instantiate(alert, this.transform.position, this.transform.rotation);	
				if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2) && GameObject.Find("GhostController").tag == "ActivePlayer"){
					//play animation
					Instantiate(alert, this.transform.position, this.transform.rotation);
					this.CauseFear();
					alreadyActivated=true;
				}
			}
		}
		
		//}
	}
	
	public void CauseFear()
	{
		//get enemies in radius and set them to fleeing
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 200f);
		int i = 0;
		while(i<hitColliders.Length)
		{
			if (hitColliders[i].tag == "Enemy")
			{
				hitColliders[i].SendMessage("IsFeared");
			}
			i++;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		GameObject ghost = GameObject.Find("GhostController");
		if (col.gameObject == ghost)
		{
			isActive=true;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		GameObject ghost = GameObject.Find("GhostController");
		if (col.gameObject == ghost)
		{
			isActive=false;
		}
	}
}


