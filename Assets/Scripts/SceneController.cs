using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private UnitSpawner unitSpawner;
    [SerializeField] private GameObject unitPanel;
    [SerializeField] private GameObject turretPanel;
    [SerializeField] private GameObject sellTurretPanel;
    [SerializeField] private Transform progressBar;
    [SerializeField] private Text infoText;
    [SerializeField] private Image[] unitSlots;


#region UI Toggles 

    public void Toggle_UnitPanel(bool open)
    {
        unitPanel.SetActive(open);
    }

    public void Toggle_TurretPanel(bool open)
    {
        turretPanel.SetActive(open);
    }

    public void Toggle_SellTurretPanel(bool open)
    {
        sellTurretPanel.SetActive(open);
    }

#endregion

    public void Update_Queue()
    {
        for (int c = 0; c < unitSlots.Length; c++)
        {
            if ((c+1) <= unitSpawner.unitQueue.Count)
            {
                unitSlots[c].color = Color.red;
            }
            else
            {
                unitSlots[c].color = Color.white;
            }
        }
    }
    
    public void Update_Progressbar(float progressRate)
    {
        progressBar.localScale = new Vector3(progressRate, 1f, 1f);
    }

    public void Update_InfoText(string text)
    {
        infoText.text = text;
    }

    public void OrderUnit(GameObject unit)
    {
        if (unitSpawner.unitQueue.Count < 5)
        {
            unitSpawner.EnQueue_Unit(unit);
            Update_Queue();
        }
    }
}
