using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject minigameScreen;
    [SerializeField] private GameObject tutorial;

    private void Awake()
    {
        EventManager.AddListener<GameStartEvent>(OnGameStart);
        EventManager.AddListener<GameOverEvent>(OnGameOver);
        EventManager.AddListener<FinisherStartEvent>(OnFinisherStart);
        EventManager.AddListener<FinisherPlayEvent>(OnFinisherPlay);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);
        EventManager.RemoveListener<FinisherStartEvent>(OnFinisherStart);
        EventManager.RemoveListener<FinisherPlayEvent>(OnFinisherPlay);

    }

    private void OnFinisherPlay(FinisherPlayEvent obj)
    {
        minigameScreen.SetActive(false);
    }

    private void OnGameStart(GameStartEvent obj)
    {
        startScreen.SetActive(false);
        if (PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue) == 1)
            tutorial.SetActive(true);
        gameScreen.SetActive(true);
    }

    private void OnFinisherStart(FinisherStartEvent obj)
    {
        minigameScreen.SetActive(true);
    }

    private void Start()
    {
        startScreen.SetActive(true);
    }

    private void OnGameOver(GameOverEvent obj)
    {        
        gameScreen.SetActive(false);
        if (obj.IsWin)
        {
            //StartCoroutine(Timer(3f, winScreen));
            
            winScreen.SetActive(true);
        }
        else
        {
            //StartCoroutine(Timer(3f, loseScreen));

            loseScreen.SetActive(true);
        }
        
    }


    private IEnumerator Timer(float time, GameObject screen)
    {
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            yield return null;
        }
        screen.SetActive(true);
    }
}
 