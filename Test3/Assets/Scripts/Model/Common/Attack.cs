using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

	public GameObject owner;
	public int damage = 0;
	public float knockback = 0.0f;
	public bool stun;
	public GameObject victim;  // this is only not null if the event actually hit something

	public Attack(GameObject owner, int damage, float knockback)
	{
		this.owner = owner;
		this.damage = damage;
		this.knockback = knockback;
	}

	void Start()
	{
		owner = this.gameObject;
	}

	static public int CalculateDamage(int damage, int armor)
	{
		int total = 0;

		if (damage > 0)
		{
			total = Mathf.Max(1, damage - Mathf.Max(0, armor));
		}

		return total;
	}

	void OnTriggerEnter(Collider other)
	{
		print("test");
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
		    || (this.gameObject.tag.Equals("ActivePlayer") && other.GetComponentInParent<Player>() == null)
		    || (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null))
		{
			print("test");
			if (other.gameObject.GetComponent<Health>())
			{
				other.gameObject.GetComponent<Health>().OnDamage(this);
			}
		}
	}
}
