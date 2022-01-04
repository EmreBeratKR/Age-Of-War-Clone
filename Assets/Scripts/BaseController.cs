using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private AgeController ageController;
    [SerializeField] private Transform healthBar;
    [SerializeField] private Unit.Owner owner;
    public Transform[] spots;
    public GameObject[] spotButtons;
    public int spotCount;
    public int selectedTurret;
    public int gold;
    public int experience;
    public const float startHealth = 2000f;
    private int health;


    private void Start()
    {
        health = (int) startHealth;
    }

    private void Update_HealthBar()
    {
        healthBar.localScale = new Vector3(health/startHealth, 1f, 1f);
    }

    public void OpenSpots(bool forSale)
    {
        for (int i = 0; i < spotCount; i++)
        {
            if (spots[i].childCount == 0)
            {
                spotButtons[i].SetActive(!forSale);
            }
            else
            {
                spotButtons[i].SetActive(forSale);
            }
        }
    }

    public void CloseSpots()
    {
        foreach (var button in spotButtons)
        {
            button.SetActive(false);
        }
    }

    public bool TryAddSpot()
    {
        if (spotCount < 4)
        {
            spotCount++;
            return true;
        }
        return false;
    }

    public void PutTurret(int spotIndex)
    {
        if (spots[spotIndex].childCount == 0)
        {
            Instantiate(ageController.Get_Turret(selectedTurret), spots[spotIndex].position, Quaternion.identity, spots[spotIndex]);
        }
    }

    public void SellTurret(int spotIndex)
    {
        if (spots[spotIndex].childCount != 0)
        {
            Destroy(spots[spotIndex].GetChild(0).gameObject);
        }
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
        Update_HealthBar();
    }
}
