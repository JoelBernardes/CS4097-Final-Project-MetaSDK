using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZoneViewer : MonoBehaviour
{
    public OVRInput.Controller _controller;
    public OVRInput.Button _button;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(_button, _controller))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

        if (OVRInput.GetUp(_button, _controller))
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
