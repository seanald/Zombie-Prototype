using UnityEngine;
using System.Collections;

public class ZombieAnimatorController : MonoBehaviour
{
	private Animator zombieAnimator;
	private CharacterController controller;
	private Player player;

	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.zombieAnimator = this.GetComponentInChildren<Animator>();
		this.player = this.GetComponentInChildren<Player>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.player.PlayerState = PlayerState.attacking;
			StartCoroutine(this.Punch());
		}
		else if (this.controller.isGrounded && this.controller.velocity != Vector3.zero)
		{
			this.zombieAnimator.SetBool("walking", true);
		}
		else
		{
			this.zombieAnimator.SetBool("walking", false);
		}
	}

	IEnumerator Punch()
	{
		this.zombieAnimator.Play("Zombie_Punch");
		yield return new WaitForSeconds(0.8f);
		this.player.PlayerState = PlayerState.standing;
	}
}
