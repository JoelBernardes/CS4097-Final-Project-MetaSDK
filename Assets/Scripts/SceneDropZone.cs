using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDropZone : MonoBehaviour
{
    public string sceneName;

    public void GoToScene() {
        GameObject.FindObjectOfType<SceneFadeManager>().FadeToScene(sceneName);
    }
}
