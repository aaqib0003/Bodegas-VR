using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchLabel : MonoBehaviour
{
    public TextMeshProUGUI  palletID, 
                            description, 
                            boxQT, 
                            palletQT, 
                            aisle, 
                            shelf, 
                            level;

    public Transform spawnPoint;

    public void ResetPosition()
    {
        this.transform.position = spawnPoint.transform.position;
        this.transform.rotation = spawnPoint.transform.rotation;
    }
}
