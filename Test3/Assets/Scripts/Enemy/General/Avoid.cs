using UnityEngine;
using System.Collections;

public class Avoid : MonoBehaviour
{
	Enemy enemy;
	// Use this for initialization
	void Start()
	{
		this.enemy = this.GetComponentInParent<Enemy>();
	}

	void OnTriggerEnter(Collider other)
	{
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
		    || (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null) || (this.gameObject.tag.Equals("EnemyScared") && other.GetComponentInParent<Enemy>() == null))
		{
			Vector3 distVec = (other.transform.position - transform.position);
			print("working");
		}
	}

	void OnTriggerStay(Collider other)
	{
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
		    || (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null) || (this.gameObject.tag.Equals("EnemyScared") && other.GetComponentInParent<Enemy>() == null))
		{
			Vector3 distVec = (other.transform.position - transform.position);
			print("working");
		}
	}
}
