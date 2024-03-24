using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice LeftController;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        if (devices.Count > 0)
        {
            LeftController = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
