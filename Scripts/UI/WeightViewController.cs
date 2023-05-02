using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightViewController : MonoBehaviour
{
    [SerializeField] private PlayerPropertiesManager _propertiesManager;
    [SerializeField] private Image lightFill;
    [SerializeField] private Image heavyFill;
    private float _startWeight = 1f;
    private float _lightWeight;
    private float _heavyWeight;
    private void Awake()
    {
        _propertiesManager.WeightChange += PropertiesManagerOnWeightChange;
    }

    private void PropertiesManagerOnWeightChange(float obj)
    {
        float value = obj - _startWeight;
        if (value < 0)
        {
            _lightWeight = Mathf.Abs(value / (_propertiesManager.WeightMinMax.y - 1));
            _heavyWeight = 0;
        }
        else
        {
            _heavyWeight = Mathf.Abs(value / (1 - _propertiesManager.WeightMinMax.x));
            _lightWeight = 0;
        }
    }

    private void Update()
    {
        lightFill.fillAmount = Mathf.Lerp(lightFill.fillAmount, _lightWeight, Time.deltaTime);
        heavyFill.fillAmount = Mathf.Lerp(heavyFill.fillAmount, _heavyWeight, Time.deltaTime);
    }
}
