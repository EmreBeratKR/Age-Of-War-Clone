using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private AgeController ageController;
    [SerializeField] private BaseController baseController;
    [SerializeField] private UnitSpawner unitSpawner;
    [SerializeField] private GameObject unitPanel;
    [SerializeField] private GameObject turretPanel;
    [SerializeField] private GameObject sellTurretPanel;
    [SerializeField] private Transform progressBar;
    [SerializeField] private Text infoText;
    [SerializeField] private Image[] unitSlots;
    private enum TurretingMode
    {
        PUT,
        SELL
    }
    private TurretingMode turretingMode;


#region UI Toggles 

    public void Toggle_UnitPanel(bool open)
    {
        unitPanel.SetActive(open);
    }

    public void Toggle_TurretPanel(bool open)
    {
        turretPanel.SetActive(open);
        if (!open)
        {
            baseController.CloseSpots();
        }
    }

    public void Toggle_SellTurretPanel(bool open)
    {
        sellTurretPanel.SetActive(open);
        if (open)
        {
            //baseController.OpenSpots(true);
            OpenSpotButtons(true);
        }
        else
        {
            baseController.CloseSpots();
        }
    }

#endregion

#region UI Updates

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
     
#endregion

    public void OrderUnit(int unitIndex)
    {
        if (unitSpawner.unitQueue.Count < 5)
        {
            unitSpawner.EnQueue_Unit(ageController.Get_Unit(unitIndex));
            Update_Queue();
        }
    }

    public void Evolve()
    {
        if (ageController.TryEvolve())
        {
            
        }
    }

    public void AddTurretSpot()
    {
        if (baseController.TryAddSpot())
        {

        }
    }

    public void SelectTurret(int turretIndex)
    {
        baseController.selectedTurret = turretIndex;
        OpenSpotButtons(false);
    }

    public void Turreting(int spotIndex)
    {
        baseController.spotButtons[spotIndex].SetActive(false);
        if (turretingMode == TurretingMode.PUT)
        {
            baseController.PutTurret(spotIndex);
        }
        else
        {
            baseController.SellTurret(spotIndex);
        }
    }

    public void OpenSpotButtons(bool forSale)
    {
        if (forSale)
        {
            turretingMode = TurretingMode.SELL;
        }
        else
        {
            turretingMode = TurretingMode.PUT;
        }
        baseController.OpenSpots(forSale);
    }
}
