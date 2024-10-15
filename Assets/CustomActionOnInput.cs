using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomActionOnInput : MonoBehaviour
{
    public OVRInput.Controller _controller;
    public OVRInput.Button _button;

    public UnityEvent OnCustomInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        }

        if (OVRInput.GetUp(_button, _controller))
        {
            OnCustomInput.Invoke();
        }
    }
}
