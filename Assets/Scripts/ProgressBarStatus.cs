using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarStatus : MonoBehaviour
{
    public Slider progressBar;
    void Start()
    {
        string savedState = PlayerPrefs.GetString("savedScene", "");
        Debug.Log("Saved at: " + savedState);
        if (savedState.Equals("MainMenu"))
        {
            progressBar.value = 0;
        }
        else if (savedState.Equals("InitialCutscene"))
        {
            progressBar.value = 0.14f;
        }
        else if (savedState.Equals("Level1-ChildhoodBedroom"))
        {
            progressBar.value = 0.29f;
        }
        else if (savedState.Equals("CutsceneTwo"))
        {
            progressBar.value = 0.43f;
        }
        else if (savedState.Equals("Level2-DormRoom"))
        {
            progressBar.value = 0.57f;
        }
        else if (savedState.Equals("CutsceneThree"))
        {
            progressBar.value = 0.71f;
        }
        else if (savedState.Equals("Level3-Appartment"))
        {
            progressBar.value = 0.86f;
        }
        else if (savedState.Equals("CutsceneFinal"))
        {
            progressBar.value = 1f;
        }
        else
        {
            progressBar.value = 0;
        }
        Debug.Log("Progress bar value: " + progressBar.value);
    }
}
