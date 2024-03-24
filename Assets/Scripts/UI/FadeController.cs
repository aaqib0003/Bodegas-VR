using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class FadeController : MonoBehaviour
{
    //Reference to fade image
    public Image fadeImg, fadeImg2;
    public GameObject PlayerXRRig;


    [Header("TASK DESCARGA RELATED - Descaga Mercancia")]
    public Transform[] SpanwBox;

    public GameObject PrefabBox;
    public int boxValidate = 5;
    public CheckTrigger checkTrigger;
    //pirvados
    private List<GameObject> points = new List<GameObject>();
    private List<int> numbersValidate = new List<int>();
    private List<GameObject> pointsSelected = new List<GameObject>();

    [Header("TASK ALMACENAMIENTO - Almacenar Mercancia")]
    public Transform[] SpanwAlmacenaBox;
    public GameObject PrefabBoxAlma;

    [Header("TASK PICKING - Seleccionar Pedidos")]

    public Transform[] SpanwBoxPICKING;
    public GameObject PrefabBoxPICK;
    public CheckTriggerPicking checkTriggerPickIng;
    public UnityEvent loadPickIng;
    public Transform pointSeccion2;
    public Transform Player;

    [Header("TASK 001 RELATED - Recepcion Mercancia")]
    public GameObject MapLoop;
    public GameObject InboundMerch;

    [Header("TASK 003 RELATED - Acomodar Mercancia")]
    public GameObject AcomodarMerch;
    public GameObject InventorySocket, BarScanner;

    [Header("TASK 004 RELATED - PICKING")]
    public GameObject PickUpPackagesTask004;

    [Header("SHOW PACKING PROCESS RELATED")]
    public GameObject PackingAnimation;
    public Transform PackingTPPoint;
    public AudioClip PackingVoiceLine;
    public AudioSource PlayerAudioSource;

    [Header("TASKS COMPLETED - Reactivar loop y estado inicial")]
    public GameObject OutboundPackages;

    [Header("Timpo de evaluacion")]
    public float timerMision = 0.0f;
    public bool isEvaluacion= false;
    public bool isMision = false;
    public TextMeshProUGUI timeEvaluacionText;

    public void FadeToTask001() {
        StartCoroutine(FadeToBlackTask001());
    }

    void Start() {
        //FadeToTaskDescarga();
        //FadeToTaskPICKING();
    }

    void Update() {
        countTiempoMision();
    }

    public void timeEvaluacion(bool a) {
        isMision = a;
    }

    private void countTiempoMision() {
        if (isEvaluacion && isMision) {
            timerMision += Time.deltaTime;

            float minutes = Mathf.Floor(timerMision / 60);
            float seconds = timerMision % 60;
            string timeFormat = minutes + " Min : " + Mathf.RoundToInt(seconds) + " seg";
            timeEvaluacionText.text = timeFormat;
        }
    }

        //-------------------------------Picking---------------------------------------------------------------------//
    public void FadeToTaskPICKING() {
        for (int i = 0; i<SpanwBoxPICKING.Length; i++) {
            GameObject box = Instantiate(PrefabBoxPICK, SpanwBoxPICKING[i].position, SpanwBoxPICKING[i].rotation);
            checkDuplicate(box);
            box.GetComponent<LoadedPalletInfo>().setUbicacion(SpanwBoxPICKING[i].name);
            points.Add(box);
        }

        //Asignar el nuimero de cajas validas 
        for (int i = 0; i < boxValidate; i++) {
            checkIntPickIng();
        }

        checkTriggerPickIng.setListBoxValidate(pointsSelected);
    }

    public void pickIngTrasalde() {
        StartCoroutine(pickIngTrasaldeMove());
    }

    private void checkIntPickIng() {
        int numberValidate = Random.Range(0, SpanwBoxPICKING.Length);
        bool validate = true;

        for (int i = 0; i < numbersValidate.Count; i++) {
            if (numbersValidate[i] == numberValidate) {
                validate = false;
            }
        }

        if (validate) {
            numbersValidate.Add(numberValidate);
            pointsSelected.Add(points[numberValidate]);
        } else {
            checkIntPickIng();
        }
    }


    //-------------------------------Almacenamient--------------------------------------------------------------//
    public void FadeToTaskAlmacenamiento() {
        for (int i = 0; i < SpanwAlmacenaBox.Length; i++) {
            GameObject box = Instantiate(PrefabBoxAlma, SpanwAlmacenaBox[i].position, SpanwAlmacenaBox[i].rotation);
            box.GetComponent<LoadedPalletInfo>().establcerContenido();
            points.Add(box);

        }
    }

    //-------------------------------TaskDescarga--------------------------------------------------------------//
    public void FadeToTaskDescarga() {

        for (int i = 0; i < SpanwBox.Length; i++) {
            GameObject box = Instantiate(PrefabBox, SpanwBox[i].position, SpanwBox[i].rotation);

            box.GetComponent<LoadedPalletInfo>().crearStart = false;
            box.GetComponent<LoadedPalletInfo>().establcerContenido();
            checkDuplicate(box);
            points.Add(box);
        }

        //Asignar el nuimero de cajas validas 
        for (int i = 0; i < boxValidate; i++) {
            checkInt();
        }

        boxMalEstado();
        checkTrigger.setListBoxValidate(pointsSelected);

    }

    private void checkDuplicate(GameObject box) {
        bool validate = true;

        LoadedPalletInfo loadedPalletInfo = box.GetComponent<LoadedPalletInfo>();

        for (int i = 0; i < points.Count; i++) {
            LoadedPalletInfo infoValidate = points[i].GetComponent<LoadedPalletInfo>();

            if (loadedPalletInfo.description == infoValidate.description) {
                loadedPalletInfo.establcerContenido();
                validate = false;
            }
        }

        if (!validate) {
            checkDuplicate(box);
        }
    }

    //Asignar una caja valida para recoger y asegurar que no se repita 
    private void checkInt() {
        int numberValidate = Random.Range(0, SpanwBox.Length);
        bool validate = true;

        for (int i = 0; i < numbersValidate.Count; i++)
        {
            if (numbersValidate[i] == numberValidate)
            {
                validate = false;
            }
        }

        if (validate) {
            numbersValidate.Add(numberValidate);
            pointsSelected.Add(points[numberValidate]);
        } else {
            checkInt();
        }
    }

    /*Asignar una caja en mal estado para reportar y asegurar que no se repita 
    * con las que ya se asignaron como validas
    */

    private void boxMalEstado() {
        int numberMalEstado = Random.Range(0, SpanwBox.Length);
        bool validate = true;

        for (int i = 0; i < numbersValidate.Count; i++) {
            if (numbersValidate[i] == numberMalEstado) {
                validate = false;
            }
        }
        if (validate) {
            points[numberMalEstado].GetComponent<LoadedPalletInfo>().setMalEstado();
        } else {
            boxMalEstado();
        }

    }

    public void finishTaskDescarga() {

        for (int i = 0; i < points.Count; i++) {
            Destroy(points[i]);
        }

        points = new List<GameObject>();
        numbersValidate = new List<int>();
        pointsSelected = new List<GameObject>();
        checkTrigger.setListBoxValidate(pointsSelected);
        checkTrigger.boxValidate = 0;
    }
    //-------------------------------TaskDescarga--------------------------------------------------------------//
    IEnumerator pickIngTrasaldeMove() {
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime) {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        Player.position = pointSeccion2.position;

        /*Starting fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime) {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;
    }

    IEnumerator FadeToBlackTask001(){
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        /*fade to black completed*/
        //MapLoop.GetComponent<Animator>().StopPlayback();
        MapLoop.SetActive(false);

        InboundMerch.SetActive(true);
        yield return null;

        /*Starting fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;

        /*fade to transparent completed*/
        
    }

    public void FadeToTask003()
    {
        StartCoroutine(FadeToBlackTask003());
    }

    IEnumerator FadeToBlackTask003()
    {
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        /*fade to black completed*/
        PlayerXRRig.SetActive(false);
        InventorySocket.SetActive(false);
        BarScanner.SetActive(false);

        //InboundMerch.GetComponent<Animator>().speed = 0.0f;
        InboundMerch.SetActive(false);


        AcomodarMerch.SetActive(true);
        AcomodarMerch.GetComponent<Animator>().speed = 0.0f;
        yield return null;

        /*Starting fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            fadeImg2.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg2.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;

        /*fade to transparent completed*/
        AcomodarMerch.GetComponent<Animator>().speed = 1.0f;
    }

    public void FadeToTask004()
    {
        StartCoroutine(FadeToBlackTask004());
    }

    IEnumerator FadeToBlackTask004()
    {
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        /*fade to black completed*/
        AcomodarMerch.GetComponent<Animator>().speed = 0.0f;
        AcomodarMerch.SetActive(false);
        PickUpPackagesTask004.SetActive(true);
        yield return null;

        /*Starting fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;

        /*fade to transparent completed*/
    }

    /*PACKING EXPLANATION */
    public void FadeToPacking()
    {
        StartCoroutine(FadeToBlackPacking());
    }

    IEnumerator FadeToBlackPacking()
    {
        /*1- FADE TO BLACK*/
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        /*2- TAKE PLAYER TO PACKING AREA*/
        PlayerXRRig.transform.position = PackingTPPoint.position;
        yield return null;

        /*3- Enable packing animation object*/
        PackingAnimation.SetActive(true);
        if (PackingAnimation.GetComponent<Animator>() != null)
        {
            PackingAnimation.GetComponent<Animator>().speed = 0.0f;
        }        
        yield return null;

        /*4- Fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;

        /*5- Play animation and voice line*/
        PlayerAudioSource.Stop();
        PlayerAudioSource.PlayOneShot(PackingVoiceLine);
        if (PackingAnimation.GetComponent<Animator>() != null)
        {
            PackingAnimation.GetComponent<Animator>().speed = 1.0f;
        }        
        yield return null;
    }

    /*TASK_005 ACTIVATED*/
    public void FadeTask005Activated()
    {
        StartCoroutine(FadeToBlackTask005());
    }

    IEnumerator FadeToBlackTask005()
    {
        /*1- Fade to black*/
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        /*2- Disable packing animation*/
        PackingAnimation.SetActive(false);
        yield return null;

        /*3- Enable outbound packages*/
        OutboundPackages.SetActive(true);
        yield return null;

        /*4- Fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;
    }


    /*TASK COMPLETED -> PLAYER CHOOSES KEEP EXPLOTING ON CONGRATULATIONS SCREEN*/
    public void FadeCompletedTasks()
    {
        StartCoroutine(FadeToBlackTaskCompleted());
    }

    IEnumerator FadeToBlackTaskCompleted()
    {
        /*1- Fade to black*/
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        yield return null;

        /*2-  Re enable*/
        MapLoop.SetActive(true);
        OutboundPackages.SetActive(false);
        yield return null;

        /*3- Fade to transparent*/
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime)
        {
            fadeImg.color = new Color(0.0f, 0.0f, 0.0f, t);
            yield return null;
        }

        fadeImg.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        yield return null;

    }
}
