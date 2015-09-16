using UnityEngine;
using System.Collections;

public class ZombieAnimatorController : MonoBehaviour
{
	private string currentDirection = "right";
	private Animator zombieAnimator;
	private CharacterController controller;
	
	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.zombieAnimator = this.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (this.controller.isGrounded && this.controller.velocity != Vector3.zero)
		{
			this.zombieAnimator.SetBool("walking", true);
		}
		else
		{
			this.zombieAnimator.SetBool("walking", false);
		}
	}
}
