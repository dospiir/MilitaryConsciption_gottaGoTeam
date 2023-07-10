using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private Collider2D platformCollider;

    private void Start()
    {
        // Get a reference to the platform's collider
        platformCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider entering the platform is the player
        if (other.CompareTag("Player"))
        {
            // Disable the platform's collider temporarily
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collider exiting the platform is the player
        if (other.CompareTag("Player"))
        {
            // Enable the platform's collider again
            platformCollider.isTrigger =false;
        }
    }
}
