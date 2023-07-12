using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenButton : MonoBehaviour
{
    public Text score;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        score.text = "Score: " + (3600 - Mathf.Floor(Time.time)).ToString();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
