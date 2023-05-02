using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private float _speed = 1f;
    private float _weight = 1f;
    private float _size = 1f;
    private float _nitroModifier = 1f;
    private bool _isSpiked = false;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    public float Weight
    {
        get => _weight;
        set => _weight = value;
    }
    public float Size
    {
        get => _size;
        set => _size = value;
    }
    public float NitroModifier
    {
        get => _nitroModifier;
        set => _nitroModifier = value;
    }
    public bool IsSpiked
    {
        get => _isSpiked;
        set => _isSpiked = value;
    }
    private float _spikeModifier = 1.5f;
    public float GetFullForce()
    {
        if (IsSpiked)
        {
            return Speed * Weight * Size * NitroModifier * _spikeModifier;
        }
        else
        {
            return Speed * Weight * Size * NitroModifier;
        }
    }
    public void ChangeWeightValue(float delta, float min, float max)
    {
       Weight = Mathf.Clamp(Weight + delta, min, max);
    }
}
public class PlayerPropertiesManager : MonoBehaviour
{
    private readonly PlayerInfo _playerProperties = new PlayerInfo();
    [SerializeField] private int numNitroToFull = 10;
    [SerializeField] private int numNitroPenalty = 3;
    private float _nitroAll;
    [SerializeField] private Vector2 speedMinMax;
    [SerializeField] private float speedIteration; 
    [SerializeField] private Vector2 sizeMinMax;   
    [SerializeField] private float sizeIteration;
    [SerializeField] private Vector2 weightMinMax;    
    [SerializeField] private float weightIteration;
    public float NitroAll => _nitroAll;

    public Vector2 WeightMinMax => weightMinMax;

    public Vector2 SpeedMinMax => speedMinMax;

    public PlayerInfo PlayerProperties => _playerProperties;

    public event Action<float> SizeChange;
    public event Action<float> SpeedChange;
    public event Action<float> WeightChange;
    public event Action<bool> SpikeChange;

    private float _nitroDepleted;
    private void Awake()
    {
        EventManager.AddListener<GateSizeEvent>(OnSizeEvent);
        EventManager.AddListener<GateSpeedEvent>(OnGateSpeed);
        EventManager.AddListener<GateWeightEvent>(OnWeightEvent); 
        EventManager.AddListener<GateSpikeEvent>(OnGateSpike);
        EventManager.AddListener<NitroCollectEvent>(OnNitroCollect);
        EventManager.AddListener<ObstacleEvent>(OnObstacleCollision);
        EventManager.AddListener<DebugCallEvent>(OnDebugCall);
        EventManager.AddListener<FinisherPlayEvent>(OnFinisherPlay);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<GateSpeedEvent>(OnGateSpeed);
        EventManager.RemoveListener<GateSizeEvent>(OnSizeEvent);
        EventManager.RemoveListener<GateWeightEvent>(OnWeightEvent); 
        EventManager.RemoveListener<GateSpikeEvent>(OnGateSpike);
        EventManager.RemoveListener<NitroCollectEvent>(OnNitroCollect);
        EventManager.RemoveListener<ObstacleEvent>(OnObstacleCollision);
        EventManager.RemoveListener<DebugCallEvent>(OnDebugCall);
        EventManager.RemoveListener<FinisherPlayEvent>(OnFinisherPlay);

    }

    private void OnFinisherPlay(FinisherPlayEvent obj)
    {
        float mod = _nitroDepleted;
        _playerProperties.NitroModifier = 1f + mod;
    }

    private void OnDebugCall(DebugCallEvent obj)
    {
        numNitroToFull = obj.NOS;
    }

    private void OnObstacleCollision(ObstacleEvent obj)
    {
        _playerProperties.Speed = ChangeValue(_playerProperties.Speed,
             -speedIteration, speedMinMax);
        SpeedChange?.Invoke(_playerProperties.Speed);
        _nitroAll = Mathf.Clamp01(_nitroAll - (float) numNitroPenalty / numNitroToFull);

    }

    private void OnNitroCollect(NitroCollectEvent obj)
    {
        _nitroAll = Mathf.Clamp01(_nitroAll + 1f / numNitroToFull);
    }

    public bool DepleteNitro(float rate)
    {
        bool res;
        if (_nitroAll - rate <= 0f)
        {
            res = true;
        }
        else
            res = false;
        
        _nitroAll = Mathf.Clamp01(_nitroAll - rate);
        _nitroDepleted += rate;
        return res;
    }
    private void OnGateSpeed(GateSpeedEvent obj)
    {
        _playerProperties.Speed = ChangeValue(_playerProperties.Speed,
            obj.IsGood ? speedIteration : -speedIteration, speedMinMax);
        SpeedChange?.Invoke(_playerProperties.Speed);
    }
    private void OnSizeEvent(GateSizeEvent obj)
    {
        _playerProperties.Size = ChangeValue(_playerProperties.Size,
            obj.IsGood ? sizeIteration : -sizeIteration, sizeMinMax);
        SizeChange?.Invoke(_playerProperties.Size);
    }
    private void OnWeightEvent(GateWeightEvent obj)
    {
        _playerProperties.Weight = ChangeValue(_playerProperties.Weight,
            obj.IsGood ? weightIteration : -weightIteration, weightMinMax);
        WeightChange?.Invoke(_playerProperties.Weight);
    }
    private float ChangeValue(float value, float delta, Vector2 minMax)
    {
        return Mathf.Clamp(value + delta, minMax.x, minMax.y);
    }
    private void OnGateSpike(GateSpikeEvent obj)
    {
        _playerProperties.IsSpiked = true;
        SpikeChange?.Invoke(true);
    }

}
