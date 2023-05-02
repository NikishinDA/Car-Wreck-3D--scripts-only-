using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesManager : MonoBehaviour
{
    [SerializeField] private GateController[] managedGates;

    private void Awake()
    {
        foreach (var gate in managedGates)
        {
            gate.GateActivated += GateOnGateActivated;
        }
    }

    private void GateOnGateActivated()
    {
        foreach (var gate in managedGates)
        {
            gate.DisableTrigger();
        }
    }
}
