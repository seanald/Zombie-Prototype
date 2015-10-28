using UnityEngine;
using System.Collections;

public class FearPossess : MonoBehaviour
{
	Possessable possessable;

	void Start()
	{
		this.possessable = this.GetComponent<Possessable>();
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
}
