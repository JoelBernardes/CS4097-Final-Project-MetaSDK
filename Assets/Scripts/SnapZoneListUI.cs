using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZoneListUI : MonoBehaviour
{
    public GameObject listUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateList(List<GameObject> dropZones)
    {
        string listText = "";
        foreach (var dropZone in dropZones)
        {
            if (dropZone.GetComponent<DropZoneChecker>().getOccupancy())
            {
                listText += "<color=green>" + dropZone.name + "</color>";
            }
            else
            {
                listText += "<color=green>" + dropZone.name + "</color>";
            }
        }
    }
}
