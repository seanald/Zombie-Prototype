using UnityEngine;
using System.Collections;

public class GhostHaunt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H) && this.GetComponentInParent<Plasma>().CurPlasma >= 50)
		{
			this.CauseHaunt();
			this.GetComponentInParent<Plasma>().CurPlasma -= 50;
		}
	}

	public void CauseHaunt()
	{
		//get enemies in radius and set them to fleeing
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 200f);
		int i = 0;
		while(i<hitColliders.Length)
		{
			if (hitColliders[i].tag == "Enemy")
			{
				hitColliders[i].SendMessage("IsHaunted");
			}
			i++;
		}
	}
}
