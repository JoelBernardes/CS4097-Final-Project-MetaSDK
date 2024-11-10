using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneChecker : MonoBehaviour
{
    bool dropZoneOccupied = false;
    GameObject itemInZone;
    GameObject currentItem;

    public void addItem()
    {
        dropZoneOccupied = true;
        itemInZone = currentItem;
    }

    public void removeItem()
    {
        dropZoneOccupied = false;
        itemInZone = null;
    }

    public bool getOccupancy()
    {
        return dropZoneOccupied;
    }

    public GameObject getItemInZone()
    {
        return itemInZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentItem = other.gameObject;
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        removeItem();
    }
}
