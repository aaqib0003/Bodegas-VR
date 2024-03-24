using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutbounPalletInfo : PalletInfo
{
    public string orderID;

    public void OutScanned()
    {
        this.LabelSlot.SetActive(true);
    }
}
