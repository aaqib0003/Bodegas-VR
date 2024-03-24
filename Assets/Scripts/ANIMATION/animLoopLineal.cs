using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animLoopLineal : MonoBehaviour
{
    public Animator manEntradaAnimator, manSalidaAnimator;

    /*ENTRADA*/
    public void ME_CaminarAtras()
    {
        manEntradaAnimator.SetTrigger("caminarAtras");
    }

    public void ME_CaminarAdelante()
    {
        manEntradaAnimator.SetTrigger("caminarAdelante");
    }

    public void ME_Idle()
    {
        manEntradaAnimator.SetTrigger("idle");
    }

    /*SALIDA*/
    public void MS_CaminarAtras()
    {
        manSalidaAnimator.SetTrigger("caminarAtras");
    }

    public void MS_CaminarAdelante()
    {
        manSalidaAnimator.SetTrigger("caminarAdelante");
    }

    public void MS_Idle()
    {
        manSalidaAnimator.SetTrigger("idle");
    }
}
