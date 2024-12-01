using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawns a given list of objects passed in through the inspector randomly until everything has been spawned
public class ItemSpawner : MonoBehaviour
{
    // List of GameObjects to spawn
    public List<GameObject> objectsToSpawn;

    public AudioSource boxSource;

    // Flag to control spawning
    private bool canSpawn = true;

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has a specific tag (e.g., "Player")
        if (canSpawn)
        {
            StartCoroutine(SpawnObject());
        }
    }

    private IEnumerator SpawnObject()
    {
        // Check if there are objects left to spawn
        if (objectsToSpawn.Count > 0)
        {
            // Choose a random object from the list
            int randomIndex = Random.Range(0, objectsToSpawn.Count);
            GameObject objectToSpawn = objectsToSpawn[randomIndex];

            // Instantiate the object at the spawner's position and rotation
            GameObject spawnedIn = Instantiate(objectToSpawn, transform.position, transform.rotation);
            spawnedIn.SetActive(true);

            // Optionally remove the spawned object from the list
            objectsToSpawn.RemoveAt(randomIndex);
            boxSource.Play();
        }

        // Set canSpawn to false and wait for 1 second
        canSpawn = false;
        yield return new WaitForSeconds(1f);
        canSpawn = true;
    }
}
