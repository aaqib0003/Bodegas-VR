using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CheckTrigger : MonoBehaviour {

    public int boxinCollider = 0;
    public int boxValidate = 0;
    public int boxError = 0;

    public FadeController fadeController;
    public UnityEvent loadTaskFinish;
    public UnityEvent loadEventNoFinish;
    public TMP_Text[] lableTablet;
    public Toggle[] toggleObject;
    public OrganizedObject organizedObjects;

    //private 
    private List<GameObject> ListBoxValidate = new List<GameObject>();


    private void Awake()
    {
        foreach (var item in ListBoxValidate)
        {
            item.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
        }
    }
   
    public virtual void OnTriggerEnter(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE") /*&& !other.GetComponent<Rigidbody>().isKinematic*/) {
            GameObject gameObjectCollider = other.gameObject;
            if (checkValide(other.gameObject, true)) {
              
                organizedObjects.SetPositions(boxValidate, other.gameObject);
               // other.GetComponent<Rigidbody>().isKinematic = true;
                boxValidate++;
                gameObjectCollider.transform.parent = gameObject.transform;
            } else {
                boxError++;
            }
            checkFinish();
        }
    }

    public virtual void OnTriggerExit(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE"))
        {
            GameObject gameObjectCollider = other.gameObject;
            if (checkValide(other.gameObject, false))  {
                boxValidate--;
                gameObjectCollider.transform.parent = null;
            } else {
                boxError--;
            }
            checkFinish();
        }
    }

    public void setListBoxValidate(List<GameObject> list) {
        ListBoxValidate = list;
        loadTablet();
    }

    private void  loadTablet() {
        
        for (int i = 0; i < ListBoxValidate.Count; i++) {
            lableTablet[i].text = ListBoxValidate[i].GetComponent<LoadedPalletInfo>().description;
            toggleObject[i].isOn = false;
        }
    }

    private bool checkValide(GameObject gameObjectCollider, bool actgionToggle) {

        LoadedPalletInfo gameLoader = gameObjectCollider.GetComponent<LoadedPalletInfo>();

        for (int i = 0; i < ListBoxValidate.Count; i++) {
            if (ListBoxValidate[i] == gameObjectCollider) {
                toggleObject[i].isOn = actgionToggle;
                return true;
            }
        }

        return false;

        if (gameLoader.destino == "Bogota") {
            return true;
        }
        return false;

    }

    private bool checkFinish() {
        if (boxError > 0) {
            loadEventNoFinish.Invoke();
            return true;
        }

        if (boxinCollider > fadeController.boxValidate) {
            loadEventNoFinish.Invoke();
        }

        if (boxValidate > fadeController.boxValidate || boxValidate < fadeController.boxValidate) {
            loadEventNoFinish.Invoke();
        } else if (fadeController.boxValidate == boxValidate && boxError == 0) {
            loadTaskFinish.Invoke();
        }
        return true;
    }

    
}
