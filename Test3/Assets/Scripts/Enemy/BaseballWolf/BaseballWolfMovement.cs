using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseballWolfMovement : Enemy
{
    AudioSource swingAttack; 
    private bool isRunning = false;
    public float startingTime = 2;
    private float countingTime;

    void Awake()
    {
        swingAttack = GetComponent<AudioSource>(); 
    }
	void Start()
	{
        countingTime = startingTime;

		base.Start();
		this.state = CharacterState.Attacking;
		this.enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
		this.target = GameObject.Find("ZombieController").transform;

		this.attackCooldown = this.attackRate;

		sqrAttackDistance = Mathf.Pow(attackDistance, 2);
		sqrDangerDistance = Mathf.Pow(dangerDistance, 2);

		this.stunTime = this.stunnedTime;
	}

	void FixedUpdate()
	{
		base.FixedUpdate();
		UpdateDistance();

        countingTime -= Time.deltaTime;

		Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
		this.enemyList = new List<Enemy>(enemies);
		this.enemyList.Remove((Enemy)this);

		if (this.state == CharacterState.Stunned)
		{
			this.enemyAnimator.Play("Batwolf_Stunned");
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
			Strafe();
		}
		else if (this.state == CharacterState.Moving)
		{
			Strafe();
		}
	}

	void IsFeared()
	{
		this.state = CharacterState.Fleeing;
	}

	void TakeDamage()
	{
		this.GetComponent<Health>().CurHealth -= 50;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "GhostBullet")
		{
			this.state = CharacterState.Stunned;
			stunTime = Time.time;
		}
	}

	void UpdateDistance()
	{
		if (this.state == CharacterState.Fleeing)
		{
			destination = target.transform.position * -1;
		}
		else
		{
			destination = target.transform.position;
		}
		distVec = (destination - transform.position);

		distance = distVec.magnitude;
		sqrDistance = distVec.sqrMagnitude;
	}

	public void Seek(Vector3 distVec)
	{
		if (this.velocity != Vector3.zero)
			return;

		Vector3 movement = distVec.normalized;
		movement.y = 0.0f;

		this.RawMovement(movement);
		this.enemyAnimator.Play("Batwolf_Walk");
	}

	void Attack()
	{
		if (this.distance < this.attackDistance)
		{
			//TODO: Align vertically with player on left or right side
            if(countingTime <= 0)
            {
                swingAttack.Play();
                countingTime = startingTime;
            }
			this.enemyAnimator.Play("Batwolf_Swing");
            

            StartCoroutine(WaitForAnimation());
		}
		else
		{
			this.Seek(distVec);
		}
	}

	IEnumerator WaitForAnimation()
	{
		yield return new WaitForSeconds(this.enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
        this.Strafe();
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

	void Strafe()
	{
		this.state = CharacterState.Standing;
		if (this.distance >= this.dangerDistance + 50)
		{
			this.Seek(this.distVec);
		}

		if (this.distance < this.dangerDistance - 50)
		{
			this.Seek(this.distVec * -1);
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

		//this.Seek(perpendicularVec * this.strafeDir, false);
		this.enemyAnimator.Play("Batwolf_Walk");

		if (!this.strafing)
		{
			StartCoroutine(WaitForAttack());
		}
	}

	private bool checkForOtherAttackers()
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
}
