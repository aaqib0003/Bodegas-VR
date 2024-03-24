using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_animation : MonoBehaviour
{
    [SerializeField] private Animator roboAnimation;
    [SerializeField] AudioSource roboSFX;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("movingBox") && gameObject.CompareTag("trigger_1"))
        {
            Debug.Log("Trigger");
            roboAnimation.SetBool("RobotOn", true);
            roboSFX.Play();
        }

        if (other.CompareTag("movingBox_2") && gameObject.CompareTag("trigger_2"))
        {
            Debug.Log("Trigger2");
            roboAnimation.SetBool("RobotOn", true);
            roboSFX.Play();
        }

        if (other.CompareTag("movingBox_3") && gameObject.CompareTag("trigger_3"))
        {
            Debug.Log("Trigger3");
            roboAnimation.SetBool("RobotOn", true);
            roboSFX.Play();
        }

        if (other.CompareTag("movingBox_4") && gameObject.CompareTag("trigger_4"))
        {
            Debug.Log("Trigger4");
            roboAnimation.SetBool("RobotOn", true);
            roboSFX.Play();
        }

        if (other.CompareTag("movingBox_5") && gameObject.CompareTag("trigger_5"))
        {
            Debug.Log("Trigger5");
            roboAnimation.SetBool("RobotOn", true);
            roboSFX.Play();
        }

        if (other.CompareTag("movingBox_6") && gameObject.CompareTag("trigger_6"))
        {
            Debug.Log("Trigger6");
            roboAnimation.SetBool("RobotOn", true);
            roboSFX.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("movingBox") && gameObject.CompareTag("trigger_1"))
        {
            roboAnimation.SetBool("RobotOn", false);
        }

        if (other.CompareTag("movingBox_2") && gameObject.CompareTag("trigger_2"))
        {
            roboAnimation.SetBool("RobotOn", false);
        }

        if (other.CompareTag("movingBox_3") && gameObject.CompareTag("trigger_3"))
        {
            roboAnimation.SetBool("RobotOn", false);
        }

        if (other.CompareTag("movingBox_4") && gameObject.CompareTag("trigger_4"))
        {
            roboAnimation.SetBool("RobotOn", false);
        }

        if (other.CompareTag("movingBox_5") && gameObject.CompareTag("trigger_5"))
        {
            roboAnimation.SetBool("RobotOn", false);
        }

        if (other.CompareTag("movingBox_6") && gameObject.CompareTag("trigger_6"))
        {
            roboAnimation.SetBool("RobotOn", false);
        }


    }
}
