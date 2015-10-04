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
		this.zombieAnimator.SetBool("right", true);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			this.Punch();
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.zombieAnimator.SetBool("right", true);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.zombieAnimator.SetBool("right", false);
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
		if (this.zombieAnimator.GetBool("right"))
		{
			this.zombieAnimator.Play("Zombie_Right_Punch");
		}
		else
		{
			this.zombieAnimator.Play("Zombie_Left_Punch");
		}
	}
}
