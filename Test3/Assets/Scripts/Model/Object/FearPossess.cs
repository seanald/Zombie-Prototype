using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FearPossess : MonoBehaviour
{
<<<<<<< HEAD
	Possessable possessable;
	private bool isActive;
	private GameObject ghost;
	public GameObject alert;
=======
	private Possessable possessable;
	private bool playerInBounds;
	private List<GameObject> enemyList;

>>>>>>> eedf7919af15adbf79bf7521836ecdf6e28fd8a2

	void Start()
	{
		this.possessable = this.GetComponent<Possessable>();
<<<<<<< HEAD
		ghost = GameObject.Find("GhostController");
=======
		this.enemyList = new List<GameObject>();
>>>>>>> eedf7919af15adbf79bf7521836ecdf6e28fd8a2
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
}
