using UnityEngine;
using System.Collections;

public class Chomp : Attack
{
	protected override void OnTriggerEnter(Collider other)
	{
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
			|| (this.gameObject.tag.Equals("ActivePlayer") && other.GetComponentInParent<Player>() == null)
			|| (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null))
		{
			if (other.gameObject.GetComponent<Health>())
			{
				this.transform.parent.parent.gameObject.GetComponent<Health>().AddHealth(this.damage);
				other.gameObject.GetComponent<Health>().OnDamage(this);
			}
		}
	}
}
