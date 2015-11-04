﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FearPossess : MonoBehaviour
{
	Possessable possessable;
	private bool isActive;
	private GameObject ghost;
	public GameObject alert;
	private bool playerInBounds;
	private List<GameObject> enemyList;

	void Start()
	{
		this.possessable = this.GetComponent<Possessable>();
		ghost = GameObject.Find("GhostController");
		this.enemyList = new List<GameObject>();
	}

	void Update()
	{
		//if (possessable.Possessed)
		//{
			//recieve button input from player to cause possess effect
		if(ghost.transform.position.magnitude - this.transform.position.magnitude < 20)
			{
				//+Instantiate(alert, this.transform.position, this.transform.rotation);	
				if(Input.GetKeyDown(KeyCode.P)){
					//play animation
					Instantiate(alert, this.transform.position, this.transform.rotation);
					this.CauseFear();
					isActive=true;
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
			if (hitColliders[i].tag == "EnemyScared")
			{
				hitColliders[i].SendMessage("IsFeared");
			}
			i++;
		}
	}

	public Possessable Possessable
	{
		get {
			return possessable;
		}
		set {
			possessable = value;
		}
	}
}
