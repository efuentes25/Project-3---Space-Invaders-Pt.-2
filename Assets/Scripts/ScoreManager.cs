using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        UpdateHighScore();
    }

    private void Update()
    {
        UpdateHighScore();
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "SCORE: \n" + score.ToString("00000");
    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("savedHighScore"))
        {
            if (score > PlayerPrefs.GetInt("savedHighScore"))
            {
                PlayerPrefs.SetInt("savedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("savedHighScore", score);
        }

        highScore = PlayerPrefs.GetInt("savedHighScore", 0);
        finalScoreText.text = "SCORE: \n" + score.ToString("00000");
        highScoreText.text = "HI-SCORE: \n" + highScore.ToString("00000");
    }
}
