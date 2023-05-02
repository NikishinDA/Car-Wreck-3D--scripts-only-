using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GateController : MonoBehaviour
{
    private Collider _trigger;
    private void Awake()
    {
        _trigger = GetComponent<Collider>();
    }
    public event Action GateActivated;
    protected void OnActivate()
    {
        GateActivated?.Invoke();
    }

    protected void BroadcastGlobalActivateEvent(GateEvent @event)
    {
        EventManager.Broadcast(@event);
    }

    public void DisableTrigger()
    {
        _trigger.enabled = false;
    }

    protected abstract void OnTriggerEnter(Collider other);
}

