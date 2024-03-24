using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiAudioManager : MonoBehaviour
{
    public AudioSource TargetAudioSource;
    public AudioClip AudioClipToPlay;

    private bool firstOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        /*PLAY ON FIRST OPEN*/
        if (!firstOpen)
        {
            TargetAudioSource.Stop();
            TargetAudioSource.PlayOneShot(AudioClipToPlay);
            firstOpen = true;
        }
    }
}
