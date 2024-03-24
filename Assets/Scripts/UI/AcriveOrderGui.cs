using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcriveOrderGui : MonoBehaviour
{
    public Toggle[] orderPicked;
    public Button orderCompletedBtn;
    public VoiceLineManager Task004_03;
    

    public bool OrderCompleted()
    {
        foreach (var itemPicked in orderPicked)
        {
            if (!itemPicked.isOn)
            {
                return false;
            }            
        }

        return true;
    }

    public void EnbaleCompletedOrderBtn()
    {
        orderCompletedBtn.interactable = OrderCompleted();
        Task004_03.gameObject.SetActive(OrderCompleted());
    }
}
