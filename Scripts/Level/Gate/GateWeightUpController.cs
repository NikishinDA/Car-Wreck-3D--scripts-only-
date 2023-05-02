using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWeightUpController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
        
        var evt = GameEventsHandler.GateWeightEvent;
        evt.IsGood = true;
        BroadcastGlobalActivateEvent(evt);
    }
}
