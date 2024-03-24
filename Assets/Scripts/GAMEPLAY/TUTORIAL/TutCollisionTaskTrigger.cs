using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TutCollisionTaskTrigger : MonoBehaviour
{
    public TutorialTask taskToActivate;
    public UnityEvent OnTaskTriggerEnter;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            OnTaskTriggerEnter.Invoke();
        }
    }
}
