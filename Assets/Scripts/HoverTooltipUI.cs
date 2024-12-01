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
}
