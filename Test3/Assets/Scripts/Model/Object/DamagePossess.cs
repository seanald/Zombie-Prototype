﻿using UnityEngine;
using System.Collections;

public class DamagePossess : MonoBehaviour {
	
	Possessable possessable;
	private bool isActive;
	private GameObject ghost;
	public GameObject alert;
	private bool alreadyActivated;
	
	void Start()
	{
		this.possessable = this.GetComponent<Possessable>();
		ghost = GameObject.Find("GhostController");
		alreadyActivated = false;
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
				if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)){
					//play animation
					//Instantiate(alert, this.transform.position, this.transform.rotation);
					this.CauseDamage();
					alreadyActivated=true;
				}
			}
		}
		
		//}
	}
	
	public void CauseDamage()
	{
		//get enemies in radius and set them to fleeing
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 200f);
		int i = 0;
		while(i<hitColliders.Length)
		{
			if (hitColliders[i].tag == "Enemy" || hitColliders[i].tag == "EnemyScared")
			{
				hitColliders[i].SendMessage("TakeDamage");
			}
			i++;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		
		GameObject ghost = GameObject.Find("GhostController");
		
		if (col.gameObject == ghost)
		{
			isActive = true;
			if(!alreadyActivated){
				Instantiate(alert, this.transform.position, this.transform.rotation);
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		GameObject ghost = GameObject.Find("GhostController");
		if (col.gameObject == ghost)
		{
			isActive = false;
		}
	}
}


