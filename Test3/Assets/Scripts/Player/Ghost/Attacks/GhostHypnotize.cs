﻿using UnityEngine;
using System.Collections;

public class GhostHypnotize : MonoBehaviour {

	private GameObject mytarget;
	private const int maxdistance = 10;
	public GameObject Bullet;
	public Vector3 GBoffset;

	void Fire() {
		Instantiate(Bullet, transform.position + GBoffset, transform.rotation);
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.X) /*&& this.GetComponentInParent<PlasmaController>().CurPlasma > 0*/)
		{
			Fire();
			/*this.mytarget = this.findClosestEnemy();
			this.mytarget.GetComponentInChildren<EnemyController>().WalkSpeed = -3;
			LineRenderer lineRenderer = this.GetComponentInChildren<LineRenderer>();
			lineRenderer.SetPosition(0, this.transform.position);
			lineRenderer.SetPosition(1, this.mytarget.transform.position);*/
			this.GetComponentInParent<PlasmaController>().CurPlasma--;
		}
	}

	/*private GameObject findClosestEnemy()
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
	}*/
}
