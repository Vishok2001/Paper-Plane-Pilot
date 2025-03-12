using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScene : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Instruction button clicked! Loading How To Play Scene...");
        SceneManager.LoadScene("HowToPlay");
    }
}
