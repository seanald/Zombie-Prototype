using UnityEngine;
using System.Collections;

public class GhostBullet : MonoBehaviour {

	private GameObject mytarget;
	public const int maxdistance = 10;
	
	void Update () 
	{
		if (GetComponent<Movement>().isActivePlayer)
		{
			if (Input.GetKey(KeyCode.X))
			{
				this.findClosestEnemy().GetComponentInChildren<Enemy>().moveSpeed = -3;
			}
		}
	}
	private GameObject findClosestEnemy()
	{
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;

		foreach (GameObject enemy in enemies) 
		{
			Vector3 diff = enemy.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) 
			{
				closest = enemy;
				distance = curDistance;
			}
		}
		return closest;
	}
}
