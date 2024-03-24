using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventAnimation : MonoBehaviour {

    public void establcerContenido() {
        GameObject child1 = this.gameObject.transform.Find("GRAB_BOX_PICKING").gameObject;
        GameObject child2 = child1.transform.Find("CanvasEmpaquetado").gameObject;


        child2.SetActive(true);
    }
}
