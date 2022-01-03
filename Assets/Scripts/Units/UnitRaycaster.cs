using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRaycaster : MonoBehaviour
{
    [SerializeField] private Unit unit;
    public const float maxDistance = 500f;
    public Unit target;
    public BaseController opponentBase;


    public Unit.State Get_State()
    {
        target = null;
        opponentBase = null;
        if (unit.type == Unit.UnitType.RANGED)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, unit.facing == Unit.Facing.RIGHT ? Vector2.right : Vector2.left, maxDistance);
            Debug.DrawLine(transform.position, transform.position + Vector3.right * maxDistance, Color.magenta, Time.fixedDeltaTime);
            if (hits.Length > 0)
            {
                RaycastHit2D firstFellow = hits[0];
                RaycastHit2D firstEnemy = hits[0];
                RaycastHit2D enemyBase = hits[hits.Length-1];
                bool found_FirstFellow = false;
                bool found_FirstEnemy = false;
                for (int i = 0; i < hits.Length-1; i++)
                {
                    if (hits[i].collider.gameObject != unit.gameObject)
                    {
                        if (!found_FirstFellow && unit.owner == hits[i].collider.GetComponent<Unit>().owner)
                        {
                            firstFellow = hits[i];
                            found_FirstFellow = true;
                        }
                        if (!found_FirstEnemy && unit.owner != hits[i].collider.GetComponent<Unit>().owner)
                        {
                            firstEnemy = hits[i];
                            found_FirstEnemy = true;
                        }
                    }
                    if (found_FirstEnemy)
                    {
                        break;
                    }
                }

                if (found_FirstFellow)
                {
                    if (found_FirstEnemy)
                    {
                        if (RangedUnit.attackRange >= firstEnemy.distance)
                        {
                            target = firstEnemy.collider.GetComponent<Unit>();
                            return Unit.meleeRange >= firstFellow.distance ? Unit.State.RANGED_ATTACK : Unit.State.WALK_ATTACK;
                        }
                        return Unit.meleeRange >= firstFellow.distance ? Unit.State.IDLE : Unit.State.WALK;
                    }
                    if (RangedUnit.attackRange >= enemyBase.distance)
                    {
                        opponentBase = enemyBase.collider.GetComponent<BaseController>();
                        return Unit.meleeRange >= firstFellow.distance ? Unit.State.RANGED_ATTACK : Unit.State.WALK_ATTACK;
                    }
                    return Unit.meleeRange >= firstFellow.distance ? Unit.State.IDLE : Unit.State.WALK;
                }
                if (found_FirstEnemy)
                {
                    target = firstEnemy.collider.GetComponent<Unit>();
                    if (Unit.meleeRange >= firstFellow.distance)
                    {
                        return Unit.State.MELEE_ATTACK;
                    }
                    return RangedUnit.attackRange >= firstEnemy.distance ? Unit.State.WALK_ATTACK : Unit.State.WALK;
                }
                opponentBase = enemyBase.collider.GetComponent<BaseController>();
                if (Unit.meleeRange >= enemyBase.distance)
                {
                    return Unit.State.MELEE_ATTACK;
                }
                return RangedUnit.attackRange >= enemyBase.distance ? Unit.State.WALK_ATTACK : Unit.State.WALK;
            }
            return Unit.State.WALK;
        }
        else
        {    
            RaycastHit2D hit = Physics2D.Raycast(transform.position, unit.facing == Unit.Facing.RIGHT ? Vector2.right : Vector2.left, maxDistance);
            if (hit && hit.collider.gameObject != unit.gameObject)
            {
                GameObject tar = hit.collider.gameObject;
                switch (tar.tag)
                {
                    case "Unit":
                    {
                        Unit targetUnit = tar.GetComponent<Unit>();
                        if (Unit.meleeRange < hit.distance)
                        {
                            return Unit.State.WALK;
                        }
                        if (unit.owner == targetUnit.owner)
                        {
                            return Unit.State.IDLE;
                        }
                        target = targetUnit;
                        return Unit.State.MELEE_ATTACK;
                    }
                    case "Base":
                    {
                        if (Unit.meleeRange >= hit.distance)
                        {
                            opponentBase = tar.GetComponent<BaseController>();
                            return Unit.State.MELEE_ATTACK;
                        }
                        return Unit.State.WALK;
                    }
                }
            }
            return Unit.State.WALK;
        }
    }
}
