using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private Button retryButton;

    [SerializeField] private Text moneyText;

    private void Awake()
    {
        retryButton.onClick.AddListener(OnRetryButtonClick);
        
        int levelMoney = VarSaver.MoneyCollected;
        int totalMoney = PlayerPrefs
            .GetInt(PlayerPrefsStrings.MoneyTotal.Name, PlayerPrefsStrings.MoneyTotal.DefaultValue);
        moneyText.text = (totalMoney + levelMoney).ToString();
    }

    private void OnRetryButtonClick()
    {
        SceneLoader.ReloadLevel();
    }
}
