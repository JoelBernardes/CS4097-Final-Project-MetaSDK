using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneChecker : MonoBehaviour
{
    bool dropZoneOccupied = false;
    bool corectItem = false;
    public bool getOccupancy()
    {
        return dropZoneOccupied;
    }

    public bool correctItemInZone()
    {
        return corectItem;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            Debug.Log("Is Snap Interactable grabbed: " + other.gameObject.GetComponent<itemGrabbedChecker>().checkIfGrabbed());
            if (!(other.gameObject.GetComponent<itemGrabbedChecker>().checkIfGrabbed()) && other.gameObject.GetComponent<Rigidbody>().isKinematic)
            {
                //Debug.Log("Added Item: " + other.gameObject.name);
                dropZoneOccupied = true;
                if (other.gameObject.tag == gameObject.tag)
                {
                    Debug.Log("Correct item!");
                    corectItem = true;
                }
                else
                {
                    Debug.Log("Incorrect Item");
                    corectItem = false;
                }
            }
            else
            {
                dropZoneOccupied = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            if (other.GetComponent<itemGrabbedChecker>().checkIfGrabbed())
            {
                Debug.Log("Removing Snap Interactable");
                dropZoneOccupied = false;
                corectItem = false;
            }
        }
    }
}
