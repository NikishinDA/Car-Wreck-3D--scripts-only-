using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    private float _multiplier;
    [SerializeField] private float addForce;
    [SerializeField] private PlayerPropertiesManager propertiesManager;
    [SerializeField] private Transform arrowHolderTransform;
    [SerializeField] private float depleteRate = 0.01f;
    private Vector3 arrowRot = new Vector3();

    private float _fullMulti;
    private bool _isActive = true;
    private void Awake()
    {
        
    }

    private void Start()
    { 
        Time.timeScale = 0.2f;
        StartCoroutine(Timer(3f));
    }

    private void Update()
    {
        if (!_isActive) return;
        arrowRot.z = Mathf.Lerp(-90, -270, _multiplier);
        arrowHolderTransform.eulerAngles = arrowRot;
        if (Input.GetMouseButtonDown(0))
        {
            _multiplier = Mathf.Clamp01(_multiplier + addForce);
        }

        _multiplier = Mathf.Clamp01(_multiplier - Time.unscaledDeltaTime);
        if (propertiesManager.DepleteNitro(_multiplier * depleteRate * Time.unscaledDeltaTime))
        {
            _isActive = false;
            EventManager.Broadcast(GameEventsHandler.FinisherPlayEvent);
            Time.timeScale = 1f;
        }
    }
    

    private IEnumerator Timer(float time)
    {
        for (float t = 0; t < time; t += Time.unscaledDeltaTime)
        {
            yield return null;
        }
        _isActive = false;
        EventManager.Broadcast(GameEventsHandler.FinisherPlayEvent);
        Time.timeScale = 1f;
    }
}
