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

    int totalScenes;

    void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }

    void Update()
    {
        AllInteractablesPlaced();
    }

    private void AllInteractablesPlaced()
    {
        //bool alreadyChecked = false;
        Debug.Log("Checking Placement...");
        // Add your logic for when all interactables are placed
        allCorrect = false;
        foreach (var socket in dropZones)
        {
            if (!socket.GetComponent<DropZoneChecker>().getOccupancy())
            {
                allCorrect = false;
                Debug.Log($"Snap Interactable: {socket.gameObject.name} does not have an item in it.");
            }
            else //check to see if right object is in right place
            {
                allCorrect = true;
                if(!socket.GetComponent<DropZoneChecker>().correctItemInZone()) //wrong item in slot
                {
                    Debug.Log($"Snap Interactable: {socket.gameObject.name} is not in the right place.");
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
            Debug.Log("All Snap Interactables have been placed!");
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
            if (SceneManager.GetActiveScene().buildIndex + 1 > totalScenes)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            Debug.Log("End of demo");
        }
    }
}
