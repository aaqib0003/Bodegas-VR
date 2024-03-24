using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutMerchLabel : MonoBehaviour
{
    public float destroyTime = 5.0f;
    private float destroyTimePriv;

    public TextMeshProUGUI orderID,
                           description,
                           boxQT,
                           palletQT,
                           monthDelivery,
                           dayDelivery,
                           yearDelivery;

    public GameObject OutLabelIndicator;

    private void Start()
    {
        OutLabelIndicator = GameObject.FindGameObjectWithTag("OUT_LABEL_INDICATOR");
        OutLabelIndicator.SetActive(true);
    }

    public void FillLabelData(string newOrderId, string newDesc, string newBoxQT, string newPalletQT, System.DateTime newDeliveryDate)
    {
        orderID.text = newOrderId;
        description.text = newDesc;
        boxQT.text = newBoxQT;
        palletQT.text = newPalletQT;

        /* DELIVERY DATE */
        monthDelivery.text = newDeliveryDate.Month.ToString("00");
        dayDelivery.text = newDeliveryDate.Day.ToString("00");
        yearDelivery.text = newDeliveryDate.Year.ToString();
    }

    /*DESTROY IF STAYS ON THE GROUND*/
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            destroyTimePriv -= 1.0f * Time.deltaTime;

            if (destroyTimePriv <= 0.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            destroyTimePriv = destroyTime;
        }
    }
    
    public void DisableIndicator()
    {
        OutLabelIndicator.SetActive(false);
    }
}
