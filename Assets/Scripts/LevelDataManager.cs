using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "LevelDataSO/Level Data Manager")]
public class LevelDataManager : ScriptableObject
{
    public List<LevelDataSO> LevelsDataManager = new List<LevelDataSO>();
    public void UpdateLevelData(string levelName, int jumps, int time, int diamonds)
    {
        LevelDataSO levelData = LevelsDataManager.Find(data => data.SceneLevelName == levelName);
        if (levelData != null)
        {
            levelData.Jumps = jumps;
            levelData.Time = time;
            levelData.Diamonds = diamonds;
        }
    }
}
