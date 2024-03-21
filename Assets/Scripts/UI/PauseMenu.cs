using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Assign in inspector
    [SerializeField]
    private GameObject pauseMenuCanvas;

    private bool gameIsPaused = false;

    void Start()
    {
        pauseMenuCanvas.SetActive(false); // Hides the pause menu
        gameIsPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == false)
            {
                OnPause();
            }
            else
            {
                OnResume();
            }
        }
    }

    public void OnPause()
    {  
        OnOpenMenu();

        Time.timeScale = 0f; // Freezes time

        gameIsPaused = true;
    }

    public void OnResume()
    {
        OnCloseMenu();

        Time.timeScale = 1f; // Resumes time

        gameIsPaused = false;
    }

    private void OnOpenMenu()
    {
        pauseMenuCanvas?.SetActive(true); // Shows the pause menu
    }

    private void OnCloseMenu()
    {
        pauseMenuCanvas.SetActive(false); // Hides the pause menu
    }
}
