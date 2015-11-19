using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VampireMelee : Enemy
{
	void IsFeared()
    {
        this.state = CharacterState.Fleeing;
    }

    override protected void Attack()
    {
        if (this.distance < this.attackDistance)
        {
            this.enemyAnimator.Play("Vampire_Melee_Attack");
            StartCoroutine(WaitForAnimation());
        }
        else
        {
            base.Seek(distVec);
            this.enemyAnimator.Play("Vampire_Walking");
        }
    }

    override protected void Move()
    {
        this.state = CharacterState.Moving;
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

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        this.Move();
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
}
