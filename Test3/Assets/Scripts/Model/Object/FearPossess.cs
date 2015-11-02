using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FearPossess : MonoBehaviour
{
	private Possessable possessable;
	private bool playerInBounds;
	private List<GameObject> enemyList;


	void Start()
	{
		this.possessable = this.GetComponent<Possessable>();
		this.enemyList = new List<GameObject>();
	}

	void Update()
	{
		if (possessable.Possessed)
		{
			//recieve button input from player to cause possess effect
			//play animation
			this.CauseFear();
		}
	}

	public void CauseFear()
	{
		//get enemies in radius and set them to fleeing
		//Send enemies away and have them despawn after x seconds
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.GetComponentInParent<GhostPossess>() != null)
		{
			this.playerInBounds = true;
			c.GetComponentInParent<GhostPossess>().mytarget = this;
		}

		if (c.GetComponentInParent<Enemy>() != null)
		{
			this.enemyList.Add(c.gameObject);
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (c.GetComponentInParent<GhostPossess>() != null)
		{
			this.playerInBounds = false;
			c.GetComponentInParent<GhostPossess>().mytarget = null;
		}

		if (c.GetComponentInParent<Enemy>() != null)
		{
			this.enemyList.Remove(c.gameObject);
		}
	}

	void OnTriggerStay(Collider c)
	{
		if (c.GetComponentInParent<GhostPossess>() != null)
		{
			this.playerInBounds = true;
			c.GetComponentInParent<GhostPossess>().mytarget = this;
		}
	}

	public Possessable Possessable
	{
		get {
			return possessable;
		}
	}
}
