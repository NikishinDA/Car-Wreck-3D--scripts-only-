using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private Collider _trigger;
    [SerializeField] private ObstacleEffectController effectController;

    private void Awake()
    {
        _trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _trigger.enabled = false;
        EventManager.Broadcast(GameEventsHandler.ObstacleEvent);
        effectController.Activate();
    }
}
