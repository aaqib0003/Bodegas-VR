using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheckTriggerPicking : MonoBehaviour {

    public int boxinCollider = 0;
    public int boxValidate = 0;
    public int boxError = 0;
    
    public UnityEvent loadTaskFinish;
    public UnityEvent loadEventNoFinish;

    public TMP_Text[] lableTablet;
    public Toggle[] toggleObject;
    public FadeController fadeController;

    //private 
    public List<GameObject> ListBoxValidate = new List<GameObject>();

    public virtual void OnTriggerEnter(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE")) {
            GameObject gameObjectCollider = other.gameObject;
            if (checkValide(other.gameObject, true)) {
                boxValidate++;
                gameObjectCollider.transform.parent = gameObject.transform;
                
            } else {
                boxError++;
            }
            checkFinish();
        }
    }

    public virtual void OnTriggerExit(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE")) {
            GameObject gameObjectCollider = other.gameObject;
            if (checkValide(other.gameObject, false)) {
                boxValidate--;
                gameObjectCollider.transform.parent = null;
            } else {
                boxError--;
            }
            checkFinish();
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
    }

    public void setListBoxValidate(List<GameObject> list) {
        ListBoxValidate = list;
        loadTablet();
    }

    private void loadTablet() {
        for (int i = 0; i < ListBoxValidate.Count; i++) {
            lableTablet[i].text = ListBoxValidate[i].GetComponent<LoadedPalletInfo>().ubicacionAux;
            toggleObject[i].isOn = false;
        }
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
        } else if (fadeController.boxValidate == boxValidate && boxError == 0)
        {
            loadTaskFinish.Invoke();
        }
        return true;
    }
}
