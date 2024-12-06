using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject cardboardBox;
    void Start()
    {
        Instantiate(cardboardBox, transform.position, cardboardBox.transform.rotation);
    }
}
