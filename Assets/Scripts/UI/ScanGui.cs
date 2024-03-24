using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScanGui : MonoBehaviour
{
    public TMP_InputField description,
                            boxQT,
                            palletQT;
    public Button printLabelBtn;

    [Header("GUI ENTRADA")]
    [SerializeField]
    public MerchLabel merchLabel;

    [Header("GUI SALIDA")]
    [SerializeField]
    public TMP_InputField orderID;
    [SerializeField]
    public GameObject outLabelPrefab;
    [SerializeField]
    public Transform outLabelSpawnPoint;



    const string glyphs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public void PrintMerchLabel(string storageCode)
    {
        /*GENERATE RANDOM PALLET ID*/
        int idLength = 8;
        string rndPalletID = null;

        for (int i = 0; i <= idLength; i++)
        {
            rndPalletID += glyphs[Random.Range(0, glyphs.Length)];
        }

        /*PRINT MERCH INFO IN MERCH LABEL*/
        merchLabel.palletID.text = rndPalletID;
        merchLabel.description.text = this.description.text;
        merchLabel.boxQT.text = this.boxQT.text;
        merchLabel.palletQT.text = this.palletQT.text;

        /*SPLIT STORAGE CODE*/
        string[] storageCodeSplit = storageCode.Split('-');

        merchLabel.aisle.text = storageCodeSplit[0];
        merchLabel.shelf.text = storageCodeSplit[1];
        merchLabel.level.text = storageCodeSplit[2];
        
    }

    public void PrintOutboundOrderLabel()
    {
        /*INSTANTIATE NEW LABEL*/
        GameObject newOutboundLabel = (GameObject)Instantiate(outLabelPrefab, outLabelSpawnPoint);
        newOutboundLabel.GetComponent<OutMerchLabel>().FillLabelData(orderID.text, description.text, boxQT.text, palletQT.text, System.DateTime.Today.AddDays(Random.Range(0, 3)));
    }

    private void Update()
    {
        if (description.text != string.Empty && boxQT.text != string.Empty && palletQT.text != string.Empty)
        {
            printLabelBtn.interactable = true;
        }
        else if (description.text == string.Empty || boxQT.text == string.Empty || palletQT.text == string.Empty)
        {
            printLabelBtn.interactable = false;
        }
    }
}
