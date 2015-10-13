using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour
{
	
	private float distance;
	private float maxdistance = 50f;
	public Vector3 offset;
	private bool bighit = false;
	public Vector3 knockback;
	
	// Use this for initialization
	void FixedUpdate()
	{
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Test to see if enemy is in range, if so take it takes damage while kicking.
			RaycastHit hit;
			Debug.DrawLine(offset + transform.position, transform.right * 100, Color.green);
			if (Physics.Raycast(offset + transform.position, transform.right, out hit))
			{
				distance = hit.distance;
				print(hit.transform.tag);
				if (distance < maxdistance && hit.transform.gameObject.GetComponentInChildren<EnemyController>() != null)
				{
					EnemyController enemyhit = hit.transform.gameObject.GetComponentInChildren<EnemyController>();
					enemyhit.Health--;
					if (bighit)
					{
						print("bighit");
						enemyhit.transform.position = enemyhit.transform.position + knockback;
					}
					if (enemyhit.Health <= 0)
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
			
		}
		
	}
}
