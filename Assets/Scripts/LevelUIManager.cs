using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelUIManager : MonoBehaviour
{

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _deathMessage;
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameManager _gameManager;

    private const string SCORE_PREFIX = "Score: \n";
    private bool _isPaused = false;

    void Start()
    {
        DisableStarsUI();
    }

    private void DisableStarsUI()
    {
        foreach (var item in _stars)
        {
            item.SetActive(false);
        }
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        _pauseMenu.SetActive(_isPaused);
    }

    public void LoadCompletedLevelScreen()
    {
        ActiveStars();
        _winScreen.SetActive(true);
    }

    private void ActiveStars()
    {
        int stars = _gameManager.CalculateStars();
        _score.text = SCORE_PREFIX + _gameManager.Score;
        for (int i = 0; i < stars; i++)
        {
            _stars[i].SetActive(true);
        }
    }

    public void LoadDeathScreen(string CauseOfDeath)
    {
        _deathMessage.text = "You have been \n" + CauseOfDeath;
        _deathScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        _isPaused = false;
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
