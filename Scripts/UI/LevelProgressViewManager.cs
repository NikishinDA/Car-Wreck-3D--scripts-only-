using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LevelProgressViewManager : MonoBehaviour
{
    private float _totalLength;
    private float[] _sectionsLength;
    private float[] _sectionsNormalized;
    private float _progress;

    public float Progress => _progress;

    private int _currentSection;
    [SerializeField] private SplineFollower follower;
    private float _savedProgress;

    private void Awake()
    {
        EventManager.AddListener<LevelLoadEvent>(OnLevelLoad);
        EventManager.AddListener<LevelSplineChangeEvent>(OnSplineChange);
        EventManager.AddListener<FinisherStartEvent>(OnFinisherStart);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<LevelLoadEvent>(OnLevelLoad);
        EventManager.RemoveListener<LevelSplineChangeEvent>(OnSplineChange);
        EventManager.RemoveListener<FinisherStartEvent>(OnFinisherStart);

    }

    private void OnFinisherStart(FinisherStartEvent obj)
    {
        this.enabled = false;
    }

    private void OnSplineChange(LevelSplineChangeEvent obj)
    {
        SwitchSection();
    }

    private void OnLevelLoad(LevelLoadEvent obj)
    {
        _sectionsLength = obj.Length;
        foreach (var section in _sectionsLength)
        {
            _totalLength += section;
        }

        _sectionsNormalized = new float[_sectionsLength.Length];
        for (var i = 0; i < _sectionsLength.Length; i++)
        {
            _sectionsNormalized[i] = _sectionsLength[i] / _totalLength;
        }
    }

    private void Update()
    {
        _progress = (float) follower.result.percent * _sectionsNormalized[_currentSection] + _savedProgress;
    }

    private void SwitchSection()
    {
        _currentSection++;
        _currentSection %= _sectionsNormalized.Length;
        _savedProgress = _progress;
    }
}