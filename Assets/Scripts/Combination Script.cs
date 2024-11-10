using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationScript : MonoBehaviour
{
    public GameObject combinedItemPrefab;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            CombineItems(combinedItemPrefab, other.gameObject);
        }
    }
    /*
    private GameObject identifyCombinedItem()
    {
        return null;
    }
    */

    private void CombineItems(GameObject combinedItemPrefab, GameObject itemToCombine)
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        Instantiate(combinedItemPrefab, spawnPosition, spawnRotation);

        Destroy(itemToCombine);
        Destroy(gameObject);
    }
}
