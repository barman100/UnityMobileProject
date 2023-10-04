using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _jumps;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _diamonds;
    [SerializeField] private LevelDataManager _dataManager;
    [SerializeField] private ParticleSystem _deathSplash;
    [SerializeField] private MeshRenderer _playerRenderer;
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private LevelUIManager _uiManager;

    private const string JUMPS_PREFIX = "Jumps: ";
    private const string TIME_PREFIX = "Time: ";
    private const string DIAMONDS_PREFIX = "Diamonds: ";
    private const int JUMP_SCORE_MODIFIER = -100;
    private const int Time_SCORE_MODIFIER = -20;
    private const int DIAMOND_SCORE_MODIFIER = 1000;
    private bool _oneDeath = false;
    public static int Jumps { get; set; }
    public static int Diamonds { get; set; }
    public static int LevelTime { get; set; }
    public static bool LevelEnded { get; set; }
    public static bool PlayerDied { get; set; }
    public  int Score { get; private set; }

    public string CauseOfDeath { get; set; }  


    private bool isActive = true;

    private void OnApplicationFocus(bool focus)
    {
        isActive = focus;
    }

    void Start()
    {
        InitializeValues();
    }

    private void InitializeValues()
    {
        Jumps = 0;
        Diamonds = 0;
        LevelTime = 0;
        PlayerDied = false;
        LevelEnded = false;
        _time.text = TIME_PREFIX + 0;
        _diamonds.text = DIAMONDS_PREFIX + Diamonds;
        _jumps.text = JUMPS_PREFIX + Jumps;
        _deathSplash.gameObject.SetActive(false);
        CauseOfDeath = "Explodified";
    }

    private void Update()
    {
        UpdateText();

        if (LevelEnded)
        {
            UpdateData();
            _uiManager.LoadCompletedLevelScreen();
        }
        if (PlayerDied && _oneDeath == false)
        {
            PlayerIsKilled();

        }
    }

    private void PlayerIsKilled()
    {
        _playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
        _oneDeath = true;
        _playerRenderer.enabled = false;
        _deathSplash.gameObject.SetActive(true);
        _deathSplash.Play();
        _uiManager.LoadDeathScreen(CauseOfDeath);
    }

    private void UpdateText()
    {
        LevelTime += (int)Time.deltaTime;
        _time.text = TIME_PREFIX + LevelTime;
        _diamonds.text = DIAMONDS_PREFIX + Diamonds;
        _jumps.text = JUMPS_PREFIX + Jumps;
    }

    public void UpdateData()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        _dataManager.UpdateLevelData(sceneName, Jumps, (int)LevelTime, Diamonds);
    }

    public void CalculateScore()
    {
        var scene = SceneManager.GetActiveScene().name;
        var diamonds = _dataManager.DiamondsThresholdDelta(scene,Diamonds);
        var jumps = _dataManager.DiamondsThresholdDelta(scene,Jumps);
        var time = _dataManager.DiamondsThresholdDelta(scene,LevelTime);
        Score = time * Time_SCORE_MODIFIER + jumps * JUMP_SCORE_MODIFIER + diamonds * DIAMOND_SCORE_MODIFIER;
        Score = Score > 0 ? Score : 0;
    }
    public int CalculateStars()
    {
        CalculateScore();
        int starsAmount = _dataManager.ScoreToStars(SceneManager.GetActiveScene().name,Score);
        return starsAmount;
    }
}

