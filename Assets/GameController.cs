using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameController : MonoBehaviour
{
    private int score = 20;  // Example score value (this should be updated based on the player's score)

    void Start()
    {
        // Clear PlayerPrefs at the start for testing
        Debug.Log("Game Start: Initial Score = " + score);
    }

    public void EndGame()
    {
        Debug.Log("EndGame triggered! Saving score: " + score);

        // Save the score to PlayerPrefs
        PlayerPrefs.SetInt("Final Score", score);
        PlayerPrefs.Save();  // Make sure data is saved

        // Log after saving
        Debug.Log("Score saved: " + PlayerPrefs.GetInt("Final Score"));

        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        Debug.Log("Waiting before loading scene...");

        // Wait for a short moment to allow PlayerPrefs to save
        yield return new WaitForSeconds(0.1f);

        // Log before transitioning to the next scene
        Debug.Log("Scene transition initiated");

        // Load the Game Over scene
        SceneManager.LoadScene("GameOver");

        // Log after the scene is loaded (should not be printed if scene changes)
        Debug.Log("Scene loaded: GameOverScene");
    }
}
