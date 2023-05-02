using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressViewController : MonoBehaviour
{
    [SerializeField] private LevelProgressViewManager manager;
    [SerializeField] private Image fill;
    [SerializeField] private Text levelNumberText;
    

    private void Awake()
    {
        levelNumberText.text = PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue).ToString();
    }

    private void Update()
    {
        fill.fillAmount = manager.Progress;
    }
}
