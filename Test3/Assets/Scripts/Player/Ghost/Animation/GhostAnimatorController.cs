﻿using UnityEngine;
using System.Collections;

public class GhostAnimatorController : MonoBehaviour
{
	private Animator ghostAnimator;
	private CharacterController controller;

	void Start()
	{
		this.controller = this.GetComponentInParent<CharacterController>();
		this.ghostAnimator = this.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton1)) && GameObject.Find("GhostController").tag == "ActivePlayer")
		{
			StartCoroutine(this.Fire());
		}
		else if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton0)) && this.GetComponentInChildren<Plasma>().CurPlasma >= 20 && GameObject.Find("GhostController").tag == "ActivePlayer")
		{
			StartCoroutine(this.Haunt());
		}

		if (this.controller.velocity.magnitude != 0)
		{
			this.ghostAnimator.SetBool("walking", true);
		}
		else
		{
			this.ghostAnimator.SetBool("walking", false);
		}
	}

	private IEnumerator Fire()
	{
		this.ghostAnimator.Play("Ghost_Fire");
		yield return new WaitForSeconds(0.4f);
		this.ghostAnimator.Play("Ghost_Stand");
	}
	private IEnumerator Haunt()
	{
		this.ghostAnimator.Play("Ghost_Possess");
		yield return new WaitForSeconds(1.5f);
		this.ghostAnimator.Play("Ghost_Stand");
	}
}
