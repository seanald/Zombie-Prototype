using UnityEngine;
using System.Collections;

public class Zombie : Player
{
	private Animator zombieAnimator;
	private int comboNumber = 0;
	private float comboMaxTime = 1.0f;
	private float comboSpanTime = 0.25f;
	private float comboMidPoint = 0.5f;
	private float comboTimeout = 0.0f;

	void Start()
	{
		base.Start();
		this.zombieAnimator = this.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) && GameObject.Find("ZombieController").tag == "ActivePlayer")
		{
			this.state = CharacterState.Attacking;
			StartCoroutine(this.Punch());
		}
		else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.JoystickButton2) && GameObject.Find("ZombieController").tag == "ActivePlayer")
		{
			StartCoroutine(this.Dash());
		}
		else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton1) && GameObject.Find("ZombieController").tag == "ActivePlayer")
		{
			StartCoroutine(this.Chomp());
		}
		else if (this.state == CharacterState.Moving)
		{
			this.zombieAnimator.SetBool("walking", true);
		}
		else if (this.state == CharacterState.Standing)
		{
			this.zombieAnimator.SetBool("walking", false);
		}

		if (comboTimeout > 0)
		{
			DecreaseTime();
		}
	}

	IEnumerator Punch()
	{
		this.ComboTime();
		this.state = CharacterState.Attacking;
		if (this.comboNumber == 1)
		{
			this.zombieAnimator.Play("Zombie_Punch");
			yield return new WaitForSeconds(0.8f);
		}
		else if (this.comboNumber == 2)
		{
			this.zombieAnimator.Play("Zombie_Punch_2");
			yield return new WaitForSeconds(0.8f);
		}
		else if (this.comboNumber == 3)
		{
			this.zombieAnimator.Play("Zombie_Punch_3");
			yield return new WaitForSeconds(1.4f);
			this.comboNumber = 0;
		}
		this.state = CharacterState.Standing;
	}

	private IEnumerator Dash()
	{
		this.state = CharacterState.Attacking;
		this.zombieAnimator.Play("Zombie_Dash");
		yield return new WaitForSeconds(0.8f);
		this.state = CharacterState.Standing;
	}

	private IEnumerator Chomp()
	{
		this.state = CharacterState.Attacking;
		this.zombieAnimator.Play("Zombie_Chomp");
		yield return new WaitForSeconds(2f);
		this.state = CharacterState.Standing;
	}

	public int ComboNumber
	{
		get {
			return comboNumber;
		}
		set {
			comboNumber = value;
		}
	}

	private void ComboTime()
	{
		if (comboNumber < 3 && 
			comboTimeout > 0 && 
			comboTimeout > comboMidPoint - comboSpanTime &&
			comboTimeout < comboMidPoint + comboSpanTime ||
			comboNumber == 0)
		{
			comboNumber++;
		}
		else
		{
			comboNumber = 0;
		}
		comboTimeout = comboMaxTime;
	}

	private void DecreaseTime()
	{
		comboTimeout -= 1 * Time.deltaTime;
	}
}
