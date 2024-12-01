using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public OVRInput.Controller _controller;
    public OVRInput.Button _button;

    public GrabInteractable interactable;
    
    bool isGrabbed;

    private void Awake() {
        var CurrentState = interactable.State;
        isGrabbed = CurrentState == InteractableState.Select;
    }

    private void Update()
    {
        isGrabbed = interactable.State == InteractableState.Select;
        if (isGrabbed && OVRInput.GetDown(_button, _controller))
        {
            MoveObjectToGarbage();
        }
    }

    public void MoveObjectToGarbage()
    {
        FindObjectOfType<GarbageManager>().AddToGarbage(gameObject);
        isGrabbed = false;
    }
    
}
