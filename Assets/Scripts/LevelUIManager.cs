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
        if (GameManager.Score > int.Parse(PlayerPrefs.GetString("Level"+levelId + "score")))
        {
            PlayerPrefs.SetString("Level" + levelId + "score",GameManager.Score.ToString());
        }
        if (stars > int.Parse(PlayerPrefs.GetString("Level" + levelId + "stars")))
        {
            PlayerPrefs.SetString("Level" + levelId + "stars", stars.ToString());
        }
        if (stars >= 1)
        {
            PlayerPrefs.SetString("Level" + (int.Parse(levelId)+1) + "unlock", "1");
        }
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
