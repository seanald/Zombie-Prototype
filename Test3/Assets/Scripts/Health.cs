using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth;

	private int curHealth;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
		{
			curHealth--;
		}
	}
}
