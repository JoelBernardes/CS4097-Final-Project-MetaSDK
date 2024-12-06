using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarStatus : MonoBehaviour
{
    public Slider timeBar;
    void Start()
    {
        if (PlayerPrefs.GetString("sceneSaved") == "MainMenu")
        {
            timeBar.value = 0;
        }
        else if (PlayerPrefs.GetString("sceneSaved") == "InitialCutscene")
        {
            timeBar.value = 0.14f;
        }
        else if (PlayerPrefs.GetString("sceneSaved") == "Level1-ChildhoodBedroom")
        {
            timeBar.value = 0.29f;
        }
        else if (PlayerPrefs.GetString("sceneSaved") == "CutsceneTwo")
        {
            timeBar.value = 0.43f;
        }
        if (PlayerPrefs.GetString("sceneSaved") == "Level2-DormRoom")
        {
            timeBar.value = 0.57f;
        }
        else if (PlayerPrefs.GetString("sceneSaved") == "CutsceneThree")
        {
            timeBar.value = 0.71f;
        }
        else if (PlayerPrefs.GetString("sceneSaved") == "Level3-Appartment")
        {
            timeBar.value = 0.86f;
        }
        else if (PlayerPrefs.GetString("sceneSaved") == "CutsceneFinal")
        {
            timeBar.value = 1f;
        }
        else
        {
            timeBar.value = 0;
        }
    }
}
