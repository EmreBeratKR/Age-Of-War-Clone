using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitAnimator animator;
    public UnitRaycaster raycaster;
    public enum UnitType
    {
        MELEE,
        RANGED,
        RIDER
    }
    public enum Owner
    {
        PLAYER,
        COMPUTER
    }
    public enum State
    {
        IDLE,
        WALK,
        MELEE_ATTACK,
        RANGED_ATTACK,
        WALK_ATTACK
    }
    public enum AttackState
    {
        DONE,
        ATTACKING,
        CANCELED
    }
    public enum Facing
    {
        RIGHT,
        LEFT
    }
    public string Name;
    public UnitType type;
    public Facing facing;
    public Owner owner;
    public State state;
    public AttackState attackState;
    public int cost;
    public int health;
    public int damage;
    public const float meleeRange = 4f;
    public float trainDuration;


    private void FixedUpdate()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        state = raycaster.Get_State();
        switch (state)
        {
            case State.IDLE:
                animator.Idle();
                break;
            case State.WALK:
                Walk();
                animator.Walk();
                break;
            case State.MELEE_ATTACK:
                animator.Melee();
                break;
            case State.RANGED_ATTACK:
                animator.Ranged();
                break;
            case State.WALK_ATTACK:
                Walk();
                animator.WalkAttack();
                break;
        }
    }

    private void Walk()
    {
        transform.position += (facing == Facing.RIGHT ? Vector3.right : Vector3.left) * Time.deltaTime * 10f;
    }

    private void FaceToLeft()
    {
        facing = Facing.LEFT;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
    }

    private void Die()
    {
        Debug.Log(Name + " Dead!");
        Destroy(gameObject);
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}
