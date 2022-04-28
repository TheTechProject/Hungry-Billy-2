using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    private ScoreData highScore; // Save Data

    // Loads the high score from binary file and displays it on th menu
    public void Start()
    {
        highScore = SaveSystem.LoadHighScore();

        if(highScore != null)
            highScoreText.text = "£" + highScore.highScore.ToString();
    }

    /// <summary>
    /// Runs when the player presses the play game button.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("City");
    }
}
