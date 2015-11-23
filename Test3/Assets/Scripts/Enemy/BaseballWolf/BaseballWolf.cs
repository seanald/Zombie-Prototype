using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseballWolf : Enemy
{
	void IsFeared()
	{
		this.target = GameObject.Find("Right").transform;
		this.state = CharacterState.Fleeing;
		StartCoroutine(WaitForDeath());
	}

	void TakeDamage()
	{
		this.health.CurHealth -= 20;
	}

	override protected void Attack()
	{
		if (this.distance < this.attackDistance)
		{
			this.enemyAnimator.Play("Batwolf_Swing");
			StartCoroutine(WaitForAnimation());
		}
		else
		{
			base.Seek(distVec);
			this.enemyAnimator.Play("Batwolf_Walk");
		}
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

		this.enemyAnimator.Play("Batwolf_Walk");

		if (!this.strafing)
		{
			StartCoroutine(WaitForAttack());
		}
	}

	override protected void Stunned()
	{
		this.enemyAnimator.Play("Batwolf_Stunned");
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

	IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(30f);
		Destroy(this.gameObject);
	}
}
