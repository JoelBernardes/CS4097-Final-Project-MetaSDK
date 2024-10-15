using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{
    public string tagName = "Ground";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagName))
        {
            Destroy(gameObject, 1f);

        }
    }

}
