using UnityEngine;
using System.Collections;

public class Zombie : Player
{
	private Animator zombieAnimator;
	private int comboNumber;

	 void Start()
	{
		base.Start();
		this.zombieAnimator = this.GetComponentInChildren<Animator>();
		this.comboNumber = 0;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.state = CharacterState.Attacking;
			StartCoroutine(this.Punch());
		}
        else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Z))
        {
			StartCoroutine(this.Dash());
        }
		else if (Input.GetKeyDown(KeyCode.C))
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
	}

	IEnumerator Punch()
	{
		this.comboNumber++;
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
		yield return new WaitForSeconds(0.8f);
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
}
