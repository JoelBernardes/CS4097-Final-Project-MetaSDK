using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneChecker : MonoBehaviour
{
    bool dropZoneOccupied = false;
    bool corectItem = false;
    bool isHolding = true;

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
        if (other.gameObject.tag == gameObject.tag)
        {
            //Debug.Log("Is Snap Interactable grabbed: " + isHolding);
            if (!isHolding && other.gameObject.GetComponent<Rigidbody>().isKinematic)
            {
                //Debug.Log("Added Item: " + other.gameObject.name);
                dropZoneOccupied = true;
                if (other.gameObject.tag == gameObject.tag)
                {
                    //Debug.Log("Correct item!");
                    corectItem = true;
                }
                else
                {
                    //Debug.Log("Incorrect Item");
                    corectItem = false;
                }
            }
            else
            {
                isHolding = true;
                dropZoneOccupied = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            Debug.Log("Removing Snap Interactable");
            dropZoneOccupied = false;
            isHolding = true;
            corectItem = false;
        }
    }

    public void addItem()
    {
        isHolding = false;
    }
}
