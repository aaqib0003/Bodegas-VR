using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTaskTrigger : MonoBehaviour
{
    public Task taskToActivate;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            taskToActivate.TaskActivated();
        }
    }
}
