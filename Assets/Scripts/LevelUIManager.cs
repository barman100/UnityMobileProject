using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{

    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] GameObject PauseMenu;
    
    bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        PauseMenu.SetActive(isPaused);
    }

    public void LoadCompletedLevelScreen()
    {
        WinScreen.SetActive(true);
    }

    public void LoadDeathScreen()
    {
        DeathScreen.SetActive(true);    
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
