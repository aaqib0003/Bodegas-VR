using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoopManager : MonoBehaviour
{
    public Animator mapLoopAnimator;

    public void ToggleLooping(bool newBool)
    {
        mapLoopAnimator.SetBool("stopLoop", newBool);
    }
}
