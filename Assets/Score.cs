using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the UI Text
    public int score = 0; // Player's score

    public int finalScore = 0;

    public Score scoree;

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();

            if (scoreText == null)
            {
                Debug.LogError(" Score Text UI is missing! Make sure ScoreText is inside the Canvas.");
                return;
            }
        }

        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score Updated: " + score);
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text UI is not assigned in ScoreManager!");
        }
    }

    public void EndGame()
    {
        Debug.Log("EndGame() Triggered!");
        //score = finalScore;
        //finalScore = score;
        PlayerPrefs.SetInt("Final Score", score);
        PlayerPrefs.Save();
        //SceneManager.LoadScene("GameOver");
        Debug.Log("Final Score: " + score);
    }
}