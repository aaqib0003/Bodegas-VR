using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerXRRig;
    public XRController leftHandController, rightHandController;

    [Header("Task Tracker")]
    public Task currentTask;
    public TextMeshProUGUI displayTaskText;

    [Header("Mini map GUI usage")]
    public GameObject mapGui;
    public bool isMapDisplaying;

    [Header("To remember controls GUI")]
    public GameObject controlsGui;
    public bool isControlsGuiDisplaying;

    [Header("Barcode scanner and inventory")]
    public GameObject BarScan;
    public Transform inventoryAttach;

    /*PRIMARY BUTTON*/
    private bool primaryCanBePressed_L = true;
    /*SECONDARY BUTTON*/
    private bool secondaryCanBePressed_L = true;
    private bool secondaryCanBePressed_R = true;

    public void DisplayTaskOnUI()
    {
        displayTaskText.text = currentTask.taskDescription;
    }

    public void TeleportPlayer(Transform destination)
    {
        playerXRRig.transform.position = destination.position;
        playerXRRig.transform.rotation = destination.rotation;
    }


    private void Update()
    {
        //Abrrir el mini mapa
        if (leftHandController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonPress))
        {
            if (primaryButtonPress)
            {
                if (primaryCanBePressed_L)
                {
                    mapGui.SetActive(!mapGui.gameObject.activeSelf);
                    primaryCanBePressed_L = false;
                }
            }
            else if (!primaryButtonPress)
            {
                primaryCanBePressed_L = true;
            }
        }

        //Recuperar el scanner
        if (leftHandController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonPress_L))
        {
            if (secondaryButtonPress_L)
            {
                if (secondaryCanBePressed_L)
                {
                    BarScan.transform.position = inventoryAttach.position;
                    secondaryCanBePressed_L = false;
                }
            }
            else if (!primaryButtonPress)
            {
                secondaryCanBePressed_L = true;
            }
        }

        //Abrir recordar controles
        if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonPress_R))
        {
            if (secondaryButtonPress_R)
            {
                if (secondaryCanBePressed_R)
                {
                    controlsGui.SetActive(!controlsGui.gameObject.activeSelf);
                    secondaryCanBePressed_R = false;
                }
            }
            else if (!secondaryButtonPress_R)
            {
                secondaryCanBePressed_R = true;
            }
        }
    }

    public void BringScannerToInventory()
    {
        BarScan.transform.position = inventoryAttach.position;
    }

    public void setCurrentTask(Task current) {
        currentTask = current;

    }
}
