using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeController : MonoBehaviour
{
    public int currentAge;
    public GameObject[][] unitSets;
    public GameObject[][] turretSets;
    public GameObject[] firstAgeUnits;
    public GameObject[] firstAgeTurrets;


    private void Awake()
    {
        unitSets = new GameObject[][]
        {
            firstAgeUnits
        };
        turretSets = new GameObject[][]
        {
            firstAgeTurrets
        };
    }

    public GameObject Get_Unit(int unitIndex)
    {
        return unitSets[currentAge][unitIndex];
    }

    public GameObject Get_Turret(int turretIndex)
    {
        return turretSets[currentAge][turretIndex];
    }

    public bool TryEvolve()
    {
        if (currentAge < 4)
        {
            currentAge++;
            return true;
        }
        return false;
    }
}
