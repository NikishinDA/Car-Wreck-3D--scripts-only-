using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelController[] levels;
    [SerializeField] private SplineFollower player;

    private void Awake()
    {
        int levelNum = PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue) - 1;
        LevelController level = Instantiate(levels[levelNum % levels.Length]);
        level.SetPlayer(player);
    }
}
