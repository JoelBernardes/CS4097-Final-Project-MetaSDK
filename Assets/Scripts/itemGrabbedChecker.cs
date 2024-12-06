using Oculus.Interaction;
using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGrabbedChecker : MonoBehaviour
{
    GrabInteractable grabInteractable;
    bool isGrabbed = false;
    void Start()
    {
        grabInteractable = GetComponentInChildren<GrabInteractable>();
        grabInteractable.WhenSelectingInteractorAdded.Action += WhenSelectingInteractorAdded_Action;
        grabInteractable.WhenSelectingInteractorRemoved.Action += WhenSelectingInteractorAdded_Removed;
    }

    private void WhenSelectingInteractorAdded_Action(GrabInteractor obj)
    {
        confirmIsGrabbed();
    }

    private void WhenSelectingInteractorAdded_Removed(GrabInteractor obj)
    {
        isNotGrabbed();
    }

    public bool checkIfGrabbed()
    {
        return isGrabbed;
    }

    private void confirmIsGrabbed()
    {
        isGrabbed = true;
    }

    private void isNotGrabbed()
    {
        isGrabbed = false;
    }
}
