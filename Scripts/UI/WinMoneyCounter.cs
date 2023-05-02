using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMoneyCounter : MonoBehaviour
{
    [SerializeField] private Text levelMoneyText;
    [SerializeField] private Text totalMoneyText;
    private int _levelMoney;
    private int _totalMoney;

    private void Awake()
    {
        _levelMoney = VarSaver.MoneyCollected;
        _totalMoney = PlayerPrefs
            .GetInt(PlayerPrefsStrings.MoneyTotal.Name, PlayerPrefsStrings.MoneyTotal.DefaultValue);
        totalMoneyText.text = (_totalMoney + _levelMoney).ToString();
        levelMoneyText.text = _levelMoney.ToString();
        //StartCoroutine(WaitCor(1f, 3f));
    }

    private IEnumerator WaitCor(float prepareTime, float tickerTime)
    {
        yield return new WaitForSeconds(prepareTime);
        int fullMoney = _levelMoney + _totalMoney;
        for (float t = 0; t < tickerTime; t += Time.deltaTime)
        {
            levelMoneyText.text = ((int) Mathf.Lerp(_levelMoney, 0, t / tickerTime)).ToString();
            totalMoneyText.text = ((int) Mathf.Lerp(_totalMoney, fullMoney, t / tickerTime)).ToString();
            yield return null;
        }

        levelMoneyText.text = "0";
        totalMoneyText.text = fullMoney.ToString();
    }
}