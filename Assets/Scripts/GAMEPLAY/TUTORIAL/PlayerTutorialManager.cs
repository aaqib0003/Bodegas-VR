using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTutorialManager : MonoBehaviour
{
    [Header("Task Tracker")]
    public TutorialTask currentTask;
    public TextMeshProUGUI displayTaskText;

    public void DisplayTaskOnUI()
    {
        displayTaskText.text = currentTask.taskDescription;
    }
}
