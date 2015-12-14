using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FootballWolf : Enemy
{
	public GameObject football;

	public Transform throwPoint;
	private float curLocalScale;

	void Start()
	{
		base.Start();
		this.curLocalScale = this.transform.localScale.x;
	}

	void FixedUpdate()
	{
		base.FixedUpdate();

		if (this.transform.localScale.x != curLocalScale)
		{
			throwPoint.RotateAround (throwPoint.position, throwPoint.up, 180f);
			this.curLocalScale = this.transform.localScale.x;
		}
	}

	void IsFeared()
	{
		this.target = GameObject.Find("Right").transform;
		this.state = CharacterState.Fleeing;
		StartCoroutine(WaitForDeath());
	}

	void IsHaunted()
	{
		if(GameObject.Find("GhostController").transform.position.x - this.transform.position.x < 0)
		{
			this.target = GameObject.Find("Right").transform;
		}
		else if(GameObject.Find("GhostController").transform.position.x - this.transform.position.x > 0)
		{
			this.target = GameObject.Find("Left").transform;
		}
		this.state = CharacterState.Fleeing;
		StartCoroutine(WaitForHauntEnd());
	}
	
	IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(30f);
		Destroy(this.gameObject);
	}

	void TakeDamage()
	{
		this.health.CurHealth -= 20;
	}

	override protected void Attack()
	{
		if (this.distance < this.attackDistance)
		{
			if(!this.attacking)
			{
			this.enemyAnimator.Play("FootballWolf_Throw");
			Instantiate(football, throwPoint.position, throwPoint.localRotation);
			this.attacking = true;
			StartCoroutine(WaitForAnimation());
			}
		}
		else
		{
			this.Seek(distVec);
			this.enemyAnimator.Play("FootballWolf_Walk");
		}
	}


	override protected void Move()
	{
		if (this.distance >= this.dangerDistance + 50)
		{
			this.Seek(this.distVec);
		}

		if (this.distance < this.dangerDistance - 50)
		{
			this.Seek(this.distVec * -1);
		}

		this.enemyAnimator.Play("FootballWolf_Walk");

		if (!this.strafing)
		{
			StartCoroutine(WaitForAttack());
		}
	}

	override protected void Stunned()
	{
		this.enemyAnimator.Play("FootballWolf_Stunned");
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

	IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(1.0f);
		this.attacking = false;
		this.Move();
	}

	IEnumerator WaitForHauntEnd()
	{
		yield return new WaitForSeconds(3f);
		this.target = GameObject.Find("ZombieController").transform;
		this.state = CharacterState.Attacking;
	}
}
