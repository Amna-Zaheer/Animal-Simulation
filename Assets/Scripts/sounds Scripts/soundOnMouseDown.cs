using UnityEngine;
using System.Collections;

public class soundOnMouseDown : MonoBehaviour
{
    public AudioClip valvesfx;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();


    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.enabled = true;
            if (!audioSource.isPlaying)
            {
                audioSource.clip = valvesfx;
                audioSource.Play();
            }
        }






    }

}
