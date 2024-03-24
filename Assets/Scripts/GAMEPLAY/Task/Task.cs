using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    /*Class Description: Son las tareas individuales que debe realizar el usuario para avanzar en la experiencia.*/

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
        PlayerManager playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
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
        playerManager.currentTask = null;
    }

    /*PLAY VOICE LINE EVERY MINUTE*/
    public void VoiceLinePlay1Min(AudioClip voiceLineToPlay)
    {
        playerAudioSrc.Stop();
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

    public void StopPlayEvery1Minutes(AudioClip voiceLineToPlay)
    {
        StopCoroutine(PlayEvery2Minutes(voiceLineToPlay));
    }

    /*PLAY VOICE LINE ONCE*/
    public void VoiceLinePlayOnce(AudioClip voiceLineToPlay)
    {
        playerAudioSrc.Stop();
        playerAudioSrc.PlayOneShot(voiceLineToPlay);
    }
}