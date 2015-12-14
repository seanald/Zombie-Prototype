using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Devil : Enemy
{
	private int random = 0;
	
	void IsFeared()
	{
		this.state = CharacterState.Fleeing;
	}
	
	override protected void Attack()
	{
		if (random == 0)
		{
			random = Random.Range(1, 4);
		}
		
		if (!this.attacking)
		{
			if (random == 1)
			{
				if (this.distance <= this.attackDistance)
				{
					this.Throw();
					StartCoroutine(WaitForAnimation());
				}
				else
				{
					base.Seek(this.distVec);
					this.enemyAnimator.Play("Walk");
				}
			}
			else if (random == 2)
			{
				if (this.distance <= this.attackDistance + 100)
				{
					this.Spell();
					StartCoroutine(WaitForAnimation());
				}
				else
				{
					base.Seek(this.distVec);
					this.enemyAnimator.Play("Walk");
				}
			}
			else if (random == 3)
			{
				this.Rocket();
				StartCoroutine(WaitForAnimation());
			}
		}
		else
		{
			this.random = 0;
		}
	}
	
	private void Spell()
	{
		this.enemyAnimator.Play("Spell");
		this.attacking = true;
	}
	
	private void Rocket()
	{
		this.enemyAnimator.Play("Rocket");
		this.attacking = true;
	}
	
	private void Throw()
	{
		this.enemyAnimator.Play("Throw");
		this.attacking = true;
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
			StartCoroutine(this.WaitForAttack());
		}
	}
	
	override protected void Stunned()
	{
		
	}
	
	IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(1.0f);
		this.attacking = false;
		this.Move();
	}
	
	IEnumerator WaitForAttack()
	{
		this.strafing = true;
		yield return new WaitForSeconds(this.attackRate);
		this.state = CharacterState.Attacking;
		this.strafing = false;
	}
	
}
