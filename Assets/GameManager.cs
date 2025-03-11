using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class GameManager : MonoBehaviour
{
    // Singleton for easy access
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Restarting the scene...");
        // You can either reload the current scene or load a game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // This reloads the current scene
    }
}
