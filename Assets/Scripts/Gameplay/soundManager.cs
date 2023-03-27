using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource soundFX;

    void Awake()
    {
        instance = this;    
    }

    public void playSoundFX(AudioClip clip)
    {
        soundFX.clip = clip;
        soundFX.Play();
    }
}
