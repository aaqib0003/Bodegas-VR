using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialTask : MonoBehaviour
{
    /* VARIABLES */
    public bool isActive;
    public string taskID;
    public string taskDescription;

    /* DISPLAYING TASK INFO */
    public AudioSource playerAudioSrc;

    /* EVENTS */
    public UnityEvent OnTaskActivated;
    public UnityEvent OnTaskCompleted;

    /* METHODS */
    public void TaskActivated()
    {
        PlayerTutorialManager playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTutorialManager>();
        playerManager.currentTask = this;

        isActive = true;
        OnTaskActivated.Invoke();
        Debug.Log("TASK_" + taskID + " activated!");
    }

    public void TaskCompleted()
    {
        OnTaskCompleted.Invoke();
        isActive = false;
        Debug.Log("TASK_" + taskID + " completed!");

        PlayerManager playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        //playerManager.currentTask = null;
    }

    /*PLAY A VOICE LINE RELATE EVERY 2 MINUTES*/
    public void VoiceLinePlay2Min(AudioClip voiceLineToPlay)
    {
        StartCoroutine(PlayEvery2Minutes(voiceLineToPlay));
    }

    IEnumerator PlayEvery2Minutes(AudioClip newVoiceLine)
    {
        while (isActive)
        {
            playerAudioSrc.PlayOneShot(newVoiceLine);
            yield return new WaitForSeconds(newVoiceLine.length + 60.0f);
        }
    }

    public void StopAudioClip()
    {
        playerAudioSrc.Stop();
    }

}
