using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerMovement : MonoBehaviour
{
    public GameObject[] enableObjects;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameObject: " + other.gameObject.name + " With Tag: " + other.gameObject.tag);

        FindAnyObjectByType<TutorialManager>().AdvanceLevel(1);
        for (int i = 0; i < enableObjects.Length; i++)
        {
            enableObjects[i].SetActive(true);
        }
        Destroy(gameObject);
    }
}
