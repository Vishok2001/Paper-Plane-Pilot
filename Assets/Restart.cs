using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Start button clicked! Loading Game Scene...");
        SceneManager.LoadScene("Game");
    }
}
