using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTooltipUI : MonoBehaviour
{
    public string tooltipName;
    public string tooltipDescription;
    public GameObject tooltipPrefab; // Assign the Tooltip prefab here

    private GameObject tooltipInstance;

    void Update()
    {
    }

    public void ShowTooltip()
    {
        tooltipInstance = Instantiate(tooltipPrefab, this.transform.position + new Vector3(1, 1, 0), this.transform.rotation);
        TooltipUI tooltipUI = tooltipInstance.GetComponent<TooltipUI>();
        if (tooltipUI != null)
        {
            tooltipUI.SetTooltip(tooltipName, tooltipDescription);
        }
    }

    public void HideTooltip()
    {
        if (tooltipInstance != null)
        {
            Destroy(tooltipInstance);
            tooltipInstance = null;
        }
    }
}
