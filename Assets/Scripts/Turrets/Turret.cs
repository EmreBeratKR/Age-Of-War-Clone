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
        transform.rotation = Quaternion.Euler(Vector3.up * 180f);
    }
}
