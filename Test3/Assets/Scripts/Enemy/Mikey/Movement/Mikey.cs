﻿using UnityEngine;
using System.Collections;

public class Mikey : Enemy 
{
	void IsFeared()
	{
		this.state = CharacterState.Fleeing;
	}

	override protected void Attack()
	{
		int random = 0;
		if (this.distance < this.attackDistance)
		{
			random = Random.Range(1, 4);
			if (random == 1)
			{
				this.StandardAttack();
				StartCoroutine(WaitForAnimation());
			}
			if (random == 2)
			{
				this.SholderAttack();
				StartCoroutine(WaitForAnimation());
			}
			if (random == 3)
			{
				this.HowlAttack();
				StartCoroutine(WaitForAnimation());
			}
		}
		else
		{
			base.Seek(distVec);
			this.enemyAnimator.Play("Walk");
		}
	}

	private void StandardAttack()
	{
		this.enemyAnimator.Play("Attack");
	}

	private void SholderAttack()
	{
		this.enemyAnimator.Play("Sholder");
	}

	private void HowlAttack()
	{
		this.enemyAnimator.Play("Howl");
	}

	override protected void Move()
	{
		this.state = CharacterState.Moving;
		if (this.distance >= this.dangerDistance + 50)
		{
			this.Seek(this.distVec);
		}

		if (this.distance < this.dangerDistance - 50)
		{
			this.Seek(this.distVec * -1);
		}

		this.enemyAnimator.Play("Walk");

		if (!this.strafing)
		{
			StartCoroutine(WaitForAttack());
		}
	}

	override protected void Stunned()
	{

	}

	IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(1.0f);
		this.Move();
	}

	IEnumerator WaitForAttack()
	{
		this.strafing = true;
		yield return new WaitForSeconds(this.attackRate);
		if (!this.checkForOtherAttackers())
		{
			this.state = CharacterState.Attacking;
		}
		this.strafing = false;
	}

}
