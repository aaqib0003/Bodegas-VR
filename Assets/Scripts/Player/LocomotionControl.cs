using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionControl : MonoBehaviour
{
    public XRController rightTeleportRay;
    public InputHelpers.Button teleporActivationButton;
    public float activationThreshold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (rightTeleportRay)
        {
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleporActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
