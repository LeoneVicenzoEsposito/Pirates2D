using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameMenu : MonoBehaviour
{
    public int highscore;
    public TextMeshProUGUI highscoreText;
    public GameObject endGameMenu;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.SetText("{0:0000} points", highscore);     
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
