using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float playTimer;
    public TextMeshProUGUI timeText;

    [SerializeField]
    private GameObject endGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        playTimer = 30*PlayerPrefs.GetFloat("playTimer");
    }

    // Update is called once per frame
    void Update()
    {
        if (playTimer > 0)
        {
            playTimer -= Time.deltaTime;          
        }
        else
        {
            endGameMenu.SetActive(true);
            playTimer = 0;
        }
        DisplayTime(playTimer);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.SetText("{0:00} : {1:00}", minute, second);
    }
}
