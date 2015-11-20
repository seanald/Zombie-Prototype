using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VampireBoss : Enemy {

    private bool isBat = false;

    void IsFeared()
    {
        this.state = CharacterState.Fleeing;
    }

    override protected void Attack()
    {
        int random = Random.Range(1, 4);

        if (this.distance < this.attackDistance)
        {
            if (!this.attacking)
            {
                if (isBat == true)
                {
                    this.BattoVampire();
                    StartCoroutine(WaitForAnimation());
                }
                else
                {
                    if (random == 1)
                    {
                        this.VampireSummon();
                        StartCoroutine(WaitForAnimation());
                    }
                    if (random == 2)
                    {
                        this.VampireHypnotize();
                        StartCoroutine(WaitForAnimation());
                    }
                    if (random == 3)
                    {
                        this.VampiretoBat();
                        StartCoroutine(WaitForAnimation());
                    }
                    if (random == 4)
                    {
                        this.VampiretoBat();
                        StartCoroutine(WaitForAnimation());
                    }
                }
            }
            else
            {
                base.Seek(distVec);
                if (isBat == true)
                {
                    this.enemyAnimator.Play("Boss_Vampire_Bat_Form");
                }
                else if (isBat == false)
                {
                    this.enemyAnimator.Play("Boss_Vampire_Moving");
                }
            }
        }
    }

    private void VampireSummon()
    {
        this.enemyAnimator.Play("Boss_Vampire_Summon");
        this.attacking = true;
    }

    private void VampireHypnotize()
    {
        this.enemyAnimator.Play("Boss_Vampire_Hypnotize");
        this.attacking = true;
    }

    private void VampiretoBat()
    {
        this.enemyAnimator.Play("Boss_Vampire_To_Bat");
        isBat = true;
        this.attacking = true;
    }

    private void BattoVampire()
    {
        this.enemyAnimator.Play("Boss_Vampire_Bat_To_Vampire");
        isBat = false;
        this.attacking = true;
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

        if (isBat == true)
        {
            this.enemyAnimator.Play("Boss_Vampire_Bat_Form");
        }
        else if (isBat == false)
        {
            this.enemyAnimator.Play("Boss_Vampire_Moving");
        }
        

        if (!this.strafing)
        {
            StartCoroutine(WaitForAttack());
        }
    }

    override protected void Stunned()
    {

    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        this.attacking = false;
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
