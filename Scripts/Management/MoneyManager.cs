using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private void Awake()
    {
        VarSaver.MoneyCollected = 0;
        EventManager.AddListener<MoneyCollectEvent>(OnMoneyCollect);
        EventManager.AddListener<GameOverEvent>(OnGameOver);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<MoneyCollectEvent>(OnMoneyCollect);
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);
    }

    private void OnGameOver(GameOverEvent obj)
    {
        PlayerPrefs.SetInt(PlayerPrefsStrings.MoneyTotal.Name,
            PlayerPrefs.GetInt(PlayerPrefsStrings.MoneyTotal.Name, PlayerPrefsStrings.MoneyTotal.DefaultValue) +
            VarSaver.MoneyCollected);
    }

    private void OnMoneyCollect(MoneyCollectEvent obj)
    {
        VarSaver.MoneyCollected++;
    }
}