using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Start button clicked! Loading Game Scene...");
        SceneManager.LoadScene("Game");
    }
}
