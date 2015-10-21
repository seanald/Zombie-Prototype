using UnityEngine;
using System.Collections;

public class BaseballWolfMovement : MonoBehaviour
{
	private Animator enemyAnimator;
	private Enemy enemy;
	private Transform target;
	public float attackDistance = 80.0f;
	public float dangerDistance = 500.0f;
	public float attackRate = 10.0f;

	private float attackCooldown = 10.0f;
	private float maxdistance = 50f;
	private float stunTime;
	private float stunnedTime = 2f;
	private Vector3 distVec;
	private Vector3 avoidVec = Vector3.zero;
	private float distance;
	private float sqrDistance;
	private float sqrAttackDistance;
	private float sqrDangerDistance;
	private float strafeDir = 1.0f;
	private Vector3 destination;
	private Vector3 moveVec;
	private bool strafing;

	void Start()
	{
		this.enemy = this.gameObject.GetComponentInChildren<Enemy>();
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.target = GameObject.Find("ZombieController").transform;

		this.attackCooldown = this.attackRate;

		sqrAttackDistance = Mathf.Pow(attackDistance, 2);
		sqrDangerDistance = Mathf.Pow(dangerDistance, 2);

		InvokeRepeating("UpdateStrafeDir", 2, 2);
	}

	void FixedUpdate()
	{
		UpdateDistance();

		if (this.enemy.EnemyState == EnemyState.Stunned)
		{
			this.enemyAnimator.Play("Batwolf_Stunned");
			if (Time.time - stunTime >= stunnedTime)
			{
				this.enemy.EnemyState = EnemyState.Attacking;
			}
		}

		if (this.enemy.EnemyState == EnemyState.Attacking)
		{
			if (Vector3.Distance(this.destination, this.transform.position) < this.dangerDistance && Vector3.Distance(this.destination, this.transform.position) > this.attackDistance)
			{
				this.MoveIn();
			}
			else
			{
				this.Attack();
			}
		}

		if (this.enemy.EnemyState == EnemyState.IsFeared)
		{

		}
		else if (this.enemy.EnemyState == EnemyState.Strafing)
		{
			Strafe();
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
		destination = target.transform.position;
		distVec = (destination - transform.position);

		distance = distVec.magnitude;
		sqrDistance = distVec.sqrMagnitude;
	}

	void IsFeared()
	{
		this.enemy.EnemyState = EnemyState.IsFeared;
	}

	void Seek(Vector3 distVec, bool align)
	{
		if (this.enemy.GetForce() != Vector3.zero)
			return;

		destination = this.target.transform.position;
		moveVec = distVec.normalized;
		moveVec.y = 0.0f;

		this.enemy.RawMovement(moveVec, align);
	}

	void MoveIn()
	{
		moveVec = distVec.normalized;
		moveVec.y = 0.0f;

		enemy.RawMovement(moveVec, true);

		this.enemyAnimator.Play("Batwolf_Walk");
	}

	void Attack()
	{
		if (this.distance < this.attackDistance)
		{
			RaycastHit hit;
			//Debug.DrawLine(transform.position, transform.right * 100, Color.green);
			if (Physics.Raycast(transform.position, transform.right, out hit))
			{
				//print(distance);
				//print(hit.transform.tag);
				if (hit.transform.tag == "Player" || hit.transform.tag == "ActivePlayer")
				{
					GameObject enemyhit = hit.transform.gameObject;
					enemyhit.GetComponent<HealthController>().CurHealth--;
					this.enemyAnimator.Play("Batwolf_Swing");
					StartCoroutine(WaitForAnimation());
				}
			}

		}
	}

	IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(1);
		this.Strafe();
	}

	IEnumerator WaitForAttack()
	{
		this.strafing = true;
		yield return new WaitForSeconds(this.attackRate);
		this.enemy.EnemyState = EnemyState.Attacking;
		this.strafing = false;
	}

	void Strafe()
	{
		Vector3 perpendicularVec;
		if (this.sqrDistance >= this.sqrDangerDistance)
		{
			this.MoveIn();
		}

		this.enemy.EnemyState = EnemyState.Strafing;
		if (this.sqrDistance < this.sqrDangerDistance)
		{
			perpendicularVec = Vector3.MoveTowards(this.transform.position * -1, this.target.transform.position, this.sqrDangerDistance);
		}
		else
		{
			perpendicularVec = Vector3.Cross(Vector3.up, this.target.transform.position);
		}

		this.Seek(perpendicularVec * this.strafeDir, false);
		this.enemyAnimator.Play("Batwolf_Walk");

		if (!this.strafing)
		{
			StartCoroutine(WaitForAttack());
		}
	}

	void UpdateStrafeDir()
	{
		this.strafeDir *= -1.0f;
	}
}
