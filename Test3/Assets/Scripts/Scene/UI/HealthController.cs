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

	void Update()
	{

			this.healthSlider.value = curHealth;
			if(curHealth <= 0)
			{
			Application.LoadLevel(Application.loadedLevel);
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
