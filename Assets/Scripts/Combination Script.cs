using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationScript : MonoBehaviour
{
    public GameObject combinedItemPrefab;
    public GameObject itemToCombine;

    //bool canCombine = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == itemToCombine)
        {
            CombineItems();
        }
    }

    private void CombineItems()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        GameObject newCombinedItem = Instantiate(combinedItemPrefab, spawnPosition, spawnRotation);

        Destroy(gameObject);
        Destroy(itemToCombine);
    }
}
