using UnityEngine;
using System.Collections;

public class ZombieAnimatorController : MonoBehaviour
{
	private Animator zombieAnimator;
	private CharacterController controller;

	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.zombieAnimator = this.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			this.Punch();
		}

		if (this.controller.isGrounded && this.controller.velocity != Vector3.zero)
		{
			this.zombieAnimator.SetBool("walking", true);
		}
		else
		{
			this.zombieAnimator.SetBool("walking", false);
		}
	}

	private void Punch()
	{
		this.zombieAnimator.Play("Zombie_Punch");
	}
}
