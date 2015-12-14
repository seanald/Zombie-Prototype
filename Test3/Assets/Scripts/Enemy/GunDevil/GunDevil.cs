using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunDevil : Enemy {

    public GameObject bullet;

    public Transform throwPoint;
    private float curLocalScale;

	// Use this for initialization
	void Start () {
        base.Start();
        this.curLocalScale = this.transform.localScale.x; 
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        base.FixedUpdate();

        if(this.transform.localScale.x != curLocalScale)
        {
            throwPoint.RotateAround(throwPoint.position, throwPoint.up, 180f);
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

    protected override void Attack()
    {
        if(this.distance < this.attackDistance)
        {
            this.enemyAnimator.Play("Devil_Gun_Attack");
            Instantiate(bullet, throwPoint.position, throwPoint.localRotation);
            this.state = CharacterState.Moving;
            StartCoroutine(WaitForAnimation());
        }
        else
        {
            this.Seek(distVec);
            this.enemyAnimator.Play("Devil_Gun_Walk");
        }
    }

    protected override void Move()
    {
        if(this.distance >= this.dangerDistance + 50)
        {
            this.Seek(this.distVec);
        }


        if (this.distance < this.dangerDistance - 50)
        {
            this.Seek(this.distVec * -1);
        }

        this.enemyAnimator.Play("Devil_Gun_Walk");

        if (!this.strafing)
        {
            StartCoroutine(WaitForAttack());
        }
    }

    override protected void Stunned()
    {
        this.enemyAnimator.Play("Devil_Gun_Stunned");
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
        yield return new WaitForSeconds(1f);
        this.Move();
    }

	IEnumerator WaitForHauntEnd()
	{
		yield return new WaitForSeconds(3f);
		this.target = GameObject.Find("ZombieController").transform;
		this.state = CharacterState.Attacking;
	}
}

