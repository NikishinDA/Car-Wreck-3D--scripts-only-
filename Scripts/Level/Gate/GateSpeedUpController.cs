using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpeedUpController : GateController
{
    protected override void OnTriggerEnter(Collider other)
    {
        OnActivate();
        var evt = GameEventsHandler.GateSpeedEvent;
        evt.IsGood = true;
        BroadcastGlobalActivateEvent(evt);
    }
}
