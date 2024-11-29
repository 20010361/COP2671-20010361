using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;

    // Restarts the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
        Time.timeScale = 1; // Resumes game time
    }

    // Returns to the main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main_Menu"); // Loads the main menu scene
        Time.timeScale = 1; // Resumes game time
    }
}
