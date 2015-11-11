using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FootballWolfMovement : Enemy
{
	public GameObject football;

	private Animator enemyAnimator;
	private Transform target;
	public float attackDistance = 80.0f;
	public float dangerDistance = 500.0f;
	public float attackRate = 10.0f;
	private float attackCooldown = 10.0f;
	private float stunTime;
	private float stunnedTime = 2f;
	private Vector3 distVec;
	private Vector3 avoidVec = Vector3.zero;
	private float distance;
	private float sqrDistance;
	private float sqrAttackDistance;
	private float sqrDangerDistance;
	private Vector3 destination;
	private bool stunned;
	private bool strafing;

	public Transform throwPoint;

	private List<Enemy> enemyList;

	private float curLocalScale;

	new void Start()
	{
		base.Start();
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.target = GameObject.Find("ZombieController").transform;

		this.attackCooldown = this.attackRate;

		sqrAttackDistance = Mathf.Pow(attackDistance, 2);
		sqrDangerDistance = Mathf.Pow(dangerDistance, 2);

		this.stunTime = this.stunnedTime;

		this.curLocalScale = this.transform.localScale.x;
	}

	new void FixedUpdate()
	{
		base.FixedUpdate();
		UpdateDistance();

		Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
		this.enemyList = new List<Enemy>(enemies);
		this.enemyList.Remove((Enemy)this);

		if (this.state == CharacterState.Stunned)
		{
			if (!this.stunned)
			{
				this.enemyAnimator.Play("FootballWolf_Stunned");
				this.stunned = true;
				StartCoroutine(this.WaitForStun());
			}
		}
		else if (this.state == CharacterState.Attacking)
		{
			this.Attack();
		}
		else if (this.state == CharacterState.Fleeing)
		{

		}
		else if (this.state == CharacterState.Standing)
		{
			this.Strafe();
		}

		if (this.transform.localScale.x != curLocalScale)
		{
			throwPoint.RotateAround (throwPoint.position, throwPoint.up, 180f);
			this.curLocalScale = this.transform.localScale.x;
		}

		this.alwaysFacePlayer();
	}

	void UpdateDistance()
	{
		destination = target.transform.position;
		distVec = (destination - transform.position);

		distance = distVec.magnitude;
		sqrDistance = distVec.sqrMagnitude;
	}

	IEnumerator WaitForStun()
	{
		this.GetComponentInChildren<Flicker>().Flash();
		yield return new WaitForSeconds(this.stunnedTime);
		this.state = CharacterState.Attacking;
		this.stunned = false;
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
		yield return new WaitForSeconds(this.enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
		this.Strafe();
	}

	public void Seek(Vector3 distVec, bool align)
	{
		if (this.velocity != Vector3.zero)
		{
			this.enemyAnimator.Play("FootballWolf_Stand");
			return;
		}

		moveVec = distVec.normalized;
		moveVec.y = 0.0f;

		this.RawMovement(moveVec);
		this.enemyAnimator.Play("FootballWolf_Walk");
	}

	void Attack()
	{
		if (this.distance < this.attackDistance)
		{
			//TODO: Align vertically with player on left or right side
			this.enemyAnimator.Play("FootballWolf_Throw");
			Instantiate(football, throwPoint.position, throwPoint.localRotation);
			this.state = CharacterState.Standing;
			this.WaitForAnimation();
		}
		else
		{
			this.Seek(distVec, true);
		}
	}

	void Strafe()
	{
		if (this.distance >= this.dangerDistance + 50)
		{
			this.Seek(this.distVec, true);
		}

		this.state = CharacterState.Standing;
		if (this.distance < this.dangerDistance - 50)
		{
			this.Seek(this.distVec * -1, true);
		}
		else if (distVec.x > 0)
		{
			Vector3 scale = transform.localScale;
			scale.x = 1;
			this.transform.localScale = scale;
		}
		else if (distVec.x < 0)
		{
			Vector3 scale = transform.localScale;
			scale.x = -1;
			this.transform.localScale = scale;
		}

		if (!this.strafing)
		{
			StartCoroutine(WaitForAttack());
		}
	}

	private bool checkForOtherAttackers()
	{
//		foreach(Enemy e in this.enemyList)
//		{
//			if(e.EnemyState == EnemyState.Attacking)
//			{
//				return true;
//			}
//		}
		return false;
	}

	private void alwaysFacePlayer()
	{
		if (distVec.x > 0)
		{
			Vector3 scale = transform.localScale;
			scale.x = 1;
			this.transform.localScale = scale;
		}
		else if (distVec.x < 0)
		{
			Vector3 scale = transform.localScale;
			scale.x = -1;
			this.transform.localScale = scale;
		}
	}

}
