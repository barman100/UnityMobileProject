using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelStatsTracker: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _jumps;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _diamonds;
    private const string JUMPS_PREFIX = "Jumps: ";
    private const string TIME_PREFIX = "Time: ";
    private const string DIAMONDS_PREFIX = "Diamonds: ";
    public static int Jumps { get; set; }
    public static float LevelTime { get; set; }
    public static int Diamonds { get; set; }

     void Start()
    {
        Jumps = 0;
        LevelTime = 0;
        Diamonds = 0;

        _time.text = TIME_PREFIX + LevelTime;
        _diamonds.text = DIAMONDS_PREFIX + Diamonds;
        _jumps.text = JUMPS_PREFIX + Jumps;

    }
    private void Update()
    {
        _time.text = TIME_PREFIX + (int)Time.time;
        if (Input.GetKeyDown(KeyCode.G))
        {
            LevelTime = Time.time;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

}
