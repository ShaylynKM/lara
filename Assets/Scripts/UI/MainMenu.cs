using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Assign in the inspector

    [SerializeField]
    private GameObject settingsMenuCanvas;

    [SerializeField]
    private GameObject mainMenuCanvas;

    private void Start()
    {
        settingsMenuCanvas.SetActive(false); // Hides the settings menu
    }

    #region Main Menu
    public void OnNewGame()
    {
        int sceneToLoad = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneToLoad); // Loads the first scene in the build settings after the main menu
    }

    public void OnContinueGame()
    {
        // Logic here for continuing from a save file
    }

    public void OnSettings()
    {
        mainMenuCanvas.SetActive(false); // Hides the main menu
        settingsMenuCanvas.SetActive(true); // Shows the settings menu
    }

    public void OnQuit()
    {
        // Only works once the game is built.
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    #endregion

    #region Settings Menu

    public void OnBack()
    {
        settingsMenuCanvas.SetActive(false); // Hides the settings menu
        mainMenuCanvas.SetActive(true); // Shows the main menu
    }

    #endregion
}
