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
        SceneManager.LoadScene(nextLevel);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
