using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class AnimationOrder : MonoBehaviour
{
    public int countAnimation = 0;
    public int boxValidate = 0;
    public GameObject prefabGuia;
    public UnityEvent OnTaskEnding;
    public FadeController fadeController;
    public bool changeName = false;

    // Start is called before the first frame update
    void Start() {

        if (!fadeController) {
            fadeController = GameObject.Find("[GAMEPLAY]").GetComponent<FadeController>();
        }

        boxValidate = fadeController.boxValidate;
    }

    public virtual void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("LOADED_PACKAGE") && !other.GetComponent<Rigidbody>().isKinematic) {
            countAnimation++;
            GameObject guiaBox = Instantiate(prefabGuia, gameObject.transform.position, gameObject.transform.rotation);

            //activar la animacion correspondientes
            Animator anim = guiaBox.GetComponent<Animator>();
            anim.SetInteger("count", countAnimation);

            //agregar la caja como hijo
            guiaBox.gameObject.transform.parent = gameObject.transform;
            guiaBox.gameObject.transform.position = new Vector3(0, 0, 0);


            other.gameObject.transform.parent = guiaBox.transform;
            other.gameObject.transform.position = new Vector3(0, 0, 0);
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (changeName) {
                other.gameObject.name = "GRAB_BOX_PICKING";
            }
            Destroy(other.GetComponent<XRGrabInteractable>());
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<Collider>());

            if (countAnimation >= boxValidate) {
                OnTaskEnding.Invoke();
            }

        }

    }

    public void SetCountAnimation(int countAni) {
        countAnimation = countAni;
}

}
