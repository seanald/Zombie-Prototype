using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VampireRanged : Enemy {
    public GameObject can;

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
            throwPoint.RotateAround(throwPoint.position, throwPoint.up, 180f);
            this.curLocalScale = this.transform.localScale.x;
        }
    }

    override protected void Attack()
    {
        if (this.distance < this.attackDistance)
        {
            this.enemyAnimator.Play("Vampire_Melee_Attack");
            Instantiate(can, throwPoint.position, throwPoint.localRotation);
            this.state = CharacterState.Moving;
            StartCoroutine(WaitForAnimation());
        }
        else
        {
            this.Seek(distVec);
            this.enemyAnimator.Play("Vampire_Walking");
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

        this.enemyAnimator.Play("Vampire_Walking");

        if (!this.strafing)
        {
            StartCoroutine(WaitForAttack());
        }
    }

    override protected void Stunned()
    {
        this.enemyAnimator.Play("Vampire_Stunned");
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
}
