using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignSceneDropZone : MonoBehaviour
{

    public void GoToScene()
    {
        if(PlayerPrefs.GetString("savedScene") == "MainMenu")
        {
            PlayerPrefs.DeleteKey("savedScene");
        }
        string sceneName = PlayerPrefs.GetString("savedScene", "InitialCutscene");
        GameObject.FindObjectOfType<SceneFadeManager>().FadeToScene(sceneName);
    }
}
