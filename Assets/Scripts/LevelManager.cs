using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<SnapInteractable> interactables; // Assign all interactables in the Inspector
    public List<SnapInteractor> interactors; // Assign all Snap Interactor in the Inspector

    public ParticleSystem winParticle;
    public AudioSource audio;

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
        bool allCorrect = false;
        //bool alreadyChecked = false;
        Debug.Log("All Snap Interactables have been placed!");
        // Add your logic for when all interactables are placed
        foreach (var socket in interactables)
        {
            foreach (var item in interactors)
            {
                if (socket.transform.position == item.transform.position) //Items are in the same location
                {
                    /*
                     * if (socket.tag != item.tag) //Checks to see if the item belongs in that spot
                    {
                       //Not in the right location
                       allCorrect = false;
                       break;
                    }
                    else
                    {
                        alreadyChecked = true;
                    }
                    */
                    allCorrect = true;
                    break;
                }
                else
                {
                    allCorrect = false;
                }
                /*
                 * if (alreadyChecked) //If we checked the location and its all good, go to next drop zone
                {
                    break;
                }
                */
            }

        }
        if (allCorrect)
        {
            winParticle.Play();
            audio.Play();
            //Go to the next scene once everything is done
        }
    }
}
