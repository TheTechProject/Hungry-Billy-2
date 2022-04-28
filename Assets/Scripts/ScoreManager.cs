using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int highScore;
    private int scoreThisGame = 0; // The score for the current game in progress.
    public int ScoreThisGame
    {
        get { return scoreThisGame; }
    }

    // Generic points earned for dropping a passenger off.
    private const int pointsForDropOff = 20;

    /// <summary>
    /// Adds £20 for each drop off as well as a time bonus
    /// for quick drop offs.
    /// </summary>
    /// <param name="timeTaken"></param>
    public void AddPoints(float timeTaken)
    {
        scoreThisGame += pointsForDropOff;
        int timeBonus = 1000 / (int)timeTaken;
        scoreThisGame += timeBonus;
    }

    /// <summary>
    /// Checks wether the score earned this game is higher than
    /// the high score, and saves the score if it is.
    /// </summary>
    public void CheckScore()
    {
        if(scoreThisGame >= highScore)
        {
            SaveSystem.SaveHighScore(this);
        }
    }
}
