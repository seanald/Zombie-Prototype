using UnityEngine;
using System.Collections;

public class GhostHypnotize : MonoBehaviour {

	private GameObject mytarget;
	private const int maxdistance = 10;
	public GameObject Bullet;
	public Vector3 GBoffset;

<<<<<<< HEAD
	void Fire() {
		Instantiate(Bullet, transform.position + GBoffset, transform.rotation);
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.X) /*&& this.GetComponentInParent<PlasmaController>().CurPlasma > 0*/)
=======
	void Fire(){
		Instantiate(Bullet, transform.position + GBoffset, transform.rotation);
	}
	
	void Update () 
	{

		if(Mathf.Round(Time.time)%7 ==0){
			if(this.GetComponentInParent<GhostModel>().plasma<5){
				this.GetComponentInParent<GhostModel>().plasma++;
			}
		}
		if (Input.GetKeyDown(KeyCode.X) && this.GetComponentInParent<GhostModel>().plasma > 0)
>>>>>>> cf688b337a2ddfa0cda8daa140619680d9fa8747
		{
			Fire();
			/*this.mytarget = this.findClosestEnemy();
			this.mytarget.GetComponentInChildren<EnemyController>().WalkSpeed = -3;
			LineRenderer lineRenderer = this.GetComponentInChildren<LineRenderer>();
			lineRenderer.SetPosition(0, this.transform.position);
			lineRenderer.SetPosition(1, this.mytarget.transform.position);*/
<<<<<<< HEAD
			this.GetComponentInParent<PlasmaController>().CurPlasma--;
=======
			this.GetComponentInParent<GhostModel>().plasma--;
>>>>>>> cf688b337a2ddfa0cda8daa140619680d9fa8747
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
