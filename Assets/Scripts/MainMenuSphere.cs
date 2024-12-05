using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSphere : MonoBehaviour
{
    public Transform player;          
    public float maxDistance = 10f; 

    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > maxDistance)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
