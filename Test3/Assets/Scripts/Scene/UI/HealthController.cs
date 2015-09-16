using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	
	public Slider healthSlider;
	public ZombieModel zombieModel;

	private int maxHealth;
	private int curHealth;

	void Start()
	{
		this.MaxHealth = this.zombieModel.Health;
		
		this.healthSlider.maxValue = this.MaxHealth;
		this.CurHealth = this.MaxHealth;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			curHealth--;
			this.healthSlider.value = curHealth;
		}
	}

	public int MaxHealth
	{
		get {
			return maxHealth;
		}
		set {
			maxHealth = value;
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
