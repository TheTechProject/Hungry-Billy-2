using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the UI elements for the taxi computer.
/// </summary>
public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreManager scoreManager;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "£" + scoreManager.ScoreThisGame;    
    }
}
