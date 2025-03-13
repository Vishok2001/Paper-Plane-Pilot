using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScene : MonoBehaviour
{
    public TMP_Text finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("Final Score", 0);
        Debug.Log("Loaded Final Score: " + finalScore);

        if (finalScoreText != null)
        {
            finalScoreText.text = "Score: " + finalScore.ToString(); // Display the saved score
            
        }
        else
        {
            Debug.LogError("finalScoreText is not assigned in the Inspector!");
        }


   
    }

    // Update is called once per frame
    void Update()
    {
        // SceneManager.LoadScene("Game");
    }
}