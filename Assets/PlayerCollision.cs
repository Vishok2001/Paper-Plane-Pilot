using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        Invoke(nameof(EnableCollider), 0.5f); // Enable after 0.5 seconds
    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }


    // This function will be called when the player collides with another object
    void OnTriggerCollision2D(Collision2D collision)
    {
        // Check if the collided object has the "Obstacle" tag
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with an obstacle!");

            // Call a method to handle game over, or destroy the player here
            Destroy(gameObject); // Destroy the player on collision

            // Optionally, trigger game over logic here
            GameManager.Instance.GameOver(); // Assuming you have a GameManager to handle game over
        }
    }
}
