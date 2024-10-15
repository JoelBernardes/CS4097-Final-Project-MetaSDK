using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LevelStateManager : MonoBehaviour
{
    public List<XRSocketInteractor> sockets; // List of XR sockets
    public List<XRGrabInteractable> grabbableObjects; // List of grabbable objects to be placed in the level

    private void Update()
    {
        CheckAllPlaced();
    }

    private void OnEnable()
    {
        foreach (var socket in sockets)
        {
            socket.selectEntered.AddListener(OnSocketFilled);
            socket.selectExited.AddListener(OnSocketEmptied);
        }
    }

    private void OnDisable()
    {
        foreach (var socket in sockets)
        {
            socket.selectEntered.RemoveListener(OnSocketFilled);
            socket.selectExited.RemoveListener(OnSocketEmptied);
        }
    }

    private void OnSocketFilled(SelectEnterEventArgs args)
    {
        CheckAllPlaced();
    }

    private void OnSocketEmptied(SelectExitEventArgs args)
    {
        CheckAllPlaced();
    }


    private void CheckAllPlaced()
    {
        bool allPlaced = true;

        foreach (var socket in sockets)
        {
            if (socket.interactablesSelected.Count == 0)
            {
                allPlaced = false;
                break; // Exit early if we find an empty socket
            }
        }

        if (allPlaced)
        {
            Debug.Log("All objects have been placed in their sockets!");
        }
    }
}
