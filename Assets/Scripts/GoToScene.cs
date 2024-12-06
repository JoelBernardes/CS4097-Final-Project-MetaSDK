using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void LoadTutorial()
    {
       PlayerPrefs.SetInt("TutorialComplete", 0);
       SceneManager.LoadScene("Tutorial");
    }

    public void LoadNextLevel(string nextLevel)
    {
        GameObject.FindObjectOfType<SceneFadeManager>().FadeToScene(nextLevel);
    }

    public void LoadCurrentLevel()
    {
        GameObject.FindObjectOfType<SceneFadeManager>().FadeToScene(SceneManager.GetActiveScene().name);
    }
}
