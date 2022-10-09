using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    public static Score instance;


    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endGameScoreText;

    public int highscore;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("{0:0000} points", score);
        highscore = PlayerPrefs.GetInt("Highscore");
    }

    public void AddPoints(int addedPoints)
    {
        score += addedPoints;
        scoreText.SetText("{0:0000} points", score);
        endGameScoreText.SetText("{0:0000} points", score);

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
