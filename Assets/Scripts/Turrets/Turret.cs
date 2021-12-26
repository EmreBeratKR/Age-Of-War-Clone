using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretRaycaster raycaster;
    public enum TurretType
    {
        THROWER,
        CATAPULT,
        SPILL
    }
    public string Name;
    public TurretType type;
    public Unit.Owner owner;
    public Unit.Facing facing;
    public int cost;
    public float range;






    private void FaceToLeft()
    {
        facing = Unit.Facing.LEFT;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
    }
}
