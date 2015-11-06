using UnityEngine;
using System.Collections;

public class ZombieAnimatorController : MonoBehaviour
{
	private Animator zombieAnimator;
	private CharacterController controller;
	private Player player;
	private int comboNumber;

	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.zombieAnimator = this.GetComponentInChildren<Animator>();
		this.player = this.GetComponentInChildren<Player>();
		this.comboNumber = 0;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.player.PlayerState = PlayerState.attacking;
			StartCoroutine(this.Punch());
		}
		else if (this.player.PlayerState == PlayerState.moving)
		{
			this.zombieAnimator.SetBool("walking", true);
		}
		else if (this.player.PlayerState == PlayerState.standing)
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
			this.zombieAnimator.Play("Zombie_Punch");
			yield return new WaitForSeconds(1.4f);
			this.comboNumber = 0;
		}
		this.player.PlayerState = PlayerState.standing;
	}
}
