using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Starts the game
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level"); // Loads the game level
    }

    // Quits the game
    public void QuitGame()
    {
        Application.Quit(); // Shuts down the game
    }
}
