using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEffectsPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject particleVFX;

    bool objectEntered = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayEffects()
    {
        //Debug.Log("Playing audio when object is " + objectEntered);
        if (!objectEntered)
        {
            audioSource.Play();
            objectEntered = true;

            GameObject played = Instantiate(particleVFX, transform.position, transform.rotation);
            //Destroy(played, 1.5f);
        }
    }

    public void ResetEffects()
    {
        //Debug.Log("Resetting Audio when object is " + objectEntered);
        audioSource.Stop();
        objectEntered = false;
    }
}
