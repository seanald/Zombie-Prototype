using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	
	public Slider healthSlider;

	private int maxHealth;
	private int curHealth;

	void Start()
	{
		this.MaxHealth = this.GetComponentInParent<ZombieModel>().Health;
		
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

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Hazard")
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
