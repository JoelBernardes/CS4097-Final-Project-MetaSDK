using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDropZone : MonoBehaviour
{
    public int sceneIndex;

    public void GoToScene() {
        SceneManager.LoadScene(sceneIndex);
    }
}
