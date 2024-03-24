using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public PlayerTutorialManager playerTutManager;
    public GameObject levelSelectionGUI, groundCollider, welcomeVoiceLine;
    [SerializeField]
    public int tutorialCompleted;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("TUTORIAL_COMPLETE"))
        {
            tutorialCompleted = PlayerPrefs.GetInt("TUTORIAL_COMPLETE");
            if (tutorialCompleted == 1)
            {
                welcomeVoiceLine.SetActive(false);
                levelSelectionGUI.SetActive(true);
                groundCollider.SetActive(true);
            }
            else if (tutorialCompleted == 0)
            {
                welcomeVoiceLine.SetActive(true);
                levelSelectionGUI.SetActive(false);
                groundCollider.SetActive(false);
            }
        }
        else
        {
            tutorialCompleted = 0;
            PlayerPrefs.SetInt("TUTORIAL_COMPLETE", 0);
            welcomeVoiceLine.SetActive(true);
            levelSelectionGUI.SetActive(false);
            groundCollider.SetActive(false);
        }
    }

    private void Start()
    {
        /*if (PlayerPrefs.HasKey("TUTORIAL_COMPLETE"))
        {
            tutorialCompleted = PlayerPrefs.GetInt("TUTORIAL_COMPLETE");
            if (tutorialCompleted == 1)
            {
                welcomeVoiceLine.SetActive(false);
                levelSelectionGUI.SetActive(true);
                groundCollider.SetActive(true);                
            }
            else
            {
                welcomeVoiceLine.SetActive(true);
            }
        }
        else
        {
            tutorialCompleted = 0;
        }*/
        
    }

    public void TaskCompletedOnAction(string taskID)
    {
        if (playerTutManager.currentTask.taskID == taskID)
        {
            playerTutManager.currentTask.TaskCompleted();
        }
        else
        {
            return;
        }
    }

    public void TutorialCompleted()
    {
        PlayerPrefs.SetInt("TUTORIAL_COMPLETE", 1);
        tutorialCompleted = PlayerPrefs.GetInt("TUTORIAL_COMPLETE");
    }
}
