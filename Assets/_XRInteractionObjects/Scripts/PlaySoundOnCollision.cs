using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource _audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audioSource.Play();
    }
}
