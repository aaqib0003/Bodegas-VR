using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private Animator roboAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") && gameObject.CompareTag("Box_collider"))
        {
            Debug.Log("Box!!");
            roboAnimation.SetBool("RobotOn", true);
            
        }
    }

}
