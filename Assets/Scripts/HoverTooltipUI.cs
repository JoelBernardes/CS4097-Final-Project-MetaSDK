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
        CheckForHover();
    }

    private void CheckForHover()
    {
        // Cast a ray from the controller (replace with your controller's transform)
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // Change this to your controller's position and direction
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                ShowTooltip(hit.point); // Show the tooltip at the hit point
            }
            else
            {
                HideTooltip();
            }
        }
        else
        {
            HideTooltip();
        }
    }

    private void ShowTooltip(Vector3 position)
    {
        if (tooltipInstance == null)
        {
            tooltipInstance = Instantiate(tooltipPrefab, position + new Vector3(10, 5, 0), Quaternion.identity);
            TooltipUI tooltipUI = tooltipInstance.GetComponent<TooltipUI>();
            if (tooltipUI != null)
            {
                tooltipUI.SetTooltip(tooltipName, tooltipDescription);
            }
        }
    }

    private void HideTooltip()
    {
        if (tooltipInstance != null)
        {
            Destroy(tooltipInstance);
            tooltipInstance = null;
        }
    }
}
