using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTooltipUI : MonoBehaviour
{
    public string tooltipName;
    public string tooltipDescription;
    public GameObject tooltipPrefab; 
    public float xOffset = 0.5f;
    public float yOffset = 0.5f;
    private GameObject tooltipInstance;

    public float frequency;
    public float amplitude;
    public float duration;

    OVRInput.Controller controller;

    void Update()
    {
        // always make the menu face the player
        if (tooltipInstance != null)
        {
            tooltipInstance.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        }
    }

    // spawns in the tooltip prefab UI at the set offset from the object
    public void ShowTooltip()
    {
        if (tooltipInstance != null)
        {
            return;
        }

        tooltipInstance = Instantiate(tooltipPrefab, this.transform.position + new Vector3(xOffset, yOffset, 0), tooltipPrefab.transform.rotation);
        TooltipUI tooltipUI = tooltipInstance.GetComponent<TooltipUI>();
        tooltipInstance.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        if (tooltipUI != null)
        {
            tooltipUI.SetTooltip(tooltipName, tooltipDescription);
        }
    }

    // delete the tooltip from the game as to not take processing power
    public void HideTooltip()
    {
        if (tooltipInstance != null)
        {
            Destroy(tooltipInstance);
            tooltipInstance = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftHand")
        {
            controller = OVRInput.Controller.LTouch;
        }
        else if (collision.gameObject.tag == "RightHand")
        {
            controller = OVRInput.Controller.RTouch;
        }
    }

    public void grabObject()
    {
        StartCoroutine(triggerHapticsRoutine(controller, frequency));
    }

    private IEnumerator triggerHapticsRoutine(OVRInput.Controller _controller, float frequency)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, _controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, _controller);
    }
}
