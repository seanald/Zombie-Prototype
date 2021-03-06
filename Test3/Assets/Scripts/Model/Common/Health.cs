﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	private Character character;

	public int maxHealth = 100;
	public float armor = 0.0f;
	public float invincibilityDuration = 1.0f;

	public bool invincibleWhenHit = false;

	private int curHealth = 100;

	public Slider healthBar;

	void Start()
	{
		this.curHealth = this.maxHealth;
		this.character = this.gameObject.GetComponentInParent<Character>();
	}

	void Update()
	{
		if (this.healthBar != null)
		{
			this.healthBar.maxValue = this.maxHealth;
			this.healthBar.value = this.curHealth;
		}
	}

	public void OnDamage(Attack attack)
	{
		CurHealth -= attack.damage;
		this.character.State = CharacterState.Stunned;
        if (CurHealth <= 0)
		{
			if (this.GetComponentInChildren<Flicker>() != null)
			{
				this.GetComponentInChildren<Flicker>().Flash();
			}
            ScoreManager.AddPoints(10);
            if (this.gameObject.GetComponentInChildren<Animator>() != null)
			{
				character.State = CharacterState.Dying;
				this.gameObject.GetComponentInChildren<Animator>().Play("death");
				this.StartCoroutine(this.KillOnAnimationEnd());
                
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}

	public void AddHealth(int hp)
	{
		curHealth += hp;
		if (curHealth > maxHealth)
		{
			curHealth = maxHealth;
		}
	}

	public int CurHealth
	{
		get {
			return curHealth;
		}
		set {
			curHealth = value;
		}
	}

	public void ResetHealth()
	{
		this.curHealth = this.maxHealth;
	}

	private IEnumerator KillOnAnimationEnd()
	{
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}

}
