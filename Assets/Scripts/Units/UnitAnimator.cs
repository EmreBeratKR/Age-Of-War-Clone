using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Unit unit;


    public void Idle()
    {
        animator.SetBool("isWalk", false);
        animator.SetBool("isMelee", false);
        if (unit.type == Unit.UnitType.RANGED)
        {
            animator.SetBool("isRangedAttack", false);
            animator.SetBool("isWalkAttack", false);
        }
    }

    public void Walk()
    {
        animator.SetBool("isWalk", true);
        animator.SetBool("isMelee", false);
        if (unit.type == Unit.UnitType.RANGED)
        {
            animator.SetBool("isRangedAttack", false);
            animator.SetBool("isWalkAttack", false);
        }
    }

    public void Melee()
    {
        unit.attackState = Unit.AttackState.ATTACKING;
        animator.SetBool("isMelee", true);
        animator.SetBool("isWalk", false);
        if (unit.type == Unit.UnitType.RANGED)
        {
            animator.SetBool("isRangedAttack", false);
            animator.SetBool("isWalkAttack", false);
        }
    }

    public void Ranged()
    {
        unit.attackState = Unit.AttackState.ATTACKING;
        animator.SetBool("isRangedAttack", true);

        animator.SetBool("isWalk", false);
        animator.SetBool("isMelee", false);
        animator.SetBool("isWalkAttack", false);
    }

    public void WalkAttack()
    {
        unit.attackState = Unit.AttackState.ATTACKING;
        animator.SetBool("isWalkAttack", true);

        animator.SetBool("isWalk", false);
        animator.SetBool("isMelee", false);
        animator.SetBool("isRangedAttack", false);
    }

    public void OnAttackEnd()
    {
        unit.attackState = Unit.AttackState.DONE;
    }

    public void OnDamage()
    {
        if (unit.raycaster.opponentBase != null)
        {
            unit.raycaster.opponentBase.DealDamage(unit.damage);
        }
        else
        {
            unit.raycaster.target.DealDamage(unit.damage);
        }
    }
}
