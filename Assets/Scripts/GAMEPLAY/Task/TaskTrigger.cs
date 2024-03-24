using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    [Header("To activate task")]
    [SerializeField]
    public Task TaskToActivate;

    [Header("To Activate task marker on scene")]
    public GameObject TaskSceneMarker;

    public void ActivateTask()
    {
        TaskToActivate.TaskActivated();
    }

    public void ActivateTaskMarker()
    {
        TaskSceneMarker.SetActive(true);
    }
}
