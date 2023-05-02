using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlayerSplineFollowerController : MonoBehaviour
{
    [SerializeField] private PlayerPropertiesManager propertiesManager;
    private SplineFollower _splineFollower;

    private float _startSpeed;
    private void Awake()
    {
        _splineFollower = GetComponent<SplineFollower>();
        _startSpeed = _splineFollower.followSpeed;
        propertiesManager.SpeedChange += PropertiesManagerOnSpeedChange;
        EventManager.AddListener<GameStartEvent>(OnGameStart);
        EventManager.AddListener<GameOverEvent>(OnGameOver);
        _splineFollower.followSpeed = 0;
        EventManager.AddListener<DebugCallEvent>(OnDebugCall);
        EventManager.AddListener<FinisherEndEvent>(OnFinisherEnd);

    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<GameStartEvent>(OnGameStart);
        EventManager.RemoveListener<GameOverEvent>(OnGameOver);
        EventManager.RemoveListener<DebugCallEvent>(OnDebugCall);
        EventManager.RemoveListener<FinisherEndEvent>(OnFinisherEnd);

    }

    private void OnFinisherEnd(FinisherEndEvent obj)
    {
        _splineFollower.followSpeed = 0;
    }

    private void OnDebugCall(DebugCallEvent obj)
    {
        _splineFollower.followSpeed = obj.Speed;
        _startSpeed = obj.Speed;
    }

    private void Update()
    {
        VarSaver.CurrentPlayerProgress = (float) _splineFollower.result.percent;
    }

    private void OnGameOver(GameOverEvent obj)
    {
        _splineFollower.followSpeed = 0;
    }

    private void OnGameStart(GameStartEvent obj)
    {
        _splineFollower.followSpeed = _startSpeed;
    }

    private void PropertiesManagerOnSpeedChange(float obj)
    {
        _splineFollower.followSpeed = _startSpeed * obj;
    }
}
