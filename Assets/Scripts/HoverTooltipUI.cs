using System.Collections;
using System.Collections.Generic;
using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine;

public class HoverTooltipUI : MonoBehaviour
{
    public string tooltipName;
    public string tooltipDescription;
    public GameObject tooltipPrefab;
    public float xOffset = 0.5f;
    public float yOffset = 0.5f;

    public OVRInput.Controller controller = OVRInput.Controller.RTouch;
    public OVRInput.Button button = OVRInput.Button.One;
    private GameObject tooltipInstance;

    private bool isHovered = false;
    private bool toggled = false;
    private bool isCooldown = false;

    void Update()
    {
        // always make the menu face the player
        if (tooltipInstance != null)
        {
            tooltipInstance.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
            tooltipInstance.transform.position = Vector3.MoveTowards(tooltipInstance.transform.position, this.transform.position + new Vector3(xOffset, yOffset, 0), 1.0f);
        }

        if (OVRInput.Get(button, controller) && !isCooldown)
        {
            if (!toggled)
            {
                ShowTooltip();
                toggled = true;
            }
            else
            {
                HideTooltip();
                toggled = false;
            }
            StartCoroutine(ToggleCooldown());
        }
    }

    public void SetHovering(bool hovering)
    {
        isHovered = hovering;
    }

    // spawns in the tooltip prefab UI at the set offset from the object
    public void ShowTooltip()
    {
        if (tooltipInstance != null || !isHovered)
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
        if (tooltipInstance != null && isHovered)
        {
            Destroy(tooltipInstance);
            tooltipInstance = null;
        }
    }

    private IEnumerator ToggleCooldown()
    {
        isCooldown = true;  // Start cooldown
        yield return new WaitForSeconds(0.5f);  // Wait for the set delay time
        isCooldown = false;  // End cooldown
    }
}
