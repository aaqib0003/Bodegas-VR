using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AcomodarMerchAnimController : MonoBehaviour
{
    public GameObject PlayerXRRig, AcomodarMerchXRRig;
    public GameObject InventorySocket, BarScanner;
    public Transform InventorySocketAttachPoint;
    public Image PlayerFade;
    public Transform AlmacenamientoSpawnPoint;
    public GameObject Task004;
    public VoiceLineManager Task004_00Voice;
    public UnityEvent endTask;

    public void AcomodarMerchEndEvent()
    {
        StartCoroutine(FadeToBlackEndEvent());
        endTask.Invoke();
    }

    IEnumerator FadeToBlackEndEvent()
    {       

        PlayerFade.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        PlayerXRRig.SetActive(true);
        yield return null;

        AcomodarMerchXRRig.SetActive(false);
        InventorySocket.SetActive(true);
        yield return null;

        PlayerXRRig.transform.position = AlmacenamientoSpawnPoint.transform.position;
        PlayerXRRig.transform.rotation = AlmacenamientoSpawnPoint.transform.rotation;

        BarScanner.SetActive(true);
        BarScanner.gameObject.transform.position = InventorySocketAttachPoint.position;
        

        //Task004.SetActive(true);
        yield return null;

        /*Starting fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            PlayerFade.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        PlayerFade.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;

        /*fade to transparent completed*/
        Task004_00Voice.gameObject.SetActive(true);
        gameObject.SetActive(false);
        yield return null;
    }

}
