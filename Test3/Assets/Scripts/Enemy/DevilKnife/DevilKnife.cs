using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevilKnife : Enemy {
    

    void IsFeared()
    {
        this.state = CharacterState.Fleeing;
    }

    protected override void Attack()
    {
        if (this.distance < this.attackDistance)
        {
            this.enemyAnimator.Play("Devil_Knife_Attack");
            StartCoroutine(WaitForAnimation());
        }
        else
        {
            base.Seek(distVec);
            this.enemyAnimator.Play("Devil_Knife_Walk");
        }
    }

    protected override void Move()
    {
        this.state = CharacterState.Moving;
        if(this.distance >= this.dangerDistance + 50)
        {
            this.Seek(this.distVec);
        }

        if (this.distance < this.dangerDistance - 50)
        {
            this.Seek(this.distVec * -1);
        }

        this.enemyAnimator.Play("Devil_Knife_Walk");

        if (!this.strafing)
        {
            StartCoroutine(WaitForAttack());
        }
    }

    protected override void Stunned()
    {
        this.enemyAnimator.Play("Devil_Knife_Stunned");
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
