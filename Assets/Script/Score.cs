using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    public TMP_Text highScoreText;

    int currentScore;
    int highScore;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;

        // Load high score from PlayerPrefs and assign it to highScore
        highScore = PlayerPrefs.GetInt("highScore", 0); // Set default value to 0 if no highScore exists

        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();

        // Update high score if current score exceeds it
        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = "HighScore: " + highScore.ToString();

            // Save the new high score in PlayerPrefs
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void UpdateScore()
    {
        currentScore++;
    }
}
