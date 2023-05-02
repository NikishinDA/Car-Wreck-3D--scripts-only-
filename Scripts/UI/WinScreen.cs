using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject[] stars;
    private void Awake()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        for (int i = 0; i < VarSaver.StarsNum; i++)
        {
            stars[i].SetActive(true);
        }
    }

    private void OnNextButtonClick()
    {
        PlayerPrefs.Save();
        SceneLoader.LoadNextLevel();
    }
}
