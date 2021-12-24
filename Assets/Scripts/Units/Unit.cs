using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Owner
    {
        PLAYER,
        COMPUTER
    }
    public enum State
    {
        IDLE,
        WALK,
        ATTACK
    }
    public enum AttackState
    {
        DONE,
        ATTACKING,
        CANCELED
    }
    public Owner owner;
    public State state;
    public AttackState attackState;
    public int cost;
    public int health;
    public int damage;
    public float range;
    public float attackDuration;
    public float trainDuration;


    private void FixedUpdate()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        if (attackState != AttackState.ATTACKING)
        {
            switch (state)
            {
                case State.IDLE:
                    
                    break;
                case State.WALK:
                    Walk();
                    break;
                case State.ATTACK:
                    
                    break;
            }
        }
    }

    private void Walk()
    {
        transform.position += Vector3.right * Time.deltaTime * 10f;
    }
}
