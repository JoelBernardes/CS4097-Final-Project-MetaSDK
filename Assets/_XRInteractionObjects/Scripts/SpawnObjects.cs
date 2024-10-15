using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject spawnObject;
    public ParticleSystem particleEffect;
    public AudioSource _audioSource;

    
    string objectTag;


    bool isInstantiateReady;

    void Start()
    {
        objectTag = spawnObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag(objectTag).Length < 3)
        {
            //Invoke("InstantiateObject", 3f);
            _audioSource.Play();
            particleEffect.Play();
            InstantiateObject();
        }
    }

    void InstantiateObject()
    {
        Instantiate(spawnObject, transform.position, Quaternion.identity);
    }
}
