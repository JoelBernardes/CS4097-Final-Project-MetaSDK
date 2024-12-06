using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialInfoUI;
    public string[] tutorialStagesName;
    public string[] tutorialStagesText;
    public List<GameObject> dropZones;

    public GameObject winParticle;
    public AudioClip nextStageSFX;

    public GameObject snapZoneListParent;
    public TMP_Text snapZoneList;

    public OVRInput.Controller _checkListController = OVRInput.Controller.RTouch;
    public OVRInput.Button _checkListButton = OVRInput.Button.One;

    AudioSource audioWin;

    int currentStage = 0;
    TooltipUI tutorialTooltipUI;

    bool allCorrect = false;
    bool firstTimePlayingEffects = true;



    private void Awake()
    {
        if (PlayerPrefs.GetInt("TutorialComplete") == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Start()
    {
        audioWin = GetComponent<AudioSource>();

        tutorialTooltipUI = tutorialInfoUI.GetComponent<TooltipUI>();
        tutorialTooltipUI.SetTooltip(tutorialStagesName[currentStage], tutorialStagesText[currentStage]);
    }

    private void AllInteractablesPlaced()
    {
        //bool alreadyChecked = false;
        //Debug.Log("Checking Placement...");
        // Add your logic for when all interactables are placed
        allCorrect = true;
        string listText = "";
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
                if (!socket.GetComponent<DropZoneChecker>().correctItemInZone()) //wrong item in slot
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

            listText += "<br>";
        }

        snapZoneList.text = listText.Substring(0, listText.Length - 4);
        if (allCorrect)
        {
            if (firstTimePlayingEffects)
            {
                Debug.Log("You win!");
                winParticle.SetActive(true);
                GetComponent<AudioSource>().Play();
                firstTimePlayingEffects = false;
                AdvanceLevel(tutorialStagesName.Length - 1);
                PlayerPrefs.SetInt("TutorialComplete", 1);
            }
        }
    }

    // Update is called once per frame
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

        tutorialInfoUI.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);   
        AllInteractablesPlaced();
    }

    public void AdvanceLevel(int toStep)
    {
        if (toStep > currentStage)
        {
            currentStage++;
            tutorialInfoUI.GetComponent<TooltipUI>().SetTooltip(tutorialStagesName[currentStage], tutorialStagesText[currentStage]);
            AudioSource.PlayClipAtPoint(nextStageSFX, Camera.main.transform.position);
        }
    }
}

/*
 * Welcome player to the game and indicate that they are in the tutorial - 5s
 * Lets start with moving around. Use the left stick to teleport to move around. - 0
 * Nice job! Moving on, try touching the box in the middle of the room.
 * Great! Touch the box in the room and hover over the item that pops out. - 0
 * - Object tooltip: explains tooltip
 * Now grab the item with the grip button - 0
 * Items can be placed in snap zones. Press the left stick down to see what zones are available - 0
 * Place the item in the snap zone. It should snap into place - 0
 * Great! But wait there's a new box with another item. Grab the new item. - 0
 * Doors and cabinets can be opened by grabbing the handle and pulling. Cabinets can also contain snap zones.
 * In the real game, you will need to place the objects in the correct snap zones. Find the correct combination of the two objects and snap zones.
 * Well done! You completed the tutorial. Use the menu button on the left controller and press the exit button to exit. - 0

 */