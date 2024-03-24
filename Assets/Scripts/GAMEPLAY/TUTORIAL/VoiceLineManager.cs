using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoiceLineManager : MonoBehaviour
{
    public AudioSource TargetAudioSource;
    public AudioClip AudioClipToPlay;

    /* EVENTS */
    public UnityEvent OnAudioClipEnd;

    private void Update()
    {
        if (!TargetAudioSource.isPlaying)
        {
            //OnAudioClipEnd.Invoke();
        }
    }

    private void Start()
    {
        TargetAudioSource.Stop();
        TargetAudioSource.PlayOneShot(AudioClipToPlay);
    }

    public void StopAudioClip()
    {
        TargetAudioSource.Stop();
    }

}
