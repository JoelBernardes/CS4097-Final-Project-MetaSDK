using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> dropZones; // Assign all interactables in the Inspector
    //public List<SnapInteractor> interactors; // Assign all Snap Interactor in the Inspector

    public GameObject winParticle;
    public AudioSource audio;

    float currentTime = 0f;
    float timeBeforeTransition = 10f;

    bool allCorrect = false;
    bool firstTimePlayingEffects = true;

    void Update()
    {
        AllInteractablesPlaced();
    }

    private void AllInteractablesPlaced()
    {
        //bool alreadyChecked = false;
        Debug.Log("All Snap Interactables have been placed!");
        // Add your logic for when all interactables are placed
        allCorrect = false;
        foreach (var socket in dropZones)
        {
            if (!socket.GetComponent<DropZoneChecker>().getOccupancy())
            {
                allCorrect = false;
            } else //check to see if right object is in right place
            {
                if(socket.GetComponent<DropZoneChecker>().getItemInZone().tag != socket.tag) //wrong item in slot
                {
                    allCorrect = false;
                }
            }
            //foreach (var item in interactors)
            //{
                /*
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
                    
                    allCorrect = true;
                    break;
                } */

                /*
                 * if (alreadyChecked) //If we checked the location and its all good, go to next drop zone
                {
                    break;
                }
                */
            //}
            if (!allCorrect)
            {
                break;
            }
        }
        if (allCorrect)
        {
            levelComplete();
        }
    }
    private void levelComplete()
    {
        if (firstTimePlayingEffects)
        {
            Debug.Log("You win!");
            winParticle.SetActive(true);
            audio.Play();
            firstTimePlayingEffects = false;
        }
        currentTime += Time.deltaTime;

        //Go to the next scene once everything is done
        if (currentTime >= timeBeforeTransition)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
