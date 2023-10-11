using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseScreen;

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    //pause/resume game if screen is active/inactive
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseScreen.SetActive(isPaused);
            Time.timeScale = !pauseScreen.activeSelf ? 1.0f : 0.0f;
        }
    }
}
