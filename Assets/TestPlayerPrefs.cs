using UnityEngine;

public class TestPlayerPrefs : MonoBehaviour
{
    private int testScore = 20;  // Example score to test saving/loading

    void Start()
    {
        // Clear any previous PlayerPrefs data before testing
        PlayerPrefs.DeleteAll();

        // Save the test score
        PlayerPrefs.SetInt("Test Score", testScore);
        PlayerPrefs.Save();  // Ensure the data is written to PlayerPrefs

        // Log the saved score
        Debug.Log("Saved Test Score: " + testScore);

        // Load the saved score to confirm it's saved correctly
        int loadedScore = PlayerPrefs.GetInt("Test Score", -1);  // Default to -1 if not found
        Debug.Log("Loaded Test Score: " + loadedScore);
    }
}
