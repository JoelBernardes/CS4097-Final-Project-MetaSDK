using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
public List<SnapInteractable> interactables; // Assign all interactables in the Inspector
    public SnapInteractor snapInteractor; // Assign the Snap Interactor here

    private HashSet<SnapInteractable> placedInteractables = new HashSet<SnapInteractable>();


    private void HandleSnap(SnapInteractable interactable)
    {
        placedInteractables.Add(interactable);
        CheckAllPlaced();
    }

    private void HandleUnsnap(SnapInteractable interactable)
    {
        placedInteractables.Remove(interactable);
    }

    private void CheckAllPlaced()
    {
        if (placedInteractables.Count == interactables.Count)
        {
            AllInteractablesPlaced();
        }
    }

    private void AllInteractablesPlaced()
    {
        Debug.Log("All Snap Interactables have been placed!");
        // Add your logic for when all interactables are placed
    }
}
