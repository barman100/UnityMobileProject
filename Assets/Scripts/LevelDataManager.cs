using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int JumpsThresholdDelta(string levelName, int jumps)
    {
        LevelDataSO levelData = LevelsDataManager.Find(data => data.SceneLevelName == levelName);
        if (levelData != null)
        {
           int jumpsDelta = levelData.JumpThreshhold > jumps ? 0 : jumps - levelData.JumpThreshhold;
            return jumpsDelta;
        }
        throw new NullReferenceException(levelName + "Couldn't be found in levels");

    }
    public int TimeThresholdDelta(string levelName, int time)
    {
        LevelDataSO levelData = LevelsDataManager.Find(data => data.SceneLevelName == levelName);
        if (levelData != null)
        {
            int timeDelta = levelData.TimeThreshhold > time ? 0 : time - levelData.TimeThreshhold;
            return timeDelta;
        }
        throw new NullReferenceException(levelName + "Couldn't be found in levels");


    }
    public int DiamondsThresholdDelta(string levelName, int diamonds)
    {
        LevelDataSO levelData = LevelsDataManager.Find(data => data.SceneLevelName == levelName);
        if (levelData != null)
        {
            int diamondsDelta = levelData.MaxDiamonds <= diamonds ? levelData.MaxDiamonds : diamonds;
            return diamondsDelta;
        }
        throw new NullReferenceException(levelName + "Couldn't be found in levels");
    }

    public int ScoreToStars(string levelName, int score)
    {
        LevelDataSO levelData = LevelsDataManager.Find(data => data.SceneLevelName == levelName);
        if (levelData.ThreeStar <= score)
            return 3;
        if (levelData.TwoStars <= score)
            return 2;
        if (levelData.OneStars <= score)
            return 1;
        return 0;
    }
}
