using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Object for resuming the game and loading main menu

    // Resumes the game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Closes the pause menu
        Time.timeScale = 1; // Resumes game time
    }

    // Returns to the main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main_Menu"); // Loads the main menu scene
        Time.timeScale = 1; // Resumes game time
    }

    // Restarts the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
        Time.timeScale = 1; // Resumes game time
    }
}
