using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{
    private void OnEnable()
    {
        type = UnitType.MELEE;
    }
}
