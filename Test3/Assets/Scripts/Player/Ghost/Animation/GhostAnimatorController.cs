using UnityEngine;
using System.Collections;

public class GhostAnimatorController : MonoBehaviour
{
	private Animator ghostAnimator;
	private CharacterController controller;

	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.ghostAnimator = this.GetComponentInChildren<Animator>();
		this.ghostAnimator.SetBool("right", true);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.ghostAnimator.SetBool("right", true);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.ghostAnimator.SetBool("right", false);
		}

		if (this.controller.isGrounded && this.controller.velocity != Vector3.zero)
		{
			this.ghostAnimator.SetBool("walking", true);
		}
		else
		{
			this.ghostAnimator.SetBool("walking", false);
		}
	}
}
