using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperPlaneController : MonoBehaviour
{
    public float speed = 5f;
    public float tiltSpeed = 2f;
    public float liftSpeed = 10f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        float tilt = Input.GetAxis("Horizontal") * tiltSpeed;
        transform.Rotate(0, 0, -tilt);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * liftSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * liftSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) // Make sure the obstacle has the "Obstacle" tag
        {
            FindObjectOfType<Score>().AddScore(10); // Adds 10 points
            Destroy(gameObject); // Destroy the paper plane
        }
    }
}
