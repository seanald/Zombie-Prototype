using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WitchBoss : Enemy
{
	private int random = 0;
	private bool teleporting;
	private List<GameObject> teleportSpots;

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
				if (this.distance < this.attackDistance)
				{
					this.StandardAttack();
					StartCoroutine(WaitForAnimation());
				}
				else
				{
					base.Seek(distVec);
					this.enemyAnimator.Play("Boss_Witch_Forward");
				}
			}
			else if (random == 2)
			{
				if (this.distance < this.attackDistance+100)
				{
					this.SpellAttack();
					StartCoroutine(WaitForAnimation());
				}
				else
				{
					base.Seek(distVec);
					this.enemyAnimator.Play("Boss_Witch_Forward");
				}
			}
			else if (random == 3)
			{
				StartCoroutine(TeleportOut());
			}
		}
		else if (this.teleporting)
		{
			if (this.distance < this.attackDistance)
			{
				StartCoroutine(TeleportIn());
				this.random = 0;
			}
			else
			{
				base.Seek(distVec);
			}
		}
		else
		{
			this.random = 0;
		}
	}

	private void StandardAttack()
	{
		this.enemyAnimator.Play("Boss_Witch_Attack");
		this.attacking = true;
	}

	private void SpellAttack()
	{
		this.enemyAnimator.Play("Boss_Witch_Spell");
		this.attacking = true;
	}

	IEnumerator TeleportIn()
	{
		this.gameObject.GetComponentInChildren<Renderer>().enabled = true;
		this.enemyAnimator.Play("Boss_Witch_Teleport_In");
		yield return new WaitForSeconds(1.0f);
		this.attacking = false;
		this.teleporting = false;
	}

	IEnumerator TeleportOut()
	{
		this.attacking = true;
		this.enemyAnimator.Play("Boss_Witch_Teleport_Out");
		yield return new WaitForSeconds(1.0f);
		this.gameObject.GetComponentInChildren<Renderer>().enabled = false;
		this.teleporting = true;
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

		this.enemyAnimator.Play("Boss_Witch_Forward");

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
		this.attacking = false;
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
