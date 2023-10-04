using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelUIManager : MonoBehaviour
{

    [SerializeField] GameObject WinScreen;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI DeathMessage;
    private const string SCORE_PREFIX = "Score: \n";
    [SerializeField] GameObject[] Stars;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameManager GameManager;

    bool isPaused = false;

    void Start()
    {
        foreach (var item in Stars)
        {
            item.SetActive(false);
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
    }

    public void LoadCompletedLevelScreen(string levelId)
    {
        // get score calculate stars show stars
        
        
        int stars = GameManager.CalculateStars();
        Score.text = SCORE_PREFIX + GameManager.Score;
        for (int i = 0; i < stars; i++)
        {
            Stars[i].SetActive(true);
        }
        WinScreen.SetActive(true);
        if (GameManager.Score > PlayerPrefs.GetInt("level"+levelId + "score"))
        {
            PlayerPrefs.SetInt("level" + levelId + "score",GameManager.Score);
        }
        if (stars > PlayerPrefs.GetInt("level" + levelId + "stars"))
        {
            PlayerPrefs.SetInt("level" + levelId + "stars", stars);
        }
        if (stars >= 1)
        {
            PlayerPrefs.SetInt("level" + (int.Parse(levelId)+1) + "unlock", 1);
        }
        PlayerPrefs.Save();
    }

    public void LoadDeathScreen(string CauseOfDeath)
    {
        DeathMessage.text = "You have been \n" + CauseOfDeath;
        DeathScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
