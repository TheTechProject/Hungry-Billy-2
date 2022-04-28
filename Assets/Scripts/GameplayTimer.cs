using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayTimer : MonoBehaviour
{
    private float timer = 0.0f;
    private int countdownTimer = 180;

    [SerializeField] private Text countdownText;

    [SerializeField] private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            countdownTimer--;
            timer = 0.0f;
        }
            
        countdownText.text = countdownTimer.ToString();

        if (countdownTimer <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        scoreManager.CheckScore();

        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
}
