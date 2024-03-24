using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDGui : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 followOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = followTarget.position + (Vector3.up * followOffset.y)
                           + (Vector3.ProjectOnPlane(followTarget.right, Vector3.up).normalized * followOffset.x)
                           + (Vector3.ProjectOnPlane(followTarget.forward, Vector3.up).normalized * followOffset.z);

        transform.eulerAngles = new Vector3(0, followTarget.eulerAngles.y, 0);
    }
}
