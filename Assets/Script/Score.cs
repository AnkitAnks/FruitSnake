using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Reference to score text.
    public TMP_Text scoreText;

    // Reference to Highscore text.
    public TMP_Text highScoreText;

    // Reference to your score text on end screen
    public TMP_Text yourScoreText;

    public int currentScore;
    public int highScore;


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
            //highScore = currentScore;
            highScoreText.text = "HighScore: " + currentScore.ToString();

            // Save the new high score in PlayerPrefs
            PlayerPrefs.SetInt("highScore", currentScore);
            PlayerPrefs.Save();
        }
    }

    public void UpdateScore()
    {
        currentScore++;
    }

    public void SetScore()
    {
        if(currentScore > highScore)
        {
            //Display the score on end screen.
            yourScoreText.text = "NewHighScore: " + currentScore.ToString();
        }
        else
        {
            //Display the score on end screen.
            yourScoreText.text = "YourScore: " + currentScore.ToString();
        }

    }
}
