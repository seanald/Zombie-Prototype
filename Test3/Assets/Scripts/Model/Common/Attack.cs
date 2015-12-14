﻿using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
	public GameObject owner;
	public int damage = 0;
	public float knockback = 0.0f;
	public bool stun;
	public GameObject victim;  // this is only not null if the event actually hit something
	public GameObject particleSystem; //particle system
	//AudioSource swingAttack;
	AudioSource weakAttack;
	GameObject player;

	void Awake()
	{


	}

	void Start()
	{
		owner = this.gameObject;
		AudioSource[] allmyAudioSources = GetComponentsInParent<AudioSource>();
		//swingAttack = allmyAudioSources[0];
		if (allmyAudioSources.Length >= 1)
		{
			weakAttack = allmyAudioSources[0];
		}
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

	protected virtual void OnTriggerEnter(Collider other)
	{
		if ((this.gameObject.tag.Equals("Player") && other.GetComponentInParent<Player>() == null)
			|| (this.gameObject.tag.Equals("ActivePlayer") && other.GetComponentInParent<Player>() == null)
			|| (this.gameObject.tag.Equals("Enemy") && other.GetComponentInParent<Enemy>() == null))
		{
			if (other.gameObject.GetComponent<Health>())
			{
				if (weakAttack != null)
				{
					Instantiate(particleSystem, transform.position, Quaternion.identity);
					weakAttack.Play();
				}
				other.gameObject.GetComponent<Health>().OnDamage(this);
			}
		}
	}
}
