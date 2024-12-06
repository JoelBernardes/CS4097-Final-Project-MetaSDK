using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> dropZones; // Assign all interactables in the Inspector
    //public List<SnapInteractor> interactors; // Assign all Snap Interactor in the Inspector

    public GameObject winParticle;
    public AudioSource audio;
    public GameObject snapZoneListParent;
    public TMP_Text snapZoneList;

    public string sceneName;

    public OVRInput.Controller _checkListController = OVRInput.Controller.RTouch;
    public OVRInput.Button _checkListButton = OVRInput.Button.One;

    float currentTime = 0f;
    float timeBeforeTransition = 5f;

    bool allCorrect = false;
    bool firstTimePlayingEffects = true;

    int totalScenes;


    void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
        Debug.Log("Current Scene number: " + SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Next Scene: " + (SceneManager.GetActiveScene().buildIndex + 1)); 
        Debug.Log("Total number of scenes: " + (totalScenes - 1));
    }

    void Update()
    {
        if (OVRInput.GetDown(_checkListButton, _checkListController))
        {
            snapZoneListParent.SetActive(true);
        }
        else if (OVRInput.GetUp(_checkListButton, _checkListController))
        {
            snapZoneListParent.SetActive(false);
        }
        AllInteractablesPlaced();
    }

    private void AllInteractablesPlaced()
    {
        string listText = "";
        //bool alreadyChecked = false;
        //Debug.Log("Checking Placement...");
        // Add your logic for when all interactables are placed
        allCorrect = true;

        foreach (var socket in dropZones)
        {
            //Debug.Log("Checking Snap Interactable: " + socket.name);
            if (!socket.GetComponent<DropZoneChecker>().getOccupancy())
            {
                listText += "<color=red>" + socket.name + ": Wrong" + "</color>";
                allCorrect = false;
                //Debug.Log($"Snap Interactable: {socket.gameObject.name} does not have an item in it.");
            }
            else //check to see if right object is in right place
            {
                if(!socket.GetComponent<DropZoneChecker>().correctItemInZone()) //wrong item in slot
                {
                    //Debug.Log($"Snap Interactable: {socket.gameObject.name} does not have the right item in it.");
                    allCorrect = false;
                    listText += "<color=yellow>" + socket.name + ": Wrong Item" + "</color>";
                }
                else
                {
                    listText += "<color=green>" + socket.name + ": Correct" + "</color>";
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

            listText += "<br>";
        }

        // Remove the last <br>
        snapZoneList.text = listText.Substring(0, listText.Length - 4);

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
            GameObject.FindObjectOfType<SceneFadeManager>().FadeToScene(sceneName);
        }
    }
}
