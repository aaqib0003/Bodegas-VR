using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketOrderIDCheck : XRSocketInteractor
{
    public OutbounPalletInfo outPalletInfo;

    private bool MatchOutOrderID (XRBaseInteractable interactable)
    {
        if (interactable.gameObject.tag == "OUT_MERCH_LABEL")
        {
            if (interactable.gameObject.GetComponent<OutMerchLabel>().orderID.text == outPalletInfo.orderID)
            {
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }
        
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchOutOrderID(interactable);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchOutOrderID(interactable); 
    }

}
