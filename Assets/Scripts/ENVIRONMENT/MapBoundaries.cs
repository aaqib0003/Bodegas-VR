using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundaries : MonoBehaviour
{
    //BarScan Inventory socket
    public Transform BarScanSocket;

    //BarSacn GameObject
    public GameObject BarScanObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BAR_SCAN")
        {
            BarScanObj.transform.position = BarScanSocket.position;

        }
        else if (other.gameObject.tag == "OUT_MERCH_LABEL")
        {
            Debug.Log(other.gameObject.name + " destroyed.");
            Destroy(other.gameObject);
        }
    }
}
