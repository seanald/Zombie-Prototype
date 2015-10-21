using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public int maxHealth = 100;
	public float armor = 0.0f;
	public float invincibilityDuration = 1.0f;

	public bool invincibleWhenHit = false;

	private int curHealth = 100;
	private bool invincible = false;

	// Use this for initialization
	void Start()
	{
		this.curHealth = this.maxHealth;
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void OnDamage(Attack attack)
	{
		//Do attack stuffs
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
