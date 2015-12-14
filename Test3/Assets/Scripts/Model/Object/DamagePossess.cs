using UnityEngine;
using System.Collections;

public class DamagePossess : MonoBehaviour {
	
	Possessable possessable;
	private bool isActive;
	private GameObject ghost;
	public GameObject alert;
	private bool alreadyActivated;
	
	void Start()
	{
		this.possessable = this.GetComponent<Possessable>();
		ghost = GameObject.Find("GhostController");
		alreadyActivated = false;
	}
	
	void Update()
	{
		//if (possessable.Possessed)
		//{
		//recieve button input from player to cause possess effect
		if(!alreadyActivated){
			if(isActive)
			{

				if((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2)) && GameObject.Find("GhostController").GetComponentInParent<Plasma>().CurPlasma >= 20 && GameObject.Find("GhostController").tag == "ActivePlayer"){
					//play animation
					Instantiate(alert, this.transform.position, this.transform.rotation);
					this.CauseDamage();
					alreadyActivated=true;
					GameObject.Find("GhostController").GetComponentInParent<Plasma>().CurPlasma -= 20;
					StartCoroutine(WaitForDeath());
				}
			}
		}
		
		//}
	}

	IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}
	
	public void CauseDamage()
	{
		//get enemies in radius and set them to fleeing
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 200f);
		int i = 0;
		while(i<hitColliders.Length)
		{
			if (hitColliders[i].tag == "Enemy" || hitColliders[i].tag == "EnemyScared")
			{
				hitColliders[i].SendMessage("TakeDamage");
			}
			i++;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		
		GameObject ghost = GameObject.Find("GhostController");
		
		if (col.gameObject == ghost)
		{
			isActive = true;

		}
	}
	
	void OnTriggerExit(Collider col)
	{
		GameObject ghost = GameObject.Find("GhostController");
		if (col.gameObject == ghost)
		{
			isActive = false;
		}
	}
}


