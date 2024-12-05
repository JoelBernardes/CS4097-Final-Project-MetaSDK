using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorybookTracker : MonoBehaviour
{
    // List of target GameObjects to move between
    public List<GameObject> targetObjects;

    public float moveSpeed = 3f;

    public OVRInput.Button moveButton = OVRInput.Button.PrimaryIndexTrigger;

    public OVRInput.Controller controller = OVRInput.Controller.RTouch;

    [SerializeField] private string sceneName = "";
    private int currentTargetIndex = 0;
    private bool isMoving = false;

    private float yOffset = 0.5f;

    void Start()
    {
        foreach (GameObject target in targetObjects)
        {
            target.SetActive(false);
        }
    }
    void Update()
    {
        // Check if the button is pressed
        if (OVRInput.GetDown(moveButton) && !isMoving && currentTargetIndex != targetObjects.Count)
        {
            StartCoroutine(MoveToNextTarget());
        }
        else if (OVRInput.GetDown(moveButton) && !isMoving)
        {
            GameObject.FindObjectOfType<SceneFadeManager>().FadeToScene(sceneName);
        }
    }

    private IEnumerator MoveToNextTarget()
    {
        if (targetObjects.Count == 0) yield break;

        isMoving = true;

        // Get the target position of the next GameObject in the list
        Vector3 targetPosition = targetObjects[currentTargetIndex].transform.position + new Vector3(0, yOffset, 0);

        // Move the object towards the target
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to the target position once close enough
        transform.position = targetPosition;

        targetObjects[currentTargetIndex].SetActive(true);

        if (currentTargetIndex > 0)
        {
            targetObjects[currentTargetIndex - 1].SetActive(false);
        }

        // Update the target index to move to the next GameObject in the list
        currentTargetIndex = currentTargetIndex + 1;

        isMoving = false;
    }
}
