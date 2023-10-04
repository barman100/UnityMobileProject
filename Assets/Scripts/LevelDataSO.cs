using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "LevelDataSO/Level Data")]
public class LevelDataSO : ScriptableObject
{
    public string SceneLevelName;
    public int Jumps;
    public int Time;
    public int Diamonds;
}
