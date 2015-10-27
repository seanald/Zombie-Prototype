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
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
			|| (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null))
		{
			Vector3 distVec = (other.transform.position - transform.position);
			this.batwolf.Seek(distVec * -1, true);
			print("working");
		}
	}

	void OnTriggerStay(Collider other)
	{
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
			|| (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null))
		{
			Vector3 distVec = (other.transform.position - transform.position);
			this.batwolf.Seek(distVec * -1, true);
			print("working");
		}
	}
}
