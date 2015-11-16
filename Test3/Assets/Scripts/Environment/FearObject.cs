﻿using UnityEngine;
using System.Collections;

public class FearObject : MonoBehaviour {
	private bool isActive;
	private GameObject ghost;
	// Use this for initialization
	void Start () {
		isActive = false;
		ghost = GameObject.Find("GhostController");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2))
		{
			if(ghost.transform.position.magnitude - this.transform.position.magnitude < 20){
				isActive = true;
			}
		}
		if (isActive==true)
		{
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
		print(isActive);
	}



}
