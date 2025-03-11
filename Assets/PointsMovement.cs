using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust speed as needed

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy if it moves off-screen
        if (transform.position.x < -10f) // Adjust based on your screen size
        {
            Destroy(gameObject);
        }
    }
}
