using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperPlaneController : MonoBehaviour
{
    public float tiltSpeed = 100f;
    public float moveSpeed = 5f;
    public float forwardSpeed = 2f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Tilting
        float tilt = Input.GetAxis("Horizontal") * tiltSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -tilt);

        // Move Up & Down
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(0, vertical, 0);

        // Restrict movement within the camera bounds
        Vector3 pos = transform.position;
        float screenTop = Camera.main.orthographicSize;  // Top of the screen
        float screenBottom = -Camera.main.orthographicSize;  // Bottom of the screen
        pos.y = Mathf.Clamp(pos.y, screenBottom, screenTop);
        transform.position = pos;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
