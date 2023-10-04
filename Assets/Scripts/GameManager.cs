using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _jumps;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _diamonds;
    [SerializeField] LevelDataManager _dataManager;
    [SerializeField] ParticleSystem _DeathSplash;
    [SerializeField] SpriteRenderer _PlayerRenderer;

    [SerializeField] GameObject LevelCompletedGO;
    private const string JUMPS_PREFIX = "Jumps: ";
    private const string TIME_PREFIX = "Time: ";
    private const string DIAMONDS_PREFIX = "Diamonds: ";
    public static int Jumps { get; set; }
    public static int Diamonds { get; set; }
    public static float LevelTime { get; set; }
    public static bool LevelEnded { get; set; }
    public static bool PlayerDied { get; set; }

    void Start()
    {
        PlayerDied = false;
        Jumps = 0;
        Diamonds = 0;
        LevelTime = 0;
        LevelEnded = false;

        _time.text = TIME_PREFIX + 0;
        _diamonds.text = DIAMONDS_PREFIX + Diamonds;
        _jumps.text = JUMPS_PREFIX + Jumps;

    }
    private void Update()
    {
        LevelTime += Time.deltaTime;
        _time.text = TIME_PREFIX + (int)LevelTime;
        _diamonds.text = DIAMONDS_PREFIX + Diamonds;
        _jumps.text = JUMPS_PREFIX + Jumps;

        if (LevelEnded)
        {
            UpdateData();
            LevelCompletedGO.SetActive(true);
            if (PlayerDied)
            {
                _DeathSplash.Play();
                _PlayerRenderer.enabled = false;
            }
        }
    }
    public void UpdateData()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        _dataManager.UpdateLevelData(sceneName, Jumps, (int)LevelTime, Diamonds);
    }
}

