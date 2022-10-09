
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetFloat("spawnRate", 1);
        PlayerPrefs.SetFloat("playTimer", 6);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("You clicked to exit the game!");
        Application.Quit();
    }


}
