using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletInfo : MonoBehaviour
{
    [Header("Información de la carga")]
    public string description;

    public string boxQuantity;

    public string palletQuantity;

    public GameObject LabelSlot;

    public bool isScanned = false;

    /* METHODS */
    public void OnScanned()
    {
        if (!isScanned)
        {
            PlayerManager playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            if (playerManager.currentTask != null)
            {
                if (playerManager.currentTask.isActive)
                {
                    if (playerManager.currentTask.taskID == "001")
                    {
                        /*TASK_001: COMPLETED WHEN ANY MERCH HAS BEEN SCANNED ONCE*/
                        playerManager.currentTask.TaskCompleted();
                    }
                }
            }
            

            isScanned = true;
            LabelSlot.SetActive(true);
        }
    }

}
