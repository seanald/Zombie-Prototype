using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character
{
	protected Animator enemyAnimator;
	protected Transform target;
	public float attackDistance = 80.0f;
	public float dangerDistance = 500.0f;
	public float attackRate = 5.0f;
	protected float attackCooldown = 10.0f;
	protected float stunTime;
	protected Vector3 distVec;
	protected Vector3 avoidVec = Vector3.zero;
	protected float distance;
	protected float sqrDistance;
	protected float sqrAttackDistance;
	protected float sqrDangerDistance;
	protected Vector3 destination;

	protected List<Enemy> enemyList;

	protected bool strafing;

	virtual protected void Attack()
	{
	}

	virtual protected void Move()
	{
	}

	virtual protected void Stunned()
	{
	}

	virtual protected void Standing()
	{
	}

	new protected void Start()
	{
		base.Start();
		this.state = CharacterState.Attacking;
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.target = GameObject.Find("ZombieController").transform;

		this.attackCooldown = this.attackRate;

		sqrAttackDistance = Mathf.Pow(attackDistance, 2);
		sqrDangerDistance = Mathf.Pow(dangerDistance, 2);

		this.stunTime = this.stunnedTime;
	}

	new protected void FixedUpdate()
	{
		base.FixedUpdate();
		this.alwaysFacePlayer();
		UpdateDistance();

		Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
		this.enemyList = new List<Enemy>(enemies);
		this.enemyList.Remove((Enemy)this);

		if (this.state == CharacterState.Stunned)
		{
			this.Stunned();
		}
		else if (this.state == CharacterState.Attacking)
		{
			this.Attack();
		}
		else if (this.state == CharacterState.Fleeing)
		{
			this.Seek(distVec);
		}
		else if (this.state == CharacterState.Standing)
		{
			this.Standing();
		}
		else if (this.state == CharacterState.Moving)
		{
			this.Move();
		}
	}

	protected void Seek(Vector3 distVec)
	{
		if (this.velocity != Vector3.zero)
			return;

		Vector3 movement = distVec.normalized;
		movement.y = 0.0f;

		this.RawMovement(movement);
	}

	protected bool checkForOtherAttackers()
	{
		foreach(Enemy e in this.enemyList)
		{
			if (e.State == CharacterState.Attacking)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateDistance()
	{
		destination = target.transform.position;
		distVec = (destination - transform.position);

		distance = distVec.magnitude;
		sqrDistance = distVec.sqrMagnitude;
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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "GhostBullet")
		{
			this.state = CharacterState.Stunned;
			stunTime = Time.time;
		}
	}
}
