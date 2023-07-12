using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("PreAlpha");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("PreAlpha");
        }
    }
}
