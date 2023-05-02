using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMoneyCounter : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    private void Awake()
    {
        moneyText.text = PlayerPrefs
            .GetInt(PlayerPrefsStrings.MoneyTotal.Name, PlayerPrefsStrings.MoneyTotal.DefaultValue).ToString();
    }
}
