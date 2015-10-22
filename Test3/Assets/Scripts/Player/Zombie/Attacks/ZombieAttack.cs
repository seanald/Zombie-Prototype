using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieAttack : MonoBehaviour
{
	
	private float distance;
	private float maxdistance = 50f;
	public Vector3 offset;
	private bool bighit = false;
	public Vector3 knockback;

	Dictionary<string, Transform> dict = new Dictionary<string, Transform>();

	void Start()
	{
		foreach(Transform t in transform)
		{
			dict.Add(t.name, t);
		}
	}
	
	// Use this for initialization
	void FixedUpdate()
	{
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Transform hitbox = this.transform.FindChild("Hitboxes");
			Transform punch = hitbox.FindChild("Punch");
			punch.gameObject.SetActive(true);

			RaycastHit
			hit;
			Debug.DrawLine(offset + transform.position, transform.right * 100, Color.green);
			if (Physics.Raycast(offset + transform.position, transform.right, out hit))
			{
				distance = hit.distance;
				print(hit.transform.tag);
				if (distance < maxdistance && hit.transform.gameObject.GetComponentInChildren<Health>() != null)
				{
					Health enemyhit = hit.transform.gameObject.GetComponentInChildren<Health>();
					enemyhit.CurHealth--;
					if (bighit)
					{
						print("bighit");
						enemyhit.transform.position = enemyhit.transform.position + knockback;
					}
					if (enemyhit.CurHealth <= 0)
					{
						Destroy(hit.transform.gameObject);
					}
					bighit = !bighit;
				}
				else
				{
					bighit = false;
				}
			}
			punch.gameObject.SetActive(false);
		}
		
	}
}
