using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWeightDownController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
       
        var evt = GameEventsHandler.GateWeightEvent;
        evt.IsGood = false;
        BroadcastGlobalActivateEvent(evt);
    }
}
