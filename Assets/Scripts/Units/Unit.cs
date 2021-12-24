using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitRaycaster raycaster;
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
    public const float meleeRange = 5f;
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
            state = raycaster.Get_State();
            switch (state)
            {
                case State.IDLE:
                    break;
                case State.WALK:
                    Walk();
                    break;
                case State.MELEE_ATTACK:
                    Debug.Log("Melee Attack");
                    break;
                case State.RANGED_ATTACK:
                    Debug.Log("Ranged Attack");
                    break;
                case State.WALK_ATTACK:
                    Walk();
                    Debug.Log("Walk Attack");
                    break;
            }
        }
    }

    private void Walk()
    {
        transform.position += (facing == Facing.RIGHT ? Vector3.right : Vector3.left) * Time.deltaTime * 10f;
    }

    private void FaceToLeft()
    {
        facing = Facing.LEFT;
        transform.rotation = Quaternion.Euler(Vector3.up * 180f);
    }
}
