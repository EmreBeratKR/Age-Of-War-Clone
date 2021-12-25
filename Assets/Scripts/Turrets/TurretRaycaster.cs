using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRaycaster : MonoBehaviour
{
    [SerializeField] private Turret turret;


    public void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, turret.facing == Unit.Facing.RIGHT ? Vector2.right : Vector2.left, UnitRaycaster.maxDistance);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length-1; i++)
            {
                if (turret.owner != hits[i].collider.GetComponent<Unit>().owner)
                {
                    
                }
            }
        }
    }
}