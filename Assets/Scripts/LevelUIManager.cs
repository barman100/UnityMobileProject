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

    [SerializeField] string LevelName;
    [SerializeField] string NextLevelName;

    public void TogglePause()
    {
        isPaused = !isPaused;
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
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(NextLevelName);
    }
}
