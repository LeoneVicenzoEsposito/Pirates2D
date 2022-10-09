using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    public void SetPlayingTime(float time)
    {
        Debug.Log(time/2 + " minutes of playtime");
        PlayerPrefs.SetFloat("playTimer", time);
    }

    public void SetSpawnRate(float spawnRate)
    {
        Debug.Log( "Spawn rate of" + 10 / spawnRate + " seconds per enemy");
        PlayerPrefs.SetFloat("spawnRate", spawnRate);
    }

}
