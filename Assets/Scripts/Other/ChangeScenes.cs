using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    // This script requires all the levels to be in the correct order in the build settings.
    // NOTE: This isn't the best way to do this if we have scenes we want to go back and forth between.

    public void LoadNextScene()
    {
        int nextScene = 1;

        // Loads the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + nextScene);
    }

}
