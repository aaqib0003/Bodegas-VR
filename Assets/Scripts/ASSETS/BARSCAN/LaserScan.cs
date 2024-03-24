using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScan : MonoBehaviour
{
    public LineRenderer lineRender;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lineRender.SetPosition(1, new Vector3(0.0f, 0.0f, hit.distance));
            }
            else
            {
                lineRender.SetPosition(1, new Vector3(0.0f, 0.0f, 3.0f));
            }
        }
    }
}
