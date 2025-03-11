using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points = 10; // Set points per obstacle

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure Player has the "Player" tag
        {
            Score scoreManager = FindObjectOfType<Score>(); // Find Score script in scene
            if (scoreManager != null)
            {
                scoreManager.AddScore(points); // Add points
            }

            Destroy(gameObject); // Remove obstacle after collision
        }
    }
}