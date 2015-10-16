using UnityEngine;
using System.Collections;

public class BaseballWolfMovement : MonoBehaviour
{
	private Animator enemyAnimator;
	private Enemy enemy;
	private Transform target;

	public float attackDistance = 80.0f;
	public float dangerDistance = 500.0f;

	private float movespeed;
	private float maxdistance = 50f;
	private float stunTime;
	float stunnedTime = 2f;

	private Vector3 distVec;
	private Vector3 avoidVec = Vector3.zero;
	private float distance;
	private float sqrDistance;
	private float sqrAttackDistance;
	private float sqrDangerDistance;

	private Vector3 destination;
	private Vector3 moveVec;

	void Start()
	{
		this.enemy = this.gameObject.GetComponentInChildren<Enemy>();
		this.movespeed = enemy.moveSpeed;
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.target = GameObject.Find("ZombieController").transform;

		sqrAttackDistance = Mathf.Pow(attackDistance, 2);
		sqrDangerDistance = Mathf.Pow(dangerDistance, 2);
	}

	void FixedUpdate()
	{
		UpdateDistance();

		if (this.enemy.EnemyState == EnemyState.Stunned)
		{
			this.enemyAnimator.Play("Batwolf_Stunned");
		}

		if (this.enemy.EnemyState == EnemyState.Attacking)
		{
			if (Vector3.Distance(this.destination, this.transform.position) < this.dangerDistance && Vector3.Distance(this.destination, this.transform.position) > this.attackDistance)
			{
				moveVec = distVec.normalized;
				moveVec.y = 0.0f;

				enemy.RawMovement(moveVec, true);

				this.enemyAnimator.Play("Batwolf_Walk");

			}
			else
			{
				this.Attack();
			}
		}

		if (Time.time - stunTime >= stunnedTime)
		{
			this.enemy.EnemyState = EnemyState.Attacking;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		
		if (collision.gameObject.tag == "GhostBullet")
		{
			this.enemy.EnemyState = EnemyState.Stunned;
			stunTime = Time.time;
		}
	}

	void UpdateDistance()
	{
		distVec = (destination - transform.position);
		sqrDistance = distVec.sqrMagnitude;
		destination = target.transform.position;
	}

	void Attack()
	{
		if (Vector3.Distance(this.destination, this.transform.position) < this.attackDistance)
		{
			RaycastHit hit;
			//Debug.DrawLine(transform.position, transform.right * 100, Color.green);
			if (Physics.Raycast(transform.position, transform.right, out hit))
			{
				distance = hit.distance;
				//print(distance);
				//print(hit.transform.tag);
				if (distance < maxdistance && (hit.transform.tag == "Player" || hit.transform.tag == "ActivePlayer"))
				{
					GameObject enemyhit = hit.transform.gameObject;
					enemyhit.GetComponent<HealthController>().CurHealth--;
				}
			}
			this.enemyAnimator.Play("Batwolf_Swing");
		}
		else
		{
			this.enemyAnimator.Play("Batwolf_Stand");
		}
	}
}
