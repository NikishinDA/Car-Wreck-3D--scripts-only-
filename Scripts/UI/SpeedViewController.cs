using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedViewController : MonoBehaviour
{
    [SerializeField] private PlayerPropertiesManager propertiesManager;
    [SerializeField] private float basicSpeed;
    [SerializeField] private Image speedFill;
    [SerializeField] private Text speedText;
    private float _startSpeed = 1f;

    private float _desiredSpeed = 1f;
    private float _currentSpeed;
    private void Awake()
    {
        _currentSpeed = basicSpeed;
        propertiesManager.SpeedChange += PropertiesManagerOnSpeedChange;
    }

    private void PropertiesManagerOnSpeedChange(float obj)
    {
        _desiredSpeed = obj;
    }

    private void Update()
    {
        speedFill.fillAmount = Mathf.Lerp(speedFill.fillAmount,
            (_desiredSpeed- propertiesManager.SpeedMinMax.x) / (propertiesManager.SpeedMinMax.y - propertiesManager.SpeedMinMax.x), Time.deltaTime);
        _currentSpeed = Mathf.Lerp(_currentSpeed, _desiredSpeed * basicSpeed, Time.deltaTime);
        speedText.text = _currentSpeed.ToString("N0");
    }
}
