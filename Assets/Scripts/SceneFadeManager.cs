using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFadeManager : MonoBehaviour
{
    public Image fadeImage; // Reference to the UI Image
    public float fadeDuration = 1f; // Duration for the fade effect
    private bool isFading = false; // To track if fading is in progress

    private void Start()
    {
        // Start with the fade image fully transparent
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
    }

    // Call this method to fade to the next scene
    public void FadeToScene(string sceneName)
    {
        if (!isFading)
        {
            StartCoroutine(FadeCoroutine(sceneName));
        }
    }

    private IEnumerator FadeCoroutine(string sceneName)
    {
        isFading = true;

        // Fade Out
        yield return Fade(1f);

        // Load the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // While the scene is loading, wait
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Fade In after the scene has finished loading
        yield return Fade(0f);

        isFading = false;
    }

    // A helper method to handle fading in and out
    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha value is exactly the target alpha after the fade
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, targetAlpha);
    }
}
