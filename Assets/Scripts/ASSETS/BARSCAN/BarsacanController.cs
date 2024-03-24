using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BarsacanController : MonoBehaviour
{
    public XRGrabInteractable BarScanGrab;
    public GameObject LaserBeam;
    public GameObject ScanGUI;
    public GameObject ScanConfirmGUI;
    public bool pickedOnce;
    public Task Task001;

    [Header("Para regresar al inventario.")]
    public float returnTime = 5.0f;
    private float returnTimePriv;
    public Transform inventorySocket;

    [Header("GUI - Bahia entrada")]
    public TMP_InputField descriptionTF;
    public TMP_InputField boxQtTf;
    public TMP_InputField palletQtTf;

    [Header("GUI - Bahia salida")]
    public TMP_InputField orderIDTFOut;
    public TMP_InputField descriptionTFOut;
    public TMP_InputField boxQtTfOut;
    public TMP_InputField palletQtTfOut;

    [Header("GUI - Scan")]
    public TMP_Text scanPeso;
    public TMP_Text scanTamano;
    public TMP_Text scanFechaVence;
    public TMP_Text scanOrigen;
    public TMP_Text scanDestino;
    public TMP_Text scanPrecio;
    public TMP_Text scanDescripcion;

    [Header("GUI - Tablet")]
    public TMP_Text texMalEstado;


    public void EnableLaser()
    {
        if (BarScanGrab.selectingInteractor.tag == "HAND_CONTROLLER")
        {
            LaserBeam.SetActive(true);
            //ScanGUI.SetActive(true);
        }
    }

    public void Scan()
    {
        LaserBeam.GetComponent<LineRenderer>().startColor = new Color(0.0f, 255.0f, 0.0f, 255.0f);
        LaserBeam.GetComponent<LineRenderer>().endColor = new Color(0.0f, 255.0f, 0.0f, 0.0f);

        RaycastHit hit;

        if (Physics.Raycast(LaserBeam.transform.position, LaserBeam.transform.forward, out hit))
        {
            LoadTextScan(hit);
            if (hit.collider.tag == "INBOUND_PACKAGE")
            {
                descriptionTF.text = hit.collider.gameObject.GetComponent<PalletInfo>().description;
                boxQtTf.text = hit.collider.gameObject.GetComponent<PalletInfo>().boxQuantity;
                palletQtTf.text = hit.collider.gameObject.GetComponent<PalletInfo>().palletQuantity;

                hit.collider.gameObject.GetComponent<PalletInfo>().OnScanned();

                StartCoroutine(ShowScanConfirm());
            }
            else if (hit.collider.tag == "OUTBOUND_PACKAGE")
            {
                orderIDTFOut.text = hit.collider.gameObject.GetComponent<OutbounPalletInfo>().orderID;
                descriptionTFOut.text = hit.collider.gameObject.GetComponent<OutbounPalletInfo>().description;
                boxQtTfOut.text = hit.collider.gameObject.GetComponent<OutbounPalletInfo>().boxQuantity;
                palletQtTfOut.text = hit.collider.gameObject.GetComponent<OutbounPalletInfo>().palletQuantity;

                hit.collider.gameObject.GetComponent<OutbounPalletInfo>().OutScanned();

                StartCoroutine(ShowScanConfirm());
            }


        }
    }

    public void LoadTextScan(RaycastHit hit) {

        if (hit.collider.tag == "LOADED_PACKAGE") {
            LoadedPalletInfo packageLoaded = hit.collider.gameObject.GetComponent<LoadedPalletInfo>();

            scanPeso.text = packageLoaded.peso;
            scanTamano.text = packageLoaded.tamano;
            scanFechaVence.text = packageLoaded.fechaVece;
            scanOrigen.text = packageLoaded.origen;
            scanDestino.text = packageLoaded.destino;
            scanPrecio.text = packageLoaded.precio;
            scanDescripcion.text = packageLoaded.description;

            StartCoroutine(ShowScanConfirm());

            textTablet(packageLoaded.description);
        }
    }

    private void textTablet(string description) {
        //texMalEstado.text = 'Esperando...';

        texMalEstado.text = description;
        /*
        if (texMalEstado.enable) {
            texMalEstado.text = description; 
        }
        */
    }
    

    IEnumerator ShowScanConfirm()
    {
        ScanConfirmGUI.SetActive(true);
        yield return new WaitForSeconds(7.0f);

        ScanConfirmGUI.SetActive(false);
        yield return null;
    }

    public void ResetScan()
    {
        LaserBeam.GetComponent<LineRenderer>().startColor = new Color(255.0f, 0.0f, 0.0f, 255.0f);
        LaserBeam.GetComponent<LineRenderer>().endColor = new Color(255.0f, 0.0f, 0.0f, 0.0f);
    }

    /*RETURN TO INVENTIRY SOCKET IF STAYS ON THE GROUND*/
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            returnTimePriv -= 1.0f * Time.deltaTime;

            if (returnTimePriv <= 0.5f)
            {
                this.gameObject.transform.position = inventorySocket.position;
                returnTimePriv = returnTime;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            returnTimePriv = returnTime;
        }
    }

    public void PlayAudioOnFirstPick(VoiceLineManager voiceLineManage)
    {
        if (!pickedOnce && BarScanGrab.selectingInteractor.tag == "HAND_CONTROLLER")
        {
            Task001.StopPlayEvery1Minutes(Task001.playerAudioSrc.clip);
            voiceLineManage.gameObject.SetActive(true);
            pickedOnce = true;
        }
    }

}

