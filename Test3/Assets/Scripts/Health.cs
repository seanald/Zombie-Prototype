using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int maxHealth;
	public Slider healthSlider;

	private int curHealth;

	void Start()
	{
		this.healthSlider.maxValue = this.maxHealth;
		this.healthSlider.value = this.maxHealth;
		this.curHealth = this.maxHealth;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			curHealth--;
			this.healthSlider.value = curHealth;
		}
	}
}
