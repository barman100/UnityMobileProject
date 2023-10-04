using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "LevelDataSO/Level Data")]
public class LevelDataSO : ScriptableObject
{
    public string SceneLevelName;
    public string LevelID;
    public int Jumps;
    public int Time;
    public int Diamonds;

    //stats threshholds
    public int JumpThreshhold;
    public int TimeThreshhold;
    public int MaxDiamonds;

    //stars threshholds
    public  int OneStars;
    public  int TwoStars;
    public  int ThreeStar;

}
