using UnityEngine;
using System.Collections;

public class Avoid : MonoBehaviour
{
	BaseballWolfMovement batwolf;
	// Use this for initialization
	void Start()
	{
		this.batwolf = this.GetComponentInParent<BaseballWolfMovement>();
	}

	void OnTriggerEnter(Collider other)
	{
		Vector3 distVec = (other.transform.position - transform.position);
		this.batwolf.Seek(distVec * -1, false);
	}
}
