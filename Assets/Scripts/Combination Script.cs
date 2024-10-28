using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationScript : MonoBehaviour
{
    public List<GameObject> combinedItemsPrefab;
    public List<GameObject> itemsToCombine;

    bool canCombine = false;

    private void OnCollisionEnter(Collision other)
    {
        foreach (GameObject itemToCombine in itemsToCombine)
        {
            if (other.gameObject == itemToCombine)
            {
                //CombineItems(, itemToCombine);
            }
        }
    }

    private GameObject identifyCombinedItem()
    {
        return null;
    }

    private void CombineItems(GameObject combinedItemPrefab, GameObject itemToCombine)
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        GameObject newCombinedItem = Instantiate(combinedItemPrefab, spawnPosition, spawnRotation);

        newCombinedItem.GetComponent<Rigidbody>().useGravity = false;
        Destroy(this);
        Destroy(itemToCombine);
    }
}
