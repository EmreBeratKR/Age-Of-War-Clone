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
    }

    public void Walk()
    {
        animator.SetBool("isWalk", true);
    }

    public void Melee()
    {
        unit.attackState = Unit.AttackState.ATTACKING;
        animator.SetTrigger("Melee");
    }

    public void OnMeleeEnd()
    {
        unit.attackState = Unit.AttackState.DONE;
    }
}
