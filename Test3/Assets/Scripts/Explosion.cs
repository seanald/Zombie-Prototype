using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CauseDamage();
		StartCoroutine(WaitForDeath());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(.3f);
		Destroy(this.gameObject);
	}

	public void CauseDamage()
	{
		//get enemies in radius and set them to fleeing
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 100f);
		int i = 0;
		while(i<hitColliders.Length)
		{
			if (hitColliders[i].tag == "Enemy" || hitColliders[i].tag == "EnemyScared")
			{
				hitColliders[i].SendMessage("TakeDamage");
			}
			if (hitColliders[i].gameObject == GameObject.Find("ZombieController"))
			{
				hitColliders[i].gameObject.GetComponent<Health>().CurHealth = hitColliders[i].gameObject.GetComponent<Health>().CurHealth - 100;
			}
			i++;
		}
	}
}
