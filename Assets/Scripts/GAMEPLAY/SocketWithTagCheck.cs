using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck : XRSocketInteractor
{
    public string targetTag = string.Empty;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchTargetTag(interactable);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchTargetTag(interactable);
    }

    private bool MatchTargetTag (XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }

    public void WhatIsHolding()
    {
        Debug.Log(this.name + " is holding" + selectTarget.name + " with tag " + selectTarget.tag);
    }
}
