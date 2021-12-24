using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    public Queue<GameObject> unitQueue;
    private GameObject currentUnit;
    private float trainStart = -1f;


    private void Start()
    {
        unitQueue = new Queue<GameObject>();
    }

    private void Update()
    {
        TrainUnit();
    }

    private void TrainUnit()
    {
        if (currentUnit == null)
        {
            if (unitQueue.Count > 0)
            {
                currentUnit = unitQueue.Dequeue();
                sceneController.Update_Queue();
            }
        }
        else
        {
            if (trainStart == -1f)
            {
                trainStart = Time.time;
            }
            else
            {
                float elapsedTime = Time.time - trainStart;
                Unit unit = currentUnit.GetComponent<Unit>();
                sceneController.Update_Progressbar(elapsedTime / unit.trainDuration);
                if ((elapsedTime) >= unit.trainDuration)
                {
                    SpawnUnit();
                    currentUnit = null;
                    trainStart = -1f;
                    sceneController.Update_Progressbar(0f);
                }
            }
        }
    }

    private void SpawnUnit()
    {
        Instantiate(currentUnit, transform.position, Quaternion.identity, transform);
    }

    public void EnQueue_Unit(GameObject unit)
    {
        unitQueue.Enqueue(unit);
    }
}
