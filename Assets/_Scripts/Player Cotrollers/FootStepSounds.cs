using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    void Walking()
    {
        source.PlayOneShot(clip); ;
    }
   
}
