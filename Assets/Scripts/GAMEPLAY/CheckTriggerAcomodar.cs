using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerAcomodar : MonoBehaviour
{
    public int boxinCollider = 0;
    public Animator aniAcomodar;
    public GameObject acomodar;
    public Transform pallete;
    public GameObject XR_RIG;
    public GameObject triggerSubir;

    public virtual void OnTriggerEnter(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE")) {
            GameObject gameObjectCollider = other.gameObject;
            gameObjectCollider.transform.parent = pallete;
            boxinCollider++;
            checkAnimation();
        }
    }

    public virtual void OnTriggerExit(Collider other) {

        if (other.CompareTag("LOADED_PACKAGE")) {
            boxinCollider--;
            checkAnimation();
        }
    }

    private void checkAnimation() {
        if (boxinCollider >= 3) {
            acomodar.SetActive(false);
            triggerSubir.SetActive(true);
        }
    }

    public void ActivarSubirCarguero() {
        aniAcomodar.SetBool("Cargar", true);
        XR_RIG.SetActive(false);
    }

    public void DesactivarSubirCarguero() {
        aniAcomodar.SetBool("Cargar", true);
        XR_RIG.SetActive(false);
    }

}
