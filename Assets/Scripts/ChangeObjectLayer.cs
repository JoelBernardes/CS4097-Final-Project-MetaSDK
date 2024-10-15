using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ChangeObjectLayer : MonoBehaviour
{
    public string newInteractionLayer = "Snapped";
    public bool isSnapped = false;

    private XRSocketInteractor socketInteractor;
    private int originalLayer;

    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
//        socketInteractor.selectEntered.AddListener(OnSnapped);

    }


    public void OnSnapped(SelectEnterEventArgs args)
    {
        XRGrabInteractable grabbedObject = args.interactableObject as XRGrabInteractable;

        if (grabbedObject != null)
        {
            originalLayer = grabbedObject.interactionLayers;
            socketInteractor.interactionLayers = InteractionLayerMask.GetMask(newInteractionLayer);
            grabbedObject.interactionLayers = InteractionLayerMask.GetMask(newInteractionLayer);
            isSnapped = true;
        }

    }

    public void OnUnsnap(SelectExitEventArgs args)
    {
        XRGrabInteractable grabbedObject = args.interactableObject as XRGrabInteractable;

        socketInteractor.interactionLayers = originalLayer;
        grabbedObject.interactionLayers = originalLayer;
        isSnapped = false;
    }
}
