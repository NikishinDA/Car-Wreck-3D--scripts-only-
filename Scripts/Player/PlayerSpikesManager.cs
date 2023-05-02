using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikesManager : MonoBehaviour
{
    [SerializeField] private GameObject spikes;
[SerializeField] private GameObject[] trails;
    private void Awake()
    {
        EventManager.AddListener<GateSpikeEvent>(OnGateSpike);
        EventManager.AddListener<GameStartEvent>(OnGameStart);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<GateSpikeEvent>(OnGateSpike);
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);

    }

    private void OnGameStart(GameStartEvent obj)
    {
        foreach (GameObject trail in trails)
        {
            trail.SetActive(true);
        }
    }

    private void OnGateSpike(GateSpikeEvent obj)
    {
        spikes.SetActive(true);
    }
}
