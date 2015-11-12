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

	protected void Start()
	{
		base.Start();
	}

	protected void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
