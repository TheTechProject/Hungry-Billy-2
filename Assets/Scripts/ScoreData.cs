using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container for Save Data.
/// Stores the High Score on this device.
/// </summary>
[System.Serializable]
public class ScoreData
{
    public int highScore;

    public ScoreData(ScoreManager score)
    {
        highScore = score.highScore;
    }
}
