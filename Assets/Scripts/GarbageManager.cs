using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    public OVRInput.Controller _controller;
    public OVRInput.Button _button;

    public AudioClip destroySound;
    public GameObject destroyVFX;
    public AudioClip restoreSound;
    public GameObject restoreVFX;
    public Transform restoreLocation;

    public bool trashIsActive = true;

    public static Stack<GameObject> disabledObjects = new Stack<GameObject>();

    private void Update()
    {
        if (OVRInput.GetDown(_button, _controller))
        {
            RestoreFromGarbage();
        }
    }

    public void AddToGarbage(GameObject obj)
    {
        if (!trashIsActive)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(destroySound, obj.transform.position);
        GameObject particle = Instantiate(destroyVFX, obj.transform.position, obj.transform.rotation);
        Destroy(particle, 2.0f);

        obj.SetActive(false);
        disabledObjects.Push(obj);
    }

    public void RestoreFromGarbage()
    {
        if (!trashIsActive)
        {
            return;
        }

        if (disabledObjects.Count == 0)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(restoreSound, restoreLocation.position);
        GameObject particle = Instantiate(restoreVFX, restoreLocation.position, restoreLocation.rotation);
        Destroy(particle, 2.0f);

        GameObject obj = disabledObjects.Pop();
        obj.transform.position = restoreLocation.position;
        
        obj.GetComponent<DestroyObject>().RestoreObject();
    }
}
