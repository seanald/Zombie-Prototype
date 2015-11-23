using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class Mikey : Enemy
{
	public GameObject spawnEnemy;
	public Vector3 spawnOffset = new Vector3(-500, 0, 0);
	private GameObject newEnemy;
	private float timeStamp;
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
				if (this.distance < this.attackDistance)
				{
					this.StandardAttack();
					StartCoroutine(WaitForAnimation());
				}
				else
				{
					base.Seek(distVec);
					this.enemyAnimator.Play("Walk");
				}
			}
			else if (random == 2)
			{
				if (this.distance < this.attackDistance)
				{
					this.SholderAttack();
					StartCoroutine(WaitForAnimation());
				}
				else
				{
					base.Seek(distVec);
					this.enemyAnimator.Play("Walk");
				}
			}
			else if (random == 3 && this.newEnemy == null)
			{
				this.HowlAttack();
				StartCoroutine(WaitForAnimation());
			}
		}
		else
		{
			random = 0;
		}

	}
	
	private void StandardAttack()
	{
		this.enemyAnimator.Play("Attack");
		this.attacking = true;
	}
	
	private void SholderAttack()
	{
		this.enemyAnimator.Play("Sholder");
		this.attacking = true;
	}
	
	private void HowlAttack()
	{
		this.enemyAnimator.Play("Howl");
		this.newEnemy = Instantiate(spawnEnemy, this.transform.position + spawnOffset, this.transform.rotation) as GameObject;
		this.attacking = true;
	}
	
	override protected void Move()
	{
		this.state = CharacterState.Moving;
		if (this.distance >= this.dangerDistance + 50)
		{
			this.Seek(this.distVec);
		}
		else if (this.distance < this.dangerDistance - 50)
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
