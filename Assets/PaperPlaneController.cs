using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            Debug.Log("Player crashed! Triggering EndGame...");

            // Destroy the player object
            Destroy(gameObject);

            // Call EndGame() to save the score and do any other game over-related tasks
            Score score = FindObjectOfType<Score>();
            if (score != null)
            {
                score.EndGame();
            }
            else
            {
                Debug.LogError("Score object not found!");
            }

            // Start the coroutine to transition to the GameOver scene
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator LoadGameOverScene()
    {
        // Wait for a brief moment to ensure the score is saved before loading the scene
        Debug.Log("Waiting to transition to GameOver scene...");
        yield return new WaitForSeconds(0.5f);  // Adjust the delay as necessary

        // Log to confirm we are loading the scene
        Debug.Log("Transitioning to GameOver scene...");

        // Load the Game Over scene (ensure this name matches the actual scene name exactly)
        SceneManager.LoadScene("GameOver");
    }
}
