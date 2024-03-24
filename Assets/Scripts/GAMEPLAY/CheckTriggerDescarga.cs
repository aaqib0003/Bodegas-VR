using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CheckTriggerDescarga : MonoBehaviour {

    public int boxinCollider = 0;
    public TMP_Text pesoBalanza;
    public GameObject butonImprimir;
    public GameObject prefabDoc;
    public Transform postDocumento;
    private LoadedPalletInfo loadedPalletInfo;



    public virtual void OnTriggerEnter(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE")) {
            GameObject gameObjectCollider = other.gameObject;
            loadedPalletInfo = gameObjectCollider.GetComponent<LoadedPalletInfo>();
            pesoBalanza.text = loadedPalletInfo.peso;

            butonImprimir.SetActive(true);

            boxinCollider++;
        }
    }

    public virtual void OnTriggerExit(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE")) {
            pesoBalanza.text = "0.";
            boxinCollider--;
            butonImprimir.SetActive(false);

        }
    }

    public void imprimirDocumento() {

        GameObject recibo = Instantiate(prefabDoc, postDocumento.position, postDocumento.rotation);
        MerchLabel reciboLabels = recibo.GetComponent<MerchLabel>();

        reciboLabels.aisle.text = "03";
        reciboLabels.shelf.text = "E";
        reciboLabels.level.text = "02";

        reciboLabels.boxQT.text = loadedPalletInfo.peso;
        reciboLabels.description.text = loadedPalletInfo.description;
        reciboLabels.palletQT.text = loadedPalletInfo.destino;

       
    }
    
}
