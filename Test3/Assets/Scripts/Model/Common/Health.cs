using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public int maxHealth = 100;
	public float armor = 0.0f;
	public float invincibilityDuration = 1.0f;

	public bool invincibleWhenHit = false;

	private int curHealth = 100;
	private bool invincible = false;

	public Slider healthBar;

	void Start()
	{
		this.curHealth = this.maxHealth;
	}
	
	void Update()
	{
		if (this.healthBar != null)
		{
			this.healthBar.maxValue = this.maxHealth;
			this.healthBar.value = this.curHealth;
			if (curHealth <= 0)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if (CurHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	public void OnDamage(Attack attack)
	{
		CurHealth -= attack.damage;
		if (CurHealth <= 0)
		{
			Destroy(this.gameObject);
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
}
